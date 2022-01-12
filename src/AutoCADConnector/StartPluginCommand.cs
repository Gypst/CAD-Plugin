using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;

[assembly: CommandClass(typeof(AutoCADConnector.StartPluginCommand))]

namespace AutoCADConnector
{
    using SproocketPlugin.UI;

    /// <summary>
    /// Класс, отвечающий за запуск плагнина из AutoCAD.
    /// </summary>
    public class StartPluginCommand
    {
        /// <summary>
        /// Команда для запуска плагина.
        /// </summary>
        [CommandMethod("BuildSproocket", CommandFlags.Modal)]
        public void StartCommand()
        {
            Application.ShowModelessDialog(new MainForm());
        }
    }

}
