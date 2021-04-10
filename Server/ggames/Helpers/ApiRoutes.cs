using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ggames.Helpers
{
    public class ApiRoutes
    {
        public const string Root = "api";

        


        public static class Users
        {
            public const string GetAll = Root + "/users";
            public const string GetById = Root + "/users/{Id}";
            public const string AddAdmin = Root + "/users/";
            public const string Delete = Root + "/users/{Id}";
        }

        public static class Auth
        {
            public const string Login = Root + "/auth/login";

            public const string Register = Root + "/auth/register";
        }
    }
}
