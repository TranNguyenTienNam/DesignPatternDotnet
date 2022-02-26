using System;

namespace ChainOfResponsibility
{
    public abstract class AbstractLogger
    {
        public static int INFO = 1;
        public static int DEBUG = 2;
        public static int ERROR = 3;

        protected int level;

        protected AbstractLogger nextLogger;

        public void SetNextLogger(AbstractLogger nextLogger)
        {
            this.nextLogger = nextLogger;
        }

        public void LogMessage(int level, String message)
        {
            if (this.level <= level)
            {
                Write(message);
            }
            if (nextLogger != null)
            {
                nextLogger.LogMessage(level, message);
            }
        }

        abstract protected void Write(String message);
    }

    public class ConsoleLogger : AbstractLogger
    {
        public ConsoleLogger(int level)
        {
            this.level = level;
        }

        override protected void Write(String message)
        {
            Console.WriteLine("Standard Console::Logger: " + message);
        }
    }

    public class ErrorLogger : AbstractLogger
    {
        public ErrorLogger(int level)
        {
            this.level = level;
        }

        override protected void Write(String message)
        {
            Console.WriteLine("Error Console::Logger: " + message);
        }
    }

    public class FileLogger : AbstractLogger
    {

        public FileLogger(int level)
        {
            this.level = level;
        }

        override protected void Write(String message)
        {
            Console.WriteLine("File::Logger: " + message);
        }
    }

    class Program
    {
        private static AbstractLogger GetChainOfLoggers()
        {
            AbstractLogger errorLogger = new ErrorLogger(AbstractLogger.ERROR);
            AbstractLogger fileLogger = new FileLogger(AbstractLogger.DEBUG);
            AbstractLogger consoleLogger = new ConsoleLogger(AbstractLogger.INFO);

            errorLogger.SetNextLogger(fileLogger);
            fileLogger.SetNextLogger(consoleLogger);

            return errorLogger;
        }

        static void Main(string[] args)
        {
            AbstractLogger loggerChain = GetChainOfLoggers();

            loggerChain.LogMessage(AbstractLogger.INFO, "This is an information.");

            Console.WriteLine("=======");

            loggerChain.LogMessage(AbstractLogger.DEBUG, "This is an debug level information.");

            Console.WriteLine("=======");

            loggerChain.LogMessage(AbstractLogger.ERROR, "This is an error information.");
        }
    }
}