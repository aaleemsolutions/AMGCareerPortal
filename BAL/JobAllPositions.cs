using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using BAL.Interfaces;
using BAL.CandidateDbSaveClass;
using DAL;

namespace BAL
{
    public class JobAllPositions : IJobPositions<JobPositionViewModels>
    {
        JobPositionsDbClass dbsaveJob;

        public JobAllPositions()
        {
            dbsaveJob = new JobPositionsDbClass();
        }
        public bool AddPositions(JobPositionViewModels JPosition)
        {
            AllPosition JobPos = new AllPosition() { 
            JobTitle = JPosition.JobTitle,
            CreatedBy = JPosition.CreatedBy,
            CreatedOn = JPosition.CreatedOn,
            EmployementType = JPosition.EmployementType,
            GenderSpecification = JPosition.GenderSpecification,
            IsPositionOpen = JPosition.IsPositionOpen,
            JobDescription = JPosition.JobDescription,
            JobLocation = JPosition.JobLocation,
            JobTotalViews = JPosition.JobTotalViews,
            LastDateOfJob = JPosition.LastDateOfJob,
            MinExperinceYear = JPosition.MinExperinceYear,
            NoOfVacancy = JPosition.NoOfVacancy,
            PostedDate = JPosition.PostedDate,
            SalaryRange = JPosition.SalaryRange,
            CategoryId = JPosition.CategoryId,
            CategoryName = JPosition.CategoryName,
            DepartmentId = JPosition.DepartmentId,
            DepartmentName = JPosition.DepartmentName,
            DesignationId = JPosition.DesignationId,
            DesignationName = JPosition.DesignationName,
            DivisionId = JPosition.DivisionId,
            DivisionName = JPosition.DivisionName,
            BranchId = JPosition.BranchId,
            BranchName = JPosition.BranchName

            };
        
             dbsaveJob.AddPositions(JobPos);

            return true;
            
        }

        public bool DeletePosition(JobPositionViewModels JPosition)
        {
            AllPosition JobPos = new AllPosition()
            {
                JobTitle = JPosition.JobTitle,
                CreatedBy = JPosition.CreatedBy,
                CreatedOn = JPosition.CreatedOn,
                EmployementType = JPosition.EmployementType,
                GenderSpecification = JPosition.GenderSpecification,
                IsPositionOpen = JPosition.IsPositionOpen,
                JobDescription = JPosition.JobDescription,
                JobLocation = JPosition.JobLocation,
                JobTotalViews = JPosition.JobTotalViews,
                LastDateOfJob = JPosition.LastDateOfJob,
                MinExperinceYear = JPosition.MinExperinceYear,
                NoOfVacancy = JPosition.NoOfVacancy,
                PostedDate = JPosition.PostedDate,
                SalaryRange = JPosition.SalaryRange,
                JobId = JPosition.JobId
               
            };

            dbsaveJob.DeletePosition(JobPos);
            return true;
        }

        public bool DeletePosition(int JobId)
        {
           

            dbsaveJob.DeletePosition(JobId);
            return true;
        }

        public List<JobPositionViewModels> GetAllPositions()
        {
            List<JobPositionViewModels> JobList = new List<JobPositionViewModels>();
            var Alljobs = dbsaveJob.GetAllPositions();
            JobList.Select(m=>m.ListAlljobs =  Alljobs);

            return JobList;
        }
        public JobPositionViewModels GetAllPositionsInViewModel()
        {
            PositionListViewModel positionList = new PositionListViewModel();


            JobPositionViewModels JobList = new JobPositionViewModels();
            var Alljobs = dbsaveJob.GetAllPositions();
            
            JobList.ListAlljobs = Alljobs;

            return JobList;
        }

        public JobPositionViewModels GetAllPositionsInModel()
        {
            PositionListViewModel positionList = new PositionListViewModel();


            JobPositionViewModels JobList = new JobPositionViewModels();
            var Alljobs = dbsaveJob.GetAllPositions(false);

            JobList.ListAlljobs = Alljobs;

            return JobList;
        }

        public JobPositionViewModels GetPosition(int PositionId)
        {

            var Jb = dbsaveJob.GetPosition(PositionId);
            JobPositionViewModels JobPos = new JobPositionViewModels()
            {
                JobTitle = Jb.JobTitle,
                CreatedBy = Jb.CreatedBy,
                CreatedOn = Jb.CreatedOn,
                EmployementType = Jb.EmployementType,
                GenderSpecification = Jb.GenderSpecification,
                IsPositionOpen = Jb.IsPositionOpen,
                JobDescription = Jb.JobDescription,
                JobLocation = Jb.JobLocation,
                JobTotalViews = Jb.JobTotalViews,
                LastDateOfJob = Jb.LastDateOfJob,
                MinExperinceYear = Jb.MinExperinceYear,
                NoOfVacancy = Jb.NoOfVacancy,
                PostedDate = Jb.PostedDate,
                SalaryRange = Jb.SalaryRange,
                JobId = Jb.JobId,
                CategoryId = Jb.CategoryId,
                CategoryName = Jb.CategoryName,
                DepartmentId = Jb.DepartmentId,
                DepartmentName = Jb.DepartmentName,
                DesignationId = Jb.DesignationId,
                DesignationName = Jb.DesignationName,
                DivisionId = Jb.DivisionId.HasValue == true ? Jb.DivisionId.Value:0,
                DivisionName = Jb.DivisionName,
                CandidateJobApplies = Jb.CandidateJobApplies,
                BranchId = Jb.BranchId,
                BranchName = Jb.BranchName

            };


            return JobPos;
        }

        public bool UpdatePosition(JobPositionViewModels JPosition)
        {
            AllPosition JobPos = new AllPosition()
            {
                
                JobTitle = JPosition.JobTitle,
                CreatedBy = JPosition.CreatedBy,
                CreatedOn = JPosition.CreatedOn,
                EmployementType = JPosition.EmployementType,
                GenderSpecification = JPosition.GenderSpecification,
                IsPositionOpen = JPosition.IsPositionOpen,
                JobDescription = JPosition.JobDescription,
                JobLocation = JPosition.JobLocation,
                JobTotalViews = JPosition.JobTotalViews,
                LastDateOfJob = JPosition.LastDateOfJob,
                MinExperinceYear = JPosition.MinExperinceYear,
                NoOfVacancy = JPosition.NoOfVacancy,
                PostedDate = JPosition.PostedDate,
                SalaryRange = JPosition.SalaryRange,
                JobId = JPosition.JobId,
                CategoryId = JPosition.CategoryId,
                CategoryName = JPosition.CategoryName,
                DepartmentId = JPosition.DepartmentId,
                DepartmentName = JPosition.DepartmentName,
                DesignationId = JPosition.DesignationId,
                DesignationName = JPosition.DesignationName,
                DivisionId = JPosition.DivisionId,
                DivisionName = JPosition.DivisionName,
                BranchId = JPosition.BranchId,
                BranchName = JPosition.BranchName

            };

            dbsaveJob.UpdatePosition(JobPos);
            return true;
        }
    }
}
