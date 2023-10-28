using HN.Management.Engine.ViewModels.Helpers;
using System;

namespace HN.Management.Engine.ViewModels.Donations
{
    public class SearchDonationRequest : SearchBase
    {
        public string Name { get; set; }
        public DateTimeOffset DateDonated { get; set; }
    }
}
