namespace OpenAIServer.Interfaces
{
    public interface IHandlerException
    {
        public Task HandleExceptionAsync(HttpContext context, Exception exception);
    }
}
