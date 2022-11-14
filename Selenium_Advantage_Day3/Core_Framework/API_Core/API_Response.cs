using System.Net;
using System.Text;
using Core_Framework.API_Core;
using Core_Framework.Reporter;

namespace Core_Framework.API_Core
{
    public class API_Response : API_Request
    {
        public HttpWebResponse response;

        public string responseBody { get; set; }
        public string responseStatusCode { get; set; }

        public API_Response(HttpWebResponse response)
        {
            this.response = response;
            GetResponseBody();
            GetResponseStatusCode();
        }

        private string GetResponseBody()
        {
            responseBody = "";
            using (var stream = response.GetResponseStream())
            {
                if (stream != null)
                    using (var reader = new StreamReader(stream))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                return responseBody;
            }
        }

        private string GetResponseStatusCode()
        {
            try
            {
                HttpStatusCode statusCode = ((HttpWebResponse)response).StatusCode;
                responseStatusCode = statusCode.ToString();
            }
            catch (WebException we)
            {
                responseStatusCode = ((HttpWebResponse)we.Response).StatusCode.ToString();

            }
            return responseStatusCode;
        }

    }
        /*public API_Response SendRequest()
        {
            if(request.Method == "GET")
            {
                requestBody = null;
            }
            else
            {
                if(requestBody != null)
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
                    request.ContentLength = byteArray.Length;
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Flush();
                        dataStream.Close();
                    }
                }
            }
            try
            {
                IAsyncResult asyncResult = request.BeginGetResponse(null, null);
                asyncResult.AsyncWaitHandle.WaitOne();
                var httpResponse = (HttpWebResponse)request.EndGetResponse(asyncResult);
                API_Response response = new API_Response(httpResponse);
                HtmlReport.CreateAPIRequestLog(this, response);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
}
