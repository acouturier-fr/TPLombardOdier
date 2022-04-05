using DistributeurBoissons.Class;
using DistributeurBoissons.Views;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using System.Reflection;

namespace DistributeurBoissons
{
    internal static class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        static string strExeFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        static string log4NetPath = Path.Combine(strExeFilePath,"Properties","Ressources","Log4Net");
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            BasicConfigurator.Configure(new FileAppender(new SimpleLayout(), Path.Combine(log4NetPath, "logs.txt")));
            log.Info(DateTime.Now.ToString() + " - Start Application " ); ;

            Application.Run(new VendingMachineForm());
        }

    }
}