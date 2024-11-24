namespace OpenAIServer.Interfaces
{
    public interface IImageAIRepository
    {
        public Task<string> getUrl(string requestAI);
    }
}
