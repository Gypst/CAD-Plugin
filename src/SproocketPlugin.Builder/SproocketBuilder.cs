﻿namespace SproocketPlugin.Builder
{
    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.Geometry;

    using BL;

    using System;

    /// <summary>
    /// Класс, отвеающий за построение модели.
    /// </summary>
    public class SproocketBuilder
    {
        #region Fields

        /// <summary>
        /// Параметры модели.
        /// </summary>
        private SproocketParameters _parameters;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="parameters">Параметры для построения модели.</param>
        public SproocketBuilder(SproocketParameters parameters)
        {
            _parameters = parameters;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Уничтожает созданную модель, если такая есть.
        /// </summary>
        /// <param name="database">База данных текущего документа AutoCAD.</param>
        /// <param name="blockName">Название блока.</param>
        private void EraseExistingModel(Database database, string blockName)
        {
            ObjectId blockId = ObjectId.Null;

            using (Transaction transaction = database.TransactionManager.
                StartTransaction())
            {
                BlockTable blockTable = (BlockTable)transaction.GetObject(
                    database.BlockTableId, OpenMode.ForRead);

                if (blockTable.Has(blockName))
                {
                    blockId = blockTable[blockName];
                }

                if (blockId.IsNull)
                {
                    return;
                }

                BlockTableRecord blockTabelRecord = (BlockTableRecord)transaction.
                    GetObject(blockId, OpenMode.ForRead);

                var blkRefs = blockTabelRecord.GetBlockReferenceIds(true, true);
                if (blkRefs != null && blkRefs.Count > 0)
                {
                    foreach (ObjectId blkRefId in blkRefs)
                    {
                        BlockReference blkRef = (BlockReference)transaction.
                            GetObject(blkRefId, OpenMode.ForWrite);
                        blkRef.Erase();
                    }
                }

                blkRefs = blockTabelRecord.GetBlockReferenceIds(true, true);
                if (blkRefs == null || blkRefs.Count == 0)
                {
                    blockTabelRecord.UpgradeOpen();
                    blockTabelRecord.Erase();
                }

                transaction.Commit();
            }
        }

        /// <summary>
        /// Строит модель.
        /// </summary>
        public void Build()
        {
            var activeDocument = Application.DocumentManager.MdiActiveDocument;
            var database = activeDocument.Database;

            var blockName = "Sproocket";

            using (var documentLock = activeDocument.LockDocument())
            {
                // Удаляем созданную модель, если такая есть.
                EraseExistingModel(database, blockName);

                using (var transaction = database.TransactionManager.
                    StartTransaction())
                {
                    // Открываем таблицу блоков для записи.
                    BlockTable blockTable = (BlockTable)transaction.
                        GetObject(database.BlockTableId, OpenMode.ForWrite);

                    // Создаем новое определение блока и даем ему имя.
                    BlockTableRecord blockTableRecord = new BlockTableRecord();
                    blockTableRecord.Name = blockName;

                    // Добавляем созданное определение блока в таблицу блоков и в транзакцию,
                    // запоминаем ID созданного определения блока.
                    ObjectId blockTableRecordId = blockTable.Add(blockTableRecord);
                    transaction.AddNewlyCreatedDBObject(blockTableRecord, true);

                    // Задаем параметры.
                    double outerRadius  = _parameters.OuterDiameter / 2;
                    double innerRadius  = _parameters.InnerDiameter / 2;
                    double thickness    = _parameters.Thickness;
                    int    toothCount   = _parameters.ToothCount;
                    double toothHeight  = _parameters.ToothHeight;

                    // Создание заготовки звёздочки и смещение его на позицию 0, 0, 0.
                    var body = CreateSproocketBody(outerRadius, innerRadius,
                        thickness);
                    body.TransformBy(Matrix3d.Displacement(
                        new Point3d(0, 0, thickness / 2) - Point3d.Origin));

                    // Создание зуба.
                    var tooth = CreateTooth(toothHeight, thickness);
                    tooth.TransformBy(Matrix3d.Displacement(
                        new Point3d(outerRadius + toothHeight / 2, 0, thickness / 2)
                        - Point3d.Origin));

                    //Размножение зубьев круговым массивом
                    body = ApplyPolarArrayOnBody(body, toothCount, tooth);

                    // Добавление модели в транзакцию
                    blockTableRecord.AppendEntity(body);
                    transaction.AddNewlyCreatedDBObject(body, true);

                    // Открываем пространсто моделей для записи,
                    // создаем новое вхождение блока, используя
                    // ранее сохраненный ID определения блока
                    BlockTableRecord modelSpace = (BlockTableRecord)transaction.
                        GetObject(blockTable[BlockTableRecord.ModelSpace], 
                        OpenMode.ForWrite);
                    BlockReference blockReference = new BlockReference(
                        Point3d.Origin, blockTableRecordId);

                    // Добавляем созданное вхождение блока
                    // на пространство модели и в транзакцию
                    modelSpace.AppendEntity(blockReference);
                    transaction.AddNewlyCreatedDBObject(blockReference, true);

                    transaction.Commit();
                }
            }

        }

        /// <summary>
        /// Создает объект-заготовку <see cref="Solid3d"/> цепного колеса (без зубьев).
        /// </summary>
        /// <param name="outerRadius">Внешний радиус цепного колеса.</param>
        /// <param name="innerRadius">Внутренний радиус цепного колеса.</param>
        /// <param name="thickness">Толщина цепного колеса.</param>
        /// <returns>Модель в виде <see cref="Solid3d"/>.</returns>
        private Solid3d CreateSproocketBody(double outerRadius, 
            double innerRadius, double thickness)
        {
            var body = new Solid3d();
            body.SetDatabaseDefaults();
            body.CreateFrustum(thickness, outerRadius, 
                outerRadius, outerRadius);
            //TODO: Теперь в шайбе надо сделать отверстие with innerRadius

            return body;
        }

        /// <summary>
        /// Создает объект <see cref="Solid3d"/> зуб.
        /// </summary>
        /// <param name="heigth">Высота элемента.</param>
        /// <returns>Модель в виде <see cref="Solid3d"/>.</returns>
        private Solid3d CreateTooth(double toothHeight, 
            double thickness)
        {
            //TODO: Сделать зубья вместо лепестков
            var model = new Solid3d();
            model.SetDatabaseDefaults();
            model.CreateFrustum(toothHeight, thickness,
                thickness, thickness);

            return model;
        }

        /// <summary>
        /// Создает элементы круговым массивом и соединяет их с базовым объектом в единую модель.
        /// </summary>
        /// <param name="body">Базовая модель для трансформации (звёздочка без зубьев).</param>
        /// <param name="elementsCount">Количесвто элементов для построения (количство зубьев).</param>
        /// <param name="element">Повторяющийся элемент для круг-массива (зуб).</param>
        /// <returns>Модель с круг-массивом из эелементов (зубчатое колесо с зубами).</returns>
        private Solid3d ApplyPolarArrayOnBody(Solid3d body, 
            int elementsCount, Solid3d element)
        {
            double angle = 360 / elementsCount * Math.PI / 180;

            for (int i = 0; i < elementsCount; i++)
            {
                var newGuid = element.Clone() as Solid3d;
                newGuid.TransformBy(Matrix3d.Rotation(angle * i, 
                    Vector3d.ZAxis, Point3d.Origin));
                body.BooleanOperation(BooleanOperationType.BoolUnite, newGuid);
            }

            return body;
        }

        #endregion Methods
    }
}