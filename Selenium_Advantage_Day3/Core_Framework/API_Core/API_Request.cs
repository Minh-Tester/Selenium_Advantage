
using System.Net;
using System.Text;
using Core_Framework.Reporter;
using Octokit.Internal;
using Core_Framework.API_Core;

namespace Core_Framework.API_Core
{
    public class API_Request
    {
        public HttpWebRequest request;
        public string url { get; set; }
        public string requestBody { get; set; }
        public string formData { get; set; }
        public string Method { get; set; }

        public API_Request SetUrl(string url)
        {
            this.url = url;
            request = (HttpWebRequest)WebRequest.Create(url);
            return this;
        }

        public API_Response Post()
        {

            throw new NotImplementedException();
        }

        public API_Request()
        {
            url = "";
            requestBody = "";
            formData = "";
        }

        public API_Request AddHeader(string key, string value)
        {
            request.Headers.Add(key, value);
            return this;
        }
        public API_Request SetRequestParameter(string key, string value)
        {
            if (url.Contains("?"))
            {
                url = url + "?" + key + "=" + value;
            }
            else
            {
                url = url + "&" + key + "=" + value;
            }
            return this;
        }

        public API_Request AddFormData(string key, string value)
        {
            if (formData.Equals("") || formData == null)
            {
                formData += key + "=" + value;
            }
            else
            {
                formData += "&" + key + "=" + value;
            }
            return this;
        }

        public API_Request SetBody(string body)
        {
            this.requestBody = body;
            return this;
        }
        public API_Response SendRequest()
        {
            if (request.Method == "GET")
            {
                requestBody = null;
            }
            else
            {
                if (requestBody != null)
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
                if (!formData.Equals("."))
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
                throw;
            }
        }
    }
}