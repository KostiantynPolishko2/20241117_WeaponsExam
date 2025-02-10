namespace ClientPageServer.PL.Interfaces
{
    public interface IHandlerException
    {
        public Task HandleExceptionAsync(HttpContext context, Exception exception);
    }
}
