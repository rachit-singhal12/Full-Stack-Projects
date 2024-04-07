using System;
using System.Collections.Generic;

namespace PincodeDL.Entity.PinCode
{
    public partial class StateMaster
    {
        public int StateId { get; set; }
        public string? StateName { get; set; }
        public string? StateCode { get; set; }
        public int? CountryId { get; set; }
        public int? IsUnionTerritory { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
