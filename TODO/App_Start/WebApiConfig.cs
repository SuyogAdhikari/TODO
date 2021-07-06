using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace TODO
{
    public static class WebApiConfig
    {
        public static MySqlConnection conn()
        {
            string sqlConfig = "server=localhost; port=3306; database=todo; username=root;";
            MySqlConnection conn = new MySqlConnection(sqlConfig);
            return conn;
        }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
