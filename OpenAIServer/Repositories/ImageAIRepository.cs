using OpenAI;
using OpenAI.Images;
using OpenAIServer.Infrastructures;
using OpenAIServer.Interfaces;
using System.ClientModel;

namespace OpenAIServer.Repositories
{
    public class ImageAIRepository : IImageAIRepository
    {
        private OpenAIClient openAIClient { get; set; }
        private CancellationTokenSource cts { get; set; }
        private readonly int timeSeconds = 25;

        public ImageAIRepository(OpenAIClient openAIClient)
        { 
            this.openAIClient = openAIClient;
            cts = new CancellationTokenSource();
        }

        public async Task<string> getUrl(string requestAI)
        {
            setTimeOfCts(this.timeSeconds);

            ClientResult<GeneratedImage>? imageResponce = await openAIClient.GetImageClient("dall-e-3").GenerateImageAsync(requestAI, getImageOptions(), cts.Token);

            if (imageResponce == null) 
                throw new ImageAIException("AI DALL-E-3 did not generate image asteroid", requestAI);

            return imageResponce.Value.ImageUri.OriginalString;

        }

        private ImageGenerationOptions getImageOptions() => new ImageGenerationOptions()
        {
            Quality = GeneratedImageQuality.Standard,
            Size = GeneratedImageSize.W1024xH1024,
            Style = GeneratedImageStyle.Vivid,
            ResponseFormat = GeneratedImageFormat.Uri,
        };

        private void setTimeOfCts(int timeSeconds)
        {
            cts.CancelAfter(TimeSpan.FromSeconds(timeSeconds));
        }
    }
}
