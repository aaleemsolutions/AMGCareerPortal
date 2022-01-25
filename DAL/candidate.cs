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
    
    public partial class candidate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public candidate()
        {
            this.CandidateQualifications = new HashSet<CandidateQualification>();
            this.CandidateExperinces = new HashSet<CandidateExperince>();
        }
    
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string CandidateName { get; set; }
        public string CandidateDescription { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public string CNIC { get; set; }
        public string CandidateAddress { get; set; }
        public string FatherName { get; set; }
        public string MaritalStatus { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string ContactNo { get; set; }
        public string ContactNoOffice { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public string PresentAddress { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidateQualification> CandidateQualifications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidateExperince> CandidateExperinces { get; set; }
    }
}
