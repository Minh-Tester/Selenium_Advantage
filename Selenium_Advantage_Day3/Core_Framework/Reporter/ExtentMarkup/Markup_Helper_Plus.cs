using AventStack.ExtentReports.MarkupUtils;
using Core_Framework.API_Core;

namespace Core_Framework.Reporter.ExtentMarkup
{
    public class Markup_Helper_Plus
    {
        public static IMarkup CreateAPIRequestLog(API_Request request, API_Response response)
        {
            return new API_Request_Log(request, response);
        }
    }
}
