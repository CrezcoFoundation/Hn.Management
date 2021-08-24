using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Web.Middlewares
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public double ExpireTime { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
    }
}
