namespace OpenAIServer.Infrastructures
{
    public class ImageAiException : Exception
    {
        public string property { get; } = null!;

        public ImageAiException(string message, string property) 
        { 
            this.property = property;
        }
    }
}
