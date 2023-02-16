using Newtonsoft.Json;
using System.Text;
using OpenAI_API;
using OpenAI_API.Completions;

namespace ContactManagementAssistant.ChatGptClient
{
    class ChatGptClient: IChatGptClient
    {
        private const string endpoint = "https://api.openai.com/v1/completions";
        private const string apiKey = "";
        private static string history = "using microsoft graph contacts api example";

        private HttpClient httpClient;

        public ChatGptClient(HttpClient httpClient) 
        {
            this.httpClient = httpClient;
        }

        public async Task<string> Create(string prompt)
        {
            try
            {
                string message = "";
                var openai = new OpenAIAPI(apiKey);
                CompletionRequest req1 = new CompletionRequest
                {
                    Model = OpenAI_API.Models.Model.DavinciText,
                    Prompt = $"http request in curl with odata query to {prompt} + {history}",
                    Temperature = 0,
                    MaxTokens = 1000,
                };

                var res = await openai.Completions.CreateCompletionAsync(req1).ConfigureAwait(false);

                foreach(var completion in res.Completions) 
                {
                    message += completion.Text;
                }
                return message;
                //CompletionResponse res1 = Completion.Create(req1);

                // Create an instance of the OpenAiClient class

                /*var request = new
                {
                    prompt = prompt + history,
                    max_tokens = 1000,
                    temperature = 0.9,
                    model = "text-davinci-003"
                };

                string requestJson = JsonConvert.SerializeObject(request);

                // Set the API key in the Authorization header
                this.httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

                // Make the API request
                var response = this.httpClient.PostAsync(endpoint, new StringContent(requestJson, Encoding.UTF8, "application/json")).Result;

                // Read the response as a string
                string responseJson = response.Content.ReadAsStringAsync().Result;

                // Deserialize the response into a dynamic object
                dynamic responseData = JsonConvert.DeserializeObject(responseJson);

                history += responseData.choices[0].text;
                // Get the text of the first choice in the response
                return responseData.choices[0].text;*/
            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
}
