namespace HN.Management.Engine.ViewModels
{
    public class EmailOptions
    {
        public const string EmailSettings = "EmailSettings";
        public string From { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public string AdminEmail { get; set; }
        public string CredentialPassword { get; set; }
        public int Timeout { get; set; }
    }
}
