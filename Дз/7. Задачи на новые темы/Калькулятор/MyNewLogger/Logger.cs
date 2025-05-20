using System;
using System.IO;

namespace MyNewLogger
{
    public class Logger
    {

    }
    interface Ilogger
    {
        void LogInformation(string message);
        void LogError(Exception exception, string? additionalMessage = null);
    }

    class ConsoleLogger : Ilogger
    {
        public void LogInformation(string message)
        {
            Console.WriteLine(message + " LogInformation");
        }

        public void LogError(Exception exception, string? additionalMessage = null)
        {
            Console.WriteLine("LogError " + exception.Message);
            if (!string.IsNullOrEmpty(additionalMessage)) Console.WriteLine("additionalMessage " + additionalMessage);

        }
    }

    class FileLogger : Ilogger
    {
        private string _filePath;
        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void LogInformation(string message)
        {
            using (var writer = new StreamWriter(_filePath))
            {
                writer.WriteLine(message + " LogInformation");
            }
        }

        public void LogError(Exception exception, string? additionalMessage = null)
        {
            using (var write = new StreamWriter(_filePath))
            {
                write.WriteLine("LogError " + exception.Message);
                if (!string.IsNullOrEmpty(additionalMessage)) Console.WriteLine($"LogError additionalMessage {additionalMessage} ");
            }
        }
    }

    class CompositeLogger : Ilogger // необходимы поянения ко всей этой хуйне
    {
        private Ilogger _consoleLogger; //необходимы пояснения в упор не понимаю 

        private Ilogger _fileLogger;

        public CompositeLogger(Ilogger ConsoleLogger, Ilogger FileLogger)
        {
            _consoleLogger = ConsoleLogger;
            _fileLogger = FileLogger;
        }

        public void LogInformation(string message)
        {
            _consoleLogger.LogInformation(message + "LogInformation");
            _fileLogger.LogInformation(message + "LogInformation");
        }

        public void LogError(Exception exception, string? additionalMessage = null)
        {
            _consoleLogger.LogError(exception, additionalMessage);
            _fileLogger.LogError(exception, additionalMessage);
        }
    }
}
