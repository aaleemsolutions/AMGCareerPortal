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
        [Required]
        public string FathersName { get; set; }
        [Required]
        public string CNIC { get; set; }
        [Required]
        public string CandidateAddress { get; set; }

        public candidate CandidateInfo{ get; set; }


        public User UsersInfo { get; set; }


        public CndQualificationViewModel CndQualificationViewModel { get; set; }

        public CndExperienceViewModel CndExperienceViewModel { get; set; }





    }
}

