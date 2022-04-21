using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic.Devices;
using SprocketPlugin.BL;
using SprocketPlugin.Builder;

[assembly: CommandClass(typeof(AutoCADConnector.StartPluginCommand))]

namespace AutoCADConnector
{
    using SprocketPlugin.UI;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// Класс, отвечающий за запуск плагнина из AutoCAD.
    /// </summary>
    public class StartPluginCommand
    {
        /// <summary>
        /// Команда для запуска плагина.
        /// </summary>
        [CommandMethod("CreateSproocket", CommandFlags.Modal)]
        public void StartCommand()
        {
            Application.ShowModelessDialog(new SprocketForm());
        }

        /// <summary>
        /// Команда для запуска нагрузочного тестированя 
        /// построения модели с параметрами по умолчанию.
        /// </summary>
        [CommandMethod("StressTest", CommandFlags.Session)]
        public void StressTest()
        {
            var gearParameters = new SprocketParameters();
            var builder = new SprocketBuilder(gearParameters);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var streamWriter = new StreamWriter($"log.txt", true);
            var currentProcess = Process.GetCurrentProcess();
            var count = 0;

            while (count < 30000)
            {
                builder.Build();
                var computerInfo = new ComputerInfo();
                var usedMemory = (computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory);
                streamWriter.WriteLine(
                    $"{++count}\t{stopWatch.ElapsedMilliseconds}\t{usedMemory}");
                streamWriter.Flush();
            }
        }
    }

}
