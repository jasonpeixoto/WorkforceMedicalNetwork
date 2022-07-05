using System;
using System.Runtime.CompilerServices;

namespace WorkforceMedicalNetwork.Api.UnitTests.TestFramework
{
    public interface ILogger : IDisposable
    {
        /// <summary>
        /// Determines if specified log level is enabled.
        /// </summary>
        /// <value>True if log level is enabled</value>
        bool IsEnabled(int level);

        /// <summary>
        /// Logs an information message.
        /// </summary>
        /// <param name="messageStr">Log message string</param>
        /// <param name="memberName">Caller method name</param>
        /// <param name="sourceFilePath">Caller source file path</param>
        /// <param name="sourceLineNumber">Caller source line number</param>
        void Information(string messageStr,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Logs a information message with late constructed message.
        /// </summary>
        /// <param name="messageFunPtr">Message function pointer</param>
        /// <param name="memberName">Caller method name</param>
        /// <param name="sourceFilePath">Caller source file path</param>
        /// <param name="sourceLineNumber">Caller source line number</param>
        void Information(Func<string> messageFunPtr,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Logs an information message with exception.
        /// </summary>
        /// <param name="messageStr">The message to log</param>
        /// <param name="exception">The exception to log</param>
        /// <param name="memberName">Caller method name</param>
        /// <param name="sourceFilePath">Caller source file path</param>
        /// <param name="sourceLineNumber">Caller source line number</param>
        void Information(string messageStr, Exception exception,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Logs an formatted information message.
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void InformationFormat(string format, params object[] args);

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="messageStr">Log message string</param>
        /// <param name="memberName">Caller method name</param>
        /// <param name="sourceFilePath">Caller source file path</param>
        /// <param name="sourceLineNumber">Caller source line number</param>
        void Warning(string messageStr,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Logs a warn message with late constructed message.
        /// </summary>
        /// <param name="messageFunPtr">Message function pointer</param>
        /// <param name="memberName">Caller method name</param>
        /// <param name="sourceFilePath">Caller source file path</param>
        /// <param name="sourceLineNumber">Caller source line number</param>
        void Warning(Func<string> messageFunPtr,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Logs a warning message with exception.
        /// </summary>
        /// <param name="messageStr">The message to log</param>
        /// <param name="exception">The exception to log</param>
        /// <param name="memberName">Caller method name</param>
        /// <param name="sourceFilePath">Caller source file path</param>
        /// <param name="sourceLineNumber">Caller source line number</param>
        void Warning(string messageStr, Exception exception,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Logs a formatted warning message.
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void WarningFormat(string format, params object[] args);

        /// <summary>
        /// Logs a debug message text into log file. 
        /// </summary>
        /// <param name="messageStr">Log message string</param>
        /// <param name="memberName">Caller method name</param>
        /// <param name="sourceFilePath">Caller source file path</param>
        /// <param name="sourceLineNumber">Caller source line number</param>
        void Debug(string messageStr,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Logs a debug message with late constructed message.
        /// </summary>
        /// <param name="messageFunPtr">Message function pointer</param>
        /// <param name="memberName">Caller method name</param>
        /// <param name="sourceFilePath">Caller source file path</param>
        /// <param name="sourceLineNumber">Caller source line number</param>
        void Debug(Func<string> messageFunPtr,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Logs a debug message with exception into log file.
        /// </summary>
        /// <param name="messageStr">The message to log</param>
        /// <param name="exception">The exception to log</param>
        /// <param name="memberName">Caller method name</param>
        /// <param name="sourceFilePath">Caller source file path</param>
        /// <param name="sourceLineNumber">Caller source line number</param>
        void Debug(string messageStr, Exception exception,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Logs formatted debug message.
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void DebugFormat(string format, params object[] args);

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="messageStr">Log message string</param>
        /// <param name="memberName">Caller method name</param>
        /// <param name="sourceFilePath">Caller source file path</param>
        /// <param name="sourceLineNumber">Caller source line number</param>
        void Error(string messageStr,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Logs an error message with late constructed message.
        /// </summary>
        /// <param name="messageFunPtr">Message function pointer</param>
        /// <param name="memberName">Caller method name</param>
        /// <param name="sourceFilePath">Caller source file path</param>
        /// <param name="sourceLineNumber">Caller source line number</param>
        void Error(Func<string> messageFunPtr,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Logs an error message with exception.
        /// </summary>
        /// <param name="messageStr">The message to log</param>
        /// <param name="exception">The exception to log</param>
        /// <param name="memberName">Caller method name</param>
        /// <param name="sourceFilePath">Caller source file path</param>
        /// <param name="sourceLineNumber">Caller source line number</param>
        void Error(string messageStr, Exception exception,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Logs formatted error message.
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void ErrorFormat(string format, params object[] args);

        /// <summary>
        /// Logs a fatal message.
        /// </summary>
        /// <param name="messageStr">Log message string</param>
        /// <param name="memberName">Caller method name</param>
        /// <param name="sourceFilePath">Caller source file path</param>
        /// <param name="sourceLineNumber">Caller source line number</param>
        void Fatal(string messageStr,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Logs a fatal message with late constructed message.
        /// </summary>
        /// <param name="messageFunPtr">Message function pointer</param>
        /// <param name="memberName">Caller method name</param>
        /// <param name="sourceFilePath">Caller source file path</param>
        /// <param name="sourceLineNumber">Caller source line number</param>
        void Fatal(Func<string> messageFunPtr,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Logs a fatal message with exception.
        /// </summary>
        /// <param name="messageStr">The message to log</param>
        /// <param name="exception">The exception to log</param>
        /// <param name="memberName">Caller method name</param>
        /// <param name="sourceFilePath">Caller source file path</param>
        /// <param name="sourceLineNumber">Caller source line number</param>
        void Fatal(string messageStr, Exception exception,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Logs a formatted fatal message.
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void FatalFormat(string format, params object[] args);
    };
}