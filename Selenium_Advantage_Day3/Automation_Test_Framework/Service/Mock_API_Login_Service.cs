using Core_Framework.API_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Octokit.Internal;

namespace Automation_Test_Framework.Service
{
    public class Mock_API_Login_Service
    {
        public string userLoginPath = "/login";

        public API_Response LoginRequest(string username, string password)
        {
            API_Response response = new API_Request()
                .SetUrl("https://demoqa.com" + "/login")
                .AddHeader("Content-Type", "application/x-www-form-urlencoded")
                .AddFormData("username", username)
                .AddFormData("password", password)
                .SendRequest();
            return response;
        }
    }
}
