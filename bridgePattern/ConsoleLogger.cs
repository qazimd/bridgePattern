using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The ConsoleLogger class is an implementation of the ILogger interface.
// It provides a logging mechanism that outputs messages to the console.
// This class can be utilized throughout the application to log various kinds of information,
// such as errors, information messages, or debugging details.
public class ConsoleLogger : ILogger
{
    // The Log method takes a string message as a parameter and outputs it to the console.
    // It's prefixed with "[Log]: " to indicate that the output is a log message.
    public void Log(string message)
    {
        //  It uses the Console.WriteLine method
        // to output the message to the standard output stream.
        // The $ before the string starts a string interpolation, allowing us to embed
        // the 'message' variable directly within the string literal.
        Console.WriteLine($"[Log]: {message}");
    }
}