﻿using System;
using System.Collections.Generic;

namespace BackendDL.Entity.Student
{
    public partial class StudentDatum
    {
        public int Studentid { get; set; }
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public int? Age { get; set; }
    }
}
