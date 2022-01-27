using BAL.CandidateDbSaveClass;
using BAL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public class CandidateLogics : ICandidate<CandidateViewModel>
    {
        CandidateGeneric candidateGeneric;
        CndQualificationGeneric cndQualification;
        UserRegModule userRegModule;
        CndExpeDbSave CndExperince;

        public CandidateLogics()
        {
            candidateGeneric = new CandidateGeneric();
            cndQualification = new CndQualificationGeneric();
            userRegModule = new UserRegModule();
            CndExperince = new CndExpeDbSave();

        }

        public CandidateViewModel AddCandidate(CandidateViewModel Candidate)
        {
            string fileContent = "";
            bool formvalidate = false;
            if (Candidate.UserImage!=null)
            {
                byte[] uploadedFile = new byte[Candidate.UserImage.InputStream.Length];
                Candidate.UserImage.InputStream.Read(uploadedFile, 0, uploadedFile.Length);
                fileContent = Convert.ToBase64String(uploadedFile);
                var userImg = userRegModule.getUser(System.Web.HttpContext.Current.Session["UserEmail"].ToString());
                userImg.userinfo.UserImage = fileContent;

                userRegModule.UpdateUser(userImg);

            }
      
            var candidateobj = new candidate
            {
                CandidateAddress = Candidate.CandidateAddress,
                CandidateName = Candidate.CandidateName,
                CandidateDescription = Candidate.CandidateDescription,
                CNIC = Candidate.CNIC,
                FathersName = Candidate.FathersName,
                FirstName = Candidate.FirstName,
                LastName = Candidate.LastName,
                UserId = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserId"].ToString()
                
                )
                
            };

            

            candidateGeneric.AddCandidate(candidateobj);


            return Candidate;
        }

        public int DeleteCandidate(CandidateViewModel Candidate)
        {
            throw new NotImplementedException();
        }

        public CandidateViewModel getCandidate(CandidateViewModel Candidate)
        {
            throw new NotImplementedException();
        }

        public CandidateViewModel GetAllUsers()
        {
            var candidateviewModel = new CandidateViewModel();

            candidateviewModel.UsersList = userRegModule.GetAllUsers();


            return candidateviewModel;
        }

        public CandidateViewModel getCandidate(int UserId)
        {
            var candidateviewModel = new CandidateViewModel();

            candidateviewModel.CandidateInfo =  candidateGeneric.getCandidate(UserId);

            candidateviewModel.UsersInfo = userRegModule.getUser(UserId).userinfo;


            if (candidateviewModel.CandidateInfo!=null)
            {
                if (candidateviewModel.CandidateInfo.FirstName != null)
                {
                    candidateviewModel.FirstName = candidateviewModel.CandidateInfo.FirstName;
                }
                if (candidateviewModel.CandidateInfo.LastName!=null)
                {
                    candidateviewModel.LastName = candidateviewModel.CandidateInfo.LastName;
                }

                if (candidateviewModel.CandidateInfo.FathersName!=null)
                {
                    candidateviewModel.FathersName = candidateviewModel.CandidateInfo.FathersName;
                }

                if (candidateviewModel.CandidateInfo.CandidateAddress !=null)
                {
                    candidateviewModel.CandidateAddress = candidateviewModel.CandidateInfo.CandidateAddress;
                }

                if (candidateviewModel.CandidateInfo.CNIC!=null)
                {
                    candidateviewModel.CNIC = candidateviewModel.CandidateInfo.CNIC;
                }

                if (candidateviewModel.CandidateInfo.User.IsEmailVerify!=null)
                {
                    candidateviewModel.EmailVerifyMessage = candidateviewModel.CandidateInfo.User.IsEmailVerify.Value;
                }

                if (candidateviewModel.CandidateInfo.CandidateDescription !=null)
                {
                    candidateviewModel.CandidateDescription = candidateviewModel.CandidateInfo.CandidateDescription;
                }

                if (candidateviewModel.CandidateInfo.MaritalStatus != null)
                {
                    candidateviewModel.MaritalStatus = candidateviewModel.CandidateInfo.MaritalStatus;
                }

                if (candidateviewModel.CandidateInfo.Religion != null)
                {
                    candidateviewModel.Religion = candidateviewModel.CandidateInfo.Religion;
                }

                if (candidateviewModel.CandidateInfo.Id != 0)
                {
                    candidateviewModel.CandidateId = candidateviewModel.CandidateInfo.Id;
                }

                if (candidateviewModel.CandidateInfo.CandidateName != null)
                {
                    candidateviewModel.CandidateName = candidateviewModel.CandidateInfo.CandidateName;
                }

                if (candidateviewModel.CandidateInfo.DOB != null)
                {
                    candidateviewModel.DOB = candidateviewModel.CandidateInfo.DOB;
                }

                if (candidateviewModel.CandidateInfo.Nationality != null)
                {
                    candidateviewModel.Nationality = candidateviewModel.CandidateInfo.Nationality;
                }

                if (candidateviewModel.CandidateInfo.ExpiryDate != null)
                {
                    candidateviewModel.ExpiryDate = candidateviewModel.CandidateInfo.ExpiryDate;
                }

                if (candidateviewModel.CandidateInfo.ContactNo != null)
                {
                    candidateviewModel.ContactNo = candidateviewModel.CandidateInfo.ContactNo;
                }

                if (candidateviewModel.CandidateInfo.ContactNoOffice != null)
                {
                    candidateviewModel.ContactNoOffice = candidateviewModel.CandidateInfo.ContactNoOffice;
                }

                if (candidateviewModel.CandidateInfo.MobileNo != null)
                {
                    candidateviewModel.MobileNo = candidateviewModel.CandidateInfo.MobileNo;
                }

                if (candidateviewModel.CandidateInfo.EmailAddress != null)
                {
                    candidateviewModel.EmailAddress = candidateviewModel.CandidateInfo.EmailAddress;
                }

                if (candidateviewModel.CandidateInfo.PresentAddress != null)
                {
                    candidateviewModel.PresentAddress = candidateviewModel.CandidateInfo.PresentAddress;
                }
                if (candidateviewModel.CndQualificationViewModel==null)
                {
                    candidateviewModel.CndQualificationViewModel = new CndQualificationViewModel();
                }
                


                //                candidateviewModel.CandidateName = candidateviewModel.CandidateInfo.CandidateName==null || candidateviewModel.CandidateInfo.CandidateName == ""?candidateviewModel.CandidateInfo.FirstName +" " + candidateviewModel.CandidateInfo.LastName : candidateviewModel.CandidateInfo.CandidateName;








                
                

                
                
                
                
                
                
                







            }





            return candidateviewModel;
        }

    
        public int getCandidateId(int UserId)
        {
        

            var candidateId = candidateGeneric.getCandidate(UserId).Id;

 

            return candidateId;
        }

        public CandidateViewModel UpdateCandidate(CandidateViewModel CandidateUpd)
        {
            string fileContent = "";
            bool formvalidate = false;
            if (CandidateUpd.UserImage != null)
            {
                byte[] uploadedFile = new byte[CandidateUpd.UserImage.InputStream.Length];
                CandidateUpd.UserImage.InputStream.Read(uploadedFile, 0, uploadedFile.Length);
                fileContent = Convert.ToBase64String(uploadedFile);
                //CandidateUpd.CandidateInfo.User.UserImage = fileContent;
                var userImg = userRegModule.getUser(System.Web.HttpContext.Current.Session["UserEmail"].ToString());
                userImg.userinfo.UserImage = fileContent;

                userRegModule.UpdateUser(userImg);

            }
            var userId = System.Web.HttpContext.Current.Session["UserId"].ToString();


            var prevobj = new candidate();
            prevobj = candidateGeneric.getCandidate(Convert.ToInt32(userId));

            var candidateobj = new candidate();

            candidateobj.Id = CandidateUpd.CandidateInfo.Id;




            if (CandidateUpd.CandidateAddress!=null)
            {
                candidateobj.CandidateAddress = CandidateUpd.CandidateAddress;
            }
            else
            {
                candidateobj.CandidateAddress = prevobj.CandidateAddress;
            }

            if (CandidateUpd.CandidateName != null)
            {
                candidateobj.CandidateName = CandidateUpd.CandidateName;
            }
            else
            {
                candidateobj.CandidateName = prevobj.CandidateName;

            }

            if (CandidateUpd.CandidateDescription != null)
            {
                candidateobj.CandidateDescription = CandidateUpd.CandidateDescription;
            }
            else
            {
                candidateobj.CandidateDescription = prevobj.CandidateDescription;

            }
            if (CandidateUpd.CNIC != null)
            {
                candidateobj.CNIC = CandidateUpd.CNIC;
            }
            else
            {
                candidateobj.CNIC = prevobj.CNIC;

            }
            if (CandidateUpd.FathersName != null)
            {
                candidateobj.FathersName = CandidateUpd.FathersName;
            }
            else
            {
                candidateobj.FathersName = prevobj.FathersName;
            }
            if (CandidateUpd.FirstName != null)
            {
                candidateobj.FirstName = CandidateUpd.FirstName;
            }
            else
            {
                candidateobj.FirstName = prevobj.FirstName;

            }
            if (CandidateUpd.LastName != null)
            {
                candidateobj.LastName = CandidateUpd.LastName;
            }
            else
            {
                candidateobj.LastName = prevobj.LastName;

            }
            if (CandidateUpd.ContactNo != null)
            {
                candidateobj.ContactNo = CandidateUpd.ContactNo;
            }
            else
            {
                candidateobj.ContactNo = prevobj.ContactNo;

            }
            if (CandidateUpd.ContactNoOffice != null)
            {
                candidateobj.ContactNoOffice = CandidateUpd.ContactNoOffice;
            }
            else
            {
                candidateobj.ContactNoOffice = prevobj.ContactNoOffice;
            }
            if (CandidateUpd.DOB != null)
            {
                candidateobj.DOB = CandidateUpd.DOB;
            }
            else
            {
                candidateobj.DOB = prevobj.DOB;
            }
            if (CandidateUpd.EmailAddress != null)
            {
                candidateobj.EmailAddress = CandidateUpd.EmailAddress;
            }
            else
            {
                candidateobj.EmailAddress = prevobj.EmailAddress;

            }
            if (CandidateUpd.MaritalStatus != null)
            {
                candidateobj.MaritalStatus = CandidateUpd.MaritalStatus;
            }
            else
            {
                candidateobj.MaritalStatus = prevobj.MaritalStatus;
            }
            if (CandidateUpd.Nationality != null)
            {
                candidateobj.Nationality = CandidateUpd.Nationality;
            }
            else
            {
                candidateobj.Nationality = prevobj.Nationality;

            }
            if (CandidateUpd.PresentAddress != null)
            {
                candidateobj.PresentAddress = CandidateUpd.PresentAddress;
            }
            else
            {
                candidateobj.PresentAddress = prevobj.PresentAddress;
            }
            if (CandidateUpd.ExpiryDate != null)
            {
                candidateobj.ExpiryDate = CandidateUpd.ExpiryDate;
            }
            else
            {
                candidateobj.ExpiryDate = prevobj.ExpiryDate;
            }
            if (CandidateUpd.Religion != null)
            {
                candidateobj.Religion = CandidateUpd.Religion;
            }
            else
            {
                candidateobj.Religion = prevobj.Religion;
            }
            if (CandidateUpd.FathersName != null)
            {
                candidateobj.FatherName = CandidateUpd.FathersName;
            }
            else
            {
                candidateobj.FatherName = prevobj.FatherName;
            }
            if (CandidateUpd.MobileNo != null)
            {
                candidateobj.MobileNo = CandidateUpd.MobileNo;
            }
            else
            {
                candidateobj.MobileNo = prevobj.MobileNo;
            }
            candidateobj.UserId = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserId"].ToString());


            //var candidateobj = new candidate
            //{
            //    Id = CandidateUpd.CandidateInfo.Id,
            //    CandidateAddress = CandidateUpd.CandidateAddress,
            //    CandidateName = CandidateUpd.CandidateName,
            //    CandidateDescription = CandidateUpd.CandidateDescription,
            //    CNIC = CandidateUpd.CNIC,
            //    FathersName = CandidateUpd.FathersName,
            //    FirstName = CandidateUpd.FirstName,
            //    LastName = CandidateUpd.LastName,
            //    ContactNo = CandidateUpd.ContactNo,
            //    ContactNoOffice = CandidateUpd.ContactNoOffice,
            //    DOB = CandidateUpd.DOB,
            //    EmailAddress = CandidateUpd.EmailAddress,
            //    MaritalStatus = CandidateUpd.MaritalStatus,
            //    Nationality = CandidateUpd.Nationality,
            //    PresentAddress = CandidateUpd.PresentAddress,
            //    ExpiryDate = CandidateUpd.ExpiryDate,
            //    Religion = CandidateUpd.Religion,
            //    FatherName = CandidateUpd.FathersName,
            //    MobileNo = CandidateUpd.MobileNo,

            //    UserId = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserId"].ToString())

            //};

            var getcandidate = new CandidateViewModel();
            getcandidate.CandidateInfo = candidateGeneric.UpdateCandidate(candidateobj);

            return getcandidate;

            
        }



        //Candidate Qualification
       public  CandidateViewModel AddCandidateQualification(CandidateViewModel cndViewModel)
        {

            var candQualification = new CandidateQualification() {
                CandidateId = cndViewModel.CndQualificationViewModel.CandidateId,
                DegreeId = cndViewModel.CndQualificationViewModel.DegreeId,
                DegreeName = cndViewModel.CndQualificationViewModel.DegreeName,
                DgrFrmMonth = cndViewModel.CndQualificationViewModel.DgrFrmMonth,
                DgrFrmYear = cndViewModel.CndQualificationViewModel.DgrFrmYear,
                DgrToMonth = cndViewModel.CndQualificationViewModel.DgrToMonth,
                DgrToYear = cndViewModel.CndQualificationViewModel.DgrToYear,
                InstitutionName = cndViewModel.CndQualificationViewModel.InstitutionName,
                isOngoing = cndViewModel.CndQualificationViewModel.isOngoing,
                ResultType = cndViewModel.CndQualificationViewModel.ResultType,
                ResultValue = cndViewModel.CndQualificationViewModel.ResultValue,
                Specialization = cndViewModel.CndQualificationViewModel.Specialization
            
            }; 
                  
            cndQualification.AddCandidateQualification(candQualification);

            return cndViewModel;
        }

        public int DeleteCandidateQualification( int CandidateID)
        {


            cndQualification.DeleteCandidateQualification(CandidateID);

            return CandidateID;
        }

        public CandidateViewModel getCandidateQualification(int UserId)
        {
            throw new NotImplementedException();
        }

        public CandidateViewModel UpdateCandidateQualification(CandidateViewModel CandidateUpd)
        {
            var candQualification = new CandidateQualification()
            {
                id = CandidateUpd.CndQualificationViewModel.id,
                CandidateId = CandidateUpd.CndQualificationViewModel.CandidateId,
                DegreeId = CandidateUpd.CndQualificationViewModel.DegreeId,
                DegreeName = CandidateUpd.CndQualificationViewModel.DegreeName,
                DgrFrmMonth = CandidateUpd.CndQualificationViewModel.DgrFrmMonth,
                DgrFrmYear = CandidateUpd.CndQualificationViewModel.DgrFrmYear,
                DgrToMonth = CandidateUpd.CndQualificationViewModel.DgrToMonth,
                DgrToYear = CandidateUpd.CndQualificationViewModel.DgrToYear,
                InstitutionName = CandidateUpd.CndQualificationViewModel.InstitutionName,
                isOngoing = CandidateUpd.CndQualificationViewModel.isOngoing,
                ResultType = CandidateUpd.CndQualificationViewModel.ResultType,
                ResultValue = CandidateUpd.CndQualificationViewModel.ResultValue,
                Specialization = CandidateUpd.CndQualificationViewModel.Specialization

            };

            var cndqualification = cndQualification.UpdateCandidateQualification(candQualification);

            return CandidateUpd;

        }


        public CandidateQualification GetQualification(int QualificationId)
        {
            var cndqualification = candidateGeneric.GetQualification(QualificationId);

            return cndqualification;

        }



        /// END
    
 
        
        //Candidate Experince
       public CandidateViewModel AddCandidateExperince(CandidateViewModel cndViewModel)
        {

            var candidateExperince = new CandidateExperince()
            {
                CandidateId = cndViewModel.CndExperienceViewModel.CandidateId,
                CompanyName = cndViewModel.CndExperienceViewModel.CompanyName,
                CurrentSalary = cndViewModel.CndExperienceViewModel.CurrentSalary,
                DesignationName = cndViewModel.CndExperienceViewModel.DesignationName,
                FreshGraduate = cndViewModel.CndExperienceViewModel.FreshGraduate,
                FromMonth = cndViewModel.CndExperienceViewModel.FromMonth,
                FromYear = cndViewModel.CndExperienceViewModel.FromYear,
                 InitialSalary = cndViewModel.CndExperienceViewModel.InitialSalary,
                IsPresent = cndViewModel.CndExperienceViewModel.IsPresent,
                JobDuties = cndViewModel.CndExperienceViewModel.JobDuties,
                Locationname = cndViewModel.CndExperienceViewModel.Locationname,
                ReasonForLeaving = cndViewModel.CndExperienceViewModel.ReasonForLeaving,
                ToMonth = cndViewModel.CndExperienceViewModel.ToMonth,
                ToYear = cndViewModel.CndExperienceViewModel.ToYear,


            };

            CndExperince.AddCandidateExperince(candidateExperince);

            return cndViewModel;
        }

        public int DeleteCandidateExperince(int CandidateID)
        {

             
            CndExperince.DeleteCandidateExp(CandidateID);

            return CandidateID;
        }

        public CandidateExperince getCandidateExperinceById(int UserId)
        {
            var cndqualification = CndExperince.GetCandidateExperince(UserId);

            return cndqualification;
        }

        public CandidateViewModel getCandidateExperince(int UserId)
        {
            throw new NotImplementedException();
        }

        public CandidateViewModel UpdateCandidateExperince(CandidateViewModel CandidateUpd)
        {

            var candidateExperince = new CandidateExperince()
            {
                id = CandidateUpd.CndExperienceViewModel.id,
                CandidateId = CandidateUpd.CndExperienceViewModel.CandidateId,
                CompanyName = CandidateUpd.CndExperienceViewModel.CompanyName,
                CurrentSalary = CandidateUpd.CndExperienceViewModel.CurrentSalary,
                DesignationName = CandidateUpd.CndExperienceViewModel.DesignationName,
                FreshGraduate = CandidateUpd.CndExperienceViewModel.FreshGraduate,
                FromMonth = CandidateUpd.CndExperienceViewModel.FromMonth,
                FromYear = CandidateUpd.CndExperienceViewModel.FromYear,
                InitialSalary = CandidateUpd.CndExperienceViewModel.InitialSalary,
                IsPresent = CandidateUpd.CndExperienceViewModel.IsPresent,
                JobDuties = CandidateUpd.CndExperienceViewModel.JobDuties,
                Locationname = CandidateUpd.CndExperienceViewModel.Locationname,
                ReasonForLeaving = CandidateUpd.CndExperienceViewModel.ReasonForLeaving,
                ToMonth = CandidateUpd.CndExperienceViewModel.ToMonth,
                ToYear = CandidateUpd.CndExperienceViewModel.ToYear,


            };
            var cndqualification = CndExperince.UpdateCandidateExperince(candidateExperince);

            return CandidateUpd;

        }


        public IList<CandidateExperince> GetAllExperince()
        {
            var cndqualification = CndExperince.GetCandidateExperince().ToList();

            return cndqualification;

        }


    }
}
