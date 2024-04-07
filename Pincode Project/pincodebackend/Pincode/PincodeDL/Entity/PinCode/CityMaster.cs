using System;
using System.Collections.Generic;

namespace PincodeDL.Entity.PinCode
{
    public partial class CityMaster
    {
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public int? DistrictId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
