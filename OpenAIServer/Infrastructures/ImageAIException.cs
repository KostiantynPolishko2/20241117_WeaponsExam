namespace OpenAIServer.Infrastructures
{
    public class ImageAIException : Exception
    {
        public string property { get; } = null!;

        public ImageAIException(string message, string property) : base(message) => this.property = property;
    }
}
