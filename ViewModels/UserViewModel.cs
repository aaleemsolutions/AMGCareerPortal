using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ViewModels
{
   public class UserViewModel 
    {

        public User userinfo { get; set; } = null;
        
        public int Id { get; set; }
    

        [Required]
        [StringLength(100, ErrorMessage = "Password  must have at least \"{2}\" character ", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; } = "Test@123++";

        [Required]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("UsernameExists", "Account", HttpMethod = "POST", ErrorMessage = "Email Address already registered.")]

        public string UserEmail { get; set; }
        public string UserPhoneNo { get; set; }
        public string UserImage { get; set; }
        public Nullable<bool> IsEmailVerify { get; set; }
        public Nullable<bool> isNewPassword { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<bool> isCandidate { get; set; }
        [Required]
        public string FullName { get; set; }

        [NotMapped] // Does not effect with your database
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("UserPassword")]
        public string ConfirmPassword { get; set; } = "Test@123++";

        ///[Required (ErrorMessage = "CV Uploading is required")]
        
        public HttpPostedFileBase CVUpload { get; set; }
        public Nullable<System.DateTime> CVUpdatedOn { get; set; }
        public string CVUploadPath { get; set; }

        public string EmailTokens { get; set; }

    }

    public class UserloginViewModel
    {
        [Required]
        public string Emailaddress { get; set; } 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Remembme { get; set; } = false;
    }

}
