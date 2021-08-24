﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN.Management.Engine.Models
{
    public class AppSetting
    {
        public string Secret { get; set; }

        public double ExpireTime { get; set; }

        public string ValidIssuer { get; set; }

        public string ValidAudience { get; set; }
    }
}
