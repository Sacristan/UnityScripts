#define LOGGER_LOG_ENABLED
#define LOGGER_LOG_WARNING_ENABLED
#define LOGGER_LOG_ERROR_ENABLED
#define LOGGER_LOG_EXCEPTION_ENABLED

using UnityEngine;
using System;

namespace Sacristan.Utils
{
    public static class Logger
    {
        public static void Log(string message)
        {
#if LOGGER_LOG_ENABLED
            Debug.Log(message);
#endif
        }

        public static void LogWarning(string message)
        {
#if LOGGER_LOG_WARNING_ENABLED
            Debug.LogWarning(message);
#endif
        }

        public static void LogError(string message)
        {
#if LOGGER_LOG_ERROR_ENABLED
            Debug.LogError(message);
#endif
        }

        public static void LogException(Exception exception)
        {
#if LOGGER_LOG_EXCEPTION_ENABLED
            Debug.LogError(string.Format("Exception message: {0} stacktrace: {1}", exception.Message, exception.StackTrace));
#endif
        }
    }
}
