using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace LS.Utility
{

    public static class UnityLogger
    {
        public enum LogType
        {
            Normal,
            Bold,
            Italic,
            BoldItalic
        }

        public enum MessageType
        {
            Log,
            Error,
            Warning,
            Assertion
        }

        public enum ColorType
        {
            White,
            Red,
            Green,
            Blue,
            Yellow,
            Cyan,
            Magenta,
            Orange,
            Purple,
            Gray,
            Black
        }

        private static bool IsDevelopmentBuild()
        {
            return Debug.isDebugBuild;
        }

        public static void Log(this Object myObj, string message, Object highlightedObject = null, ColorType color = ColorType.White, MessageType messageType = MessageType.Log, LogType logType = LogType.Normal)
        {
            if (IsDevelopmentBuild())
            {
                string logTypeString = GetLogTypeString(logType);
                string logTypeCloseString = GetLogTypeCloseString(logType);
                string messageTypeString = GetMessageTypeString(messageType);
                string formattedMessage = FormatMessage(message);
                string name = (myObj != null ? myObj.name : "NullObject");
                string fullMessage = $"{logTypeString}[{messageTypeString}][{name}]: {formattedMessage}{logTypeCloseString}".Color(color);
                Debug.Log(fullMessage, highlightedObject);
            }
        }


        private static string FormatMessage(string message)
        {
            return message;
        }

        private static string GetLogTypeString(LogType logType)
        {
            switch (logType)
            {
                case LogType.Bold:
                    return "<b>";
                case LogType.Italic:
                    return "<i>";
                case LogType.BoldItalic:
                    return "<b><i>";
                default:
                    return "";
            }
        }

        private static string GetLogTypeCloseString(LogType logType)
        {
            switch (logType)
            {
                case LogType.Bold:
                    return "</b>";
                case LogType.Italic:
                    return "</i>";
                case LogType.BoldItalic:
                    return "</i></b>";
                default:
                    return "";
            }
        }

        private static string GetMessageTypeString(MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Log:
                    return "Log";
                case MessageType.Error:
                    return "Error";
                case MessageType.Warning:
                    return "Warning";
                case MessageType.Assertion:
                    return "Assertion";
                default:
                    return "Log";
            }
        }

        private static string Color(this string myStr, ColorType color)
        {
            string colorName = Enum.GetName(typeof(ColorType), color).ToLower();
            return $"<color={colorName}>{myStr}</color>";
        }
    }
}
