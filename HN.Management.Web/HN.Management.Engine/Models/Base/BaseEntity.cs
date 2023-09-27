using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace HN.Management.Engine.Models.Base
{ 
        public abstract class BaseEntity
        {
            [JsonProperty(PropertyName = "id")]
            public virtual string Id { get; set; }
        }

}

