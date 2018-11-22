using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace ServiceLayers
{
    public static class Logger
    {
        private readonly static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Logger));

        public static void Info(string text) => logger.Info(text);
        public static void Debug(string text) => logger.Debug(text);
        public static void Warn(string text) => logger.Warn(text);
        public static void Error(string text) => logger.Error(text);
        public static void Fatal(string text) => logger.Fatal(text);

        static Logger()
        {
            Log4netSetup();
        }
        public static void Log4netSetup()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.log4net);
            XmlConfigurator.Configure(logRepository, doc.DocumentElement);
        }

    }
}
