using System;
using System.Collections.Generic;

namespace PincodeDL.Entity.PinCode
{
    public partial class DistrictMaster
    {
        public int DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public int? StateId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
