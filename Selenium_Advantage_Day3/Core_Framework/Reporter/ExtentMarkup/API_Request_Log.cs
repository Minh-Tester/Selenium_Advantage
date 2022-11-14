using AventStack.ExtentReports.MarkupUtils;
using Core_Framework.API_Core;

namespace Core_Framework.Reporter.ExtentMarkup
{
    public class API_Request_Log : IMarkup
    {
        private API_Request request { get; set; }
        private API_Response response { get; set; }

        public API_Request_Log(API_Request request, API_Response response)
        {
            this.request = request;
            this.response = response;
        }

        public string GetMarkup()
        {
            string log = $@"
                <p>Request url: {request.url}</p>
                <p>Response body: {response.responseBody}</p>
                <p>Response status: {response.responseStatusCode} <p>
            ";
            return log;

        }

        /*public static void CreateAPIRequestLog(API_Request request, API_Response response)
        {
            GetTest().Info(Markup_Helper_Plus.CreateAPIRequestLog(request, response));
        }*/
    }
}
