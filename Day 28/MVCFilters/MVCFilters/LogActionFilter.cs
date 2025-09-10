using Microsoft.AspNetCore.Mvc.Filters;

public class LogActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Before action runs → blue
        context.HttpContext.Items["BeforeLog"] = $"<p style='color:blue;'>[Log] Executing: {context.ActionDescriptor.DisplayName}</p>";
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // After action runs → green
        context.HttpContext.Items["AfterLog"] = $"<p style='color:green;'>[Log] Executed: {context.ActionDescriptor.DisplayName}</p>";
    }
}
