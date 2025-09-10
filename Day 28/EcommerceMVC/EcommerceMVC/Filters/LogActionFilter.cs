using Microsoft.AspNetCore.Mvc.Filters;

namespace EcommerceMVC.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Nothing to do before action executes right now
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {
                // Get username from session
                var username = context.HttpContext.Session.GetString("Username") ?? "Guest";

                // Create log directory if missing
                string logDir = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
                if (!Directory.Exists(logDir))
                    Directory.CreateDirectory(logDir);

                // Log file path
                string logPath = Path.Combine(logDir, "PurchaseLog.txt");

                // Prepare log content
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | " +
                                    $"User: {username} | " +
                                    $"Controller: {context.ActionDescriptor.DisplayName}";

                // Append log to file
                File.AppendAllText(logPath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LogActionFilter] Error: {ex.Message}");
            }
        }
    }
}
