using ContactManagementAssistant.Model;
using Curl.CommandLine.Parser;

namespace ContactManagementAssistant.CurlUtil
{
    class ParseCurl
    {
        public static RequestModel Parse(string curl)
        {
            try
            {
                //var output = new Converter().Parse(curl, 10);
                //var res = output.Data.;
                var output = new CurlParser(new ParsingOptions() { MaxUploadFiles = 10 }).Parse(curl);
                RequestModel requestModel = new RequestModel
                {
                    Headers = output.Data.Headers,
                    Url = output.Data.Url,
                    Method = output.Data.HttpMethod,
                    Content = output.Data.UploadData.FirstOrDefault()?.Content
                };
             
                return requestModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
