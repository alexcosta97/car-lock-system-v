using System;
using System.IO;

/// <summary>
/// Static logger class that allows direct logging of anything to a text file
/// </summary>
public static class Logger
{
    public static void Log(object message)
    {
        File.AppendAllText("CarLockSystem.log", DateTime.Now + " : " + message + Environment.NewLine);
    }
}