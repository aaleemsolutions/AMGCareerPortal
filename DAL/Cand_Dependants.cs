//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cand_Dependants
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Dependantname { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string CNIC { get; set; }
    
        public virtual User User { get; set; }
    }
}
