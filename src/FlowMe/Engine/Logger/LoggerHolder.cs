using System;
using System.Collections;
using System.Diagnostics;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository;

namespace FlowMe.Engine.Logger
{
    internal static class LoggerHolder
    {
        private static readonly ILoggerRepository LoggerRepository;

        static LoggerHolder()
        {
            LoggerRepository = LogManager.CreateRepository("FlowMe");
            var patternLayout = new PatternLayout {ConversionPattern = "%d %level [%50.50logger] - %message%newline"};
            patternLayout.ActivateOptions();
            var coloredConsoleAppender = new ManagedColoredConsoleAppender() {Layout = patternLayout};
            coloredConsoleAppender.AddMapping(new ManagedColoredConsoleAppender.LevelColors {Level = Level.Debug, ForeColor = ConsoleColor.DarkGray});
            coloredConsoleAppender.AddMapping(new ManagedColoredConsoleAppender.LevelColors {Level = Level.Info, ForeColor = ConsoleColor.Black});
            coloredConsoleAppender.AddMapping(new ManagedColoredConsoleAppender.LevelColors {Level = Level.Warn, ForeColor = ConsoleColor.DarkYellow});
            coloredConsoleAppender.AddMapping(new ManagedColoredConsoleAppender.LevelColors {Level = Level.Error, ForeColor = ConsoleColor.DarkRed});
            coloredConsoleAppender.ActivateOptions();
            BasicConfigurator.Configure(LoggerRepository, coloredConsoleAppender);
        }

        internal static ILog Logger => LogManager.GetLogger(LoggerRepository.Name, new StackTrace().GetFrame(1).GetMethod().ReflectedType);
    }
}