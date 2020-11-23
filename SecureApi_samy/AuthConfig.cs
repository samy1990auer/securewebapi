using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SecureApi_samy
{
    public class AuthConfig
    {
        public string Instance { get; set; } 
        public string Tenant { get; set; }
        public string ClientId { get; set; }
        public string Authority
        {
            get
            {
                return String.Format(CultureInfo.InvariantCulture, Instance, Tenant);
            }
        }
        public string ClientSecret { get; set; }
        public string BaseAddress { get; set; }
        public string ResourceID { get; set; }

        public static AuthConfig ReadJsonFromFile(string path)
        {
            IConfiguration Configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path);

            Configuration = builder.Build();
            return Configuration.Get<AuthConfig>();
        }
    }
}
