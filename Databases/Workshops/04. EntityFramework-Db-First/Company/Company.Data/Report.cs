//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Company.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Report
    {
        public int ReportId { get; set; }
        public System.DateTime ArriveTime { get; set; }
        public int EmployeeId { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
