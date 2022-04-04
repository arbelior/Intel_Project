using Microsoft.OData.Edm;
using System;

namespace IntelPro
{
    public partial class Contacts_Online
    {
        public int Id { get; set; }

        public string? UserOnline  { get; set; }

        public string? Type { get; set; }

        public DateTime? date { get; set; }

    }
}