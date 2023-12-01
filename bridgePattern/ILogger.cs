using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The ILogger interface defines a contract for logging mechanisms in the application.
// Any class that implements this interface will provide a concrete implementation of the Log method,
// which is intended to handle the logging of messages.

public interface ILogger
{
    // The specifics of how the message is logged (e.g., to a console, file, or external service)
    // will depend on the concrete implementation of the ILogger interface.
    // The message parameter is the information that needs to be logged.
    void Log(string message);
}