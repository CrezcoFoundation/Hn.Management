﻿using HN.Management.Engine.CosmosDb;
using Newtonsoft.Json;
using System;

namespace HN.Management.Engine.Models.Auth
{
    public class RolePrivilege : CosmosEntity
    {
        public const string UserSchema = "RolePrivilege";
        public override string PartitionKey { get; set; } = UserSchema;

        [JsonProperty("schemaName")]
        public string SchemaName { get; set; } = UserSchema;

        public string RoleId { get; set; }

        public string PrivilegeId { get; set; }
    }
}
