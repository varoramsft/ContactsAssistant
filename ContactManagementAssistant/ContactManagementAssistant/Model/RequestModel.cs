using Newtonsoft.Json;

namespace ContactManagementAssistant.Model
{
    public class RequestModel
    {
        public IReadOnlyDictionary<string, string>? Headers { get; set; }

        public Uri? Url { get; set; }

        public string? Method { get; set; }

        public string? Content { get; set; }

    }
}
