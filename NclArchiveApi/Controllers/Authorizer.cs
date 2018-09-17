using System;
using System.Web.Configuration;

namespace NclArchiveApi.Controllers
{
    internal class Authorizer
    {
        private readonly string _password = WebConfigurationManager.AppSettings["ApiPassword"];
        private readonly bool _authorized;
        private readonly string _message = "This API is password protected.  " + 
                                           "Put the password in the Basic Auth of the HTTP request (username can be any value).";

        internal Authorizer(string userNamePasswordString)
        {
            string username = userNamePasswordString.Split(':')[0];
            string password = userNamePasswordString.Split(':')[1];

            if (password == _password)
                _authorized = true;
        }

        internal bool Authorized
        {
            get { return _authorized; }
        }

        internal string RejectionMessage
        {
            get { return _message; }
        }
    }
}