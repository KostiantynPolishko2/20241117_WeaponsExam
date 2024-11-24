using Microsoft.AspNetCore.Identity;
using OpenAI;

namespace OpenAIServer.Handlers
{
    public class HandlerOpenAIClient
    {
        private CancellationTokenSource cts = null!;
        private readonly int timeRequest = 10;
        private string apiKey = string.Empty;

        private void setToken()
        {
            this.cts = new CancellationTokenSource();
            this.cts.CancelAfter(TimeSpan.FromSeconds(this.timeRequest));
        }

        public async Task<OpenAIClient> CreateOpenAIClientAsync(string? url)
        {
            if (string.IsNullOrEmpty(url)){
                throw new InvalidOperationException("URL for OpenAI API Key is missing");
            }

            setToken();

            using (HttpClient httpClient = new HttpClient()) 
            { 
                this.apiKey = await httpClient.GetStringAsync(new Uri(url), this.cts.Token);

                if (string.IsNullOrEmpty(apiKey)) {
                    throw new InvalidOperationException("OpenAI API Key is not configured");
                }
            }

            return new OpenAIClient(apiKey);
        }
    }
}
