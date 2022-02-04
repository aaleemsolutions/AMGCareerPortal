using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ViewModels
{
    public class CandidateViewModel
    {
        public Boolean EmailVerifyMessage { get; set; } = true;

        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FileContentType { get; set; }
        public HttpPostedFileBase UserImage { get; set; }
        public String UserDbImagebase64 { get; set; } = "";
        public Nullable<int> UserId { get; set; }
        public Nullable<int> CandidateId { get; set; }
        [Required (ErrorMessage = "Candidate Name Is Required.")]
        public string CandidateName { get; set; }
        [AllowHtml]
        public string CandidateDescription { get; set; }
        [AllowHtml]
        public string JobDutiesDescription { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Father Name Is Required.")]
        public string FathersName { get; set; }
        [Required]
        public string CNIC { get; set; }
        [Required]
        public string CandidateAddress { get; set; }
        [Required(ErrorMessage = "Marital Status Required.")]
        public string MaritalStatus { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        [Required(ErrorMessage = "DOB Is Required.")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> DOB { get; set; }
        [Required(ErrorMessage = "Nationality Is Required.")]
        public string Nationality { get; set; }
        [Required(ErrorMessage = "Religion Is Required.")]
        public string Religion { get; set; }
        [Required(ErrorMessage = "CNIC ExpiryDate Is Required.")]
        public Nullable<System.DateTime> ExpiryDate { get; set; }
      
        public string ContactNo { get; set; }
      
        public string ContactNoOffice { get; set; }
        [Required(ErrorMessage = "Mobile No Is Required.")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Email Address Is Required.")]
        public string EmailAddress { get; set; }
        public string PresentAddress { get; set; }
        [Required(ErrorMessage = "Freind Working field Is Required.")]
        public Nullable<bool> IsRelateFreindWorking { get; set; }
        [Required(ErrorMessage = "Previosult work field  Is Required.")]
        public Nullable<bool> PreviouslyWork { get; set; }

        public string HealthIssue { get; set; }
        public string PassportNo { get; set; }
        public Nullable<System.DateTime> PasExpiryDate { get; set; }
        public string DrivingLicenseNo { get; set; }
        public Nullable<System.DateTime> DrlExpiryDate { get; set; }
        public string NtnNo { get; set; }
        public string EOBI { get; set; }
        [Required(ErrorMessage = "Gender Is Required.")]
        public string Gender { get; set; }
        public string Bloodgroup { get; set; }

        public candidate CandidateInfo{ get; set; }


        public User UsersInfo { get; set; }


        public List<User> UsersList { get; set; }


        public CndQualificationViewModel CndQualificationViewModel { get; set; }

        public CndExperienceViewModel CndExperienceViewModel { get; set; }





    }
}

