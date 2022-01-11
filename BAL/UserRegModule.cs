using BAL.Interfaces;
using BAL.PasswordCoder;
using BAL.Utilities;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public class UserRegModule: IUsers<UserViewModel>
    {
        UsersReg useradd;


        public UserRegModule()
        {
            useradd = new UsersReg();
        }

      
       
        

        public UserViewModel AddUser(UserViewModel user)
        {
            try
            {
                UserViewModel newusermodel = new UserViewModel();

                User newuser = new User
                {
                    FullName = user.FullName,
                    CreatedOn = DateTime.Now,
                    CandidateCVPath = user.CVUploadPath,
                    IsEmailVerify = false,
                    isNewPassword = false,
                    UserEmail = user.UserEmail,

                    UserPassword = SecurePasswordEncryption.Hash(user.UserPassword),
                    UserPhoneNo = user.UserPhoneNo,
                   EmailTokens = SecurePasswordEncryption.GenerateEmailsToken()


                };

                newusermodel.userinfo = useradd.AddUser(newuser);
                if (user.CVUpload != null)
                {
                    string filename = "CV_" + newusermodel.userinfo.FullName.ToString().Trim() + newusermodel.userinfo.Id.ToString() + "_" + DateTime.Now.ToString("ddMMyy_hhmm") + Path.GetExtension(user.CVUpload.FileName);
                    ImageSaving.savePostedFileIntoFolder(user.CVUpload, GlobalFields.UploadDocumentsPath, filename);
                    newusermodel.userinfo.CandidateCVPath = GlobalFields.UploadDocumentsPath + filename;
                    newusermodel.userinfo.CVUpdatedOn = DateTime.Now;
                }
                
                useradd.UpdateUser(newusermodel.userinfo);

                
                SendEmail.Email(SendEmail.AccountOpeningEmail(newuser.EmailTokens,newuser.UserEmail), "Artistic Milliners - Verify Job Portal Account",user.UserEmail);
                
            
            
            }
            catch (Exception ex)
            {

                throw;
            }
           

            return user;    
        }

        public int Delete(UserViewModel user)
        {
            throw new NotImplementedException();
        }

        public UserViewModel getUser(UserViewModel user)
        {
            user.userinfo = useradd.getUser(user.UserEmail);
            throw new NotImplementedException();
        }

        public string IsUserExist(string EmailAddress)
        {
            string IsExist = useradd.IsUserExist(EmailAddress);


            return IsExist;
        }

        public bool UpdatePassword(UserViewModel User)
        {
            
            throw new NotImplementedException();
        }

        public UserViewModel UpdateUser(UserViewModel user)
        {


            useradd.UpdateUser(user.userinfo);

            return user;
        }

        public List<User> GetAllUsers() {
            return useradd.GetAllUsers();
        }
        public UserViewModel  getUser(string emailAddress)
        {
            var userViewModel = new UserViewModel();



            var dbUser = useradd.getUser(emailAddress);

            userViewModel.userinfo = dbUser;


            return userViewModel;

            
        }



        public UserViewModel getUser(int UserId)
        {
            var userViewModel = new UserViewModel();



            var dbUser = useradd.getUser(UserId);

            userViewModel.userinfo = dbUser;


            return userViewModel;


        }
        public UserViewModel  getUserWithToken(string emailAddress, string Token)
        {

            throw new NotImplementedException();
        }

       public  bool  UpdateEmailTokenn(string EmailToken, string UserEmail)
        {

            try
            {
                var user = useradd.getUserWithToken(UserEmail, EmailToken);

                if (user != null)
                {
                    user.EmailTokens = null;
                    user.IsEmailVerify = true;
                    useradd.UpdateUser(user);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
 

        public UserViewModel ValidateUser(string username,string password)
        {

            try
            {
                var user = getUser(username);
                if (user.userinfo != null)
                {
                    bool decryptpassword = SecurePasswordEncryption.Verify(password, user.userinfo.UserPassword);
                    if (decryptpassword)
                    {
                        return user;
                    }
                    else
                    {
                        user.userinfo = null;
                        return user;
                    }

                }
                else
                {
                    return user;
                }
            }
            catch (Exception  ex)
            {
                

                throw ;
            }
    

            

            

        }

     

        UserViewModel IUsers<UserViewModel>.ValidateUserwithPassword(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
