using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN.Management.Engine.ViewModels
{
    public class EmailOptions
    {
        public const string EmailSettings = "EmailSettings";
        public string From { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
