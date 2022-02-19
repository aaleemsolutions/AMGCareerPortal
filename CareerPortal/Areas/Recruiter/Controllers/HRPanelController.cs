using BAL;
using BAL.Ado.Net;
using BAL.Utilities;
using DAL.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;


namespace CareerPortal.Areas.Recruiter.Controllers
{
    public class HRPanelController : Controller
    {

        AdoNetFetch AdoNet;
        HRPanelEmployee hrEmployeePanel;
        HRPanelDB InterviewPanel;
        InterviewPanelDetail InterviewPanelDetail;
        
        public HRPanelController()
        {
            AdoNet = new AdoNetFetch(CareerGlobalFields.GetConnectionString());            hrEmployeePanel = new HRPanelEmployee();
            InterviewPanel = new HRPanelDB();
            InterviewPanelDetail = new InterviewPanelDetail();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HRPerson()
        {
            BindDropdowns();
            return View();
        }
        public JsonResult GetPanelEmployee(int panelEmployeeId)
        {
            var hrPanelEmployee = hrEmployeePanel.GetByid(panelEmployeeId);

           EmployeeView EmployeeView = new EmployeeView() ;

            var getEmployee = AdoNet.GetEmployeeInView(hrPanelEmployee.EmpId.Value);
            getEmployee.CustomTbId = panelEmployeeId;

            var ShowData = new
            {
                UnitType = hrPanelEmployee.GarmentDivision == true ? "Garments" : "Denim",
                DepartmentId = getEmployee.Department_ID,
                EmployeeId = getEmployee.EmployeeID,
                Email = getEmployee.Email,
                Mobile = getEmployee.Mobile,
                HiddenPPId = hrPanelEmployee.Id
            };

            var DepartmentDrop = FillDepartmentOnUnit(ShowData.UnitType).Data;
            var EmployeeDrop = FillEmployeeOnDepartment(ShowData.DepartmentId, ShowData.UnitType).Data;




            return Json(new { data = ShowData,DepartmentDrop = DepartmentDrop, EmployeeDrop = EmployeeDrop }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeletePanelEmployee(int panelEmployeeId)
        {
            SenJsonResponse senJsonResponse = new SenJsonResponse();
            hrEmployeePanel.DeleteById(panelEmployeeId);
            senJsonResponse.message = "Person delete from panel";
            senJsonResponse.title= "Delete";
            return Json(senJsonResponse, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletePanel(int panelId)
        {
            SenJsonResponse senJsonResponse = new SenJsonResponse();



            var getLstDtl = InterviewPanelDetail.GetListByPanelId(panelId);
            foreach (var item in getLstDtl)
            {
                InterviewPanelDetail.DeleteById(item.Id);

            }
           

            InterviewPanel.DeleteById(panelId);

            senJsonResponse.message = "Panel Deleted";
            senJsonResponse.title = "Delete";
            return Json(senJsonResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddUpdatePanelEmployee(InterviewPanelViewModel interviewPanelViewModel,string UnitType,int HrPanelPersonId  = 0,bool isdelete = false)
        {
            SenJsonResponse senJsonResponse = new SenJsonResponse();
            if (interviewPanelViewModel.InterviewPerson!=null)
            {
                interviewPanelViewModel.InterviewPerson.CreatedBy = GlobalUserInfo.UserId;
                interviewPanelViewModel.InterviewPerson.CreatedDate = DateTime.Now;
                interviewPanelViewModel.InterviewPerson.GarmentDivision = UnitType.ToUpper() == "Garments".ToUpper()?true:false;
                interviewPanelViewModel.InterviewPerson.IsActive = true;


                if (interviewPanelViewModel.InterviewPerson.Id!=0)
                {

                    hrEmployeePanel.UpdateDataBool(interviewPanelViewModel.InterviewPerson);
                    senJsonResponse.message = "Person Update Successfully";
                    senJsonResponse.title = "Updated!";
                }
                else
                {
                    hrEmployeePanel.AddDatabool(interviewPanelViewModel.InterviewPerson);
                    senJsonResponse.message = "Person Added Successfully";
                    senJsonResponse.title = "Added!";
                }
                
                senJsonResponse.status = true;
            }
            

            return Json(senJsonResponse, JsonRequestBehavior.AllowGet );
        }

        public ActionResult InterviewPanels()
        {
            var PanelEmployee = hrEmployeePanel.GetList();
            List<DAL.CustomModel.EmployeeView> EmployeeViewList = new List<DAL.CustomModel.EmployeeView>();

            foreach (var item in PanelEmployee)
            {
                var getEmployee = AdoNet.GetEmployeeByEmpIdIdInView(item.EmpId.Value, item.GarmentDivision == true ? "Garments" : "Denim");
                getEmployee.CustomTbId = item.Id;
                EmployeeViewList.Add(getEmployee);
            }
            
            var BindPanelPersonDrp = new SelectList(EmployeeViewList, "CustomTbId", "EmployeenameWithCode").ToList();
            BindPanelPersonDrp.Insert(0, (new SelectListItem { Text = "Select Employee", Value = "" }));
      
            ViewBag.DrpBindPanelPerson = BindPanelPersonDrp;


            return View();
        }

        [HttpPost]
        public JsonResult InterviewPanels(InterviewPanelViewModel interviewPanelViewModel, string UnitType, string PanelPersonId = null, int PanelId = 0, bool isdelete = false)
        {
            SenJsonResponse senJsonResponse = new SenJsonResponse();
            if (interviewPanelViewModel.InterviewPanels != null)
            {
            

                if (interviewPanelViewModel.InterviewPanels.Id != 0)
                {
                    
                    interviewPanelViewModel.InterviewPanels.UpdateDatetime = DateTime.Now;
                    interviewPanelViewModel.InterviewPanels.IsActive = true;
                    InterviewPanel.UpdateDataBool(interviewPanelViewModel.InterviewPanels);
                    senJsonResponse.message = "Person Update Successfully";
                    senJsonResponse.title = "Updated!";


                    var getLstDtl = InterviewPanelDetail.GetListByPanelId(interviewPanelViewModel.InterviewPanels.Id);
                    foreach (var item in getLstDtl)
                    {
                        InterviewPanelDetail.DeleteById(item.Id);

                    }

                    List<DAL.InterviewPanelDetail> lstIntPanel = new List<DAL.InterviewPanelDetail>();
                    foreach (var item in PanelPersonId.Split(','))
                    {
                        DAL.InterviewPanelDetail interviewPanelDetail = new DAL.InterviewPanelDetail();
                        interviewPanelDetail.IntPersonId = Convert.ToInt32(item);
                        interviewPanelDetail.PanelId = interviewPanelViewModel.InterviewPanels.Id;
                        interviewPanelDetail.IsActive = true;
                        interviewPanelDetail.EmpId = hrEmployeePanel.GetByid(Convert.ToInt32(item)).EmpId;

                        lstIntPanel.Add(interviewPanelDetail);
                    }
                    InterviewPanelDetail.AddRange(lstIntPanel);

                }
                else
                {

                
                    interviewPanelViewModel.InterviewPanels.CreatedBy = GlobalUserInfo.UserId;
                    interviewPanelViewModel.InterviewPanels.CreatedDate = DateTime.Now;
                    interviewPanelViewModel.InterviewPanels.IsActive = true;
                    InterviewPanel.AddData(interviewPanelViewModel.InterviewPanels);
                    senJsonResponse.message = "Panel Added Successfully";
                    senJsonResponse.title = "Added!";
                    List<DAL.InterviewPanelDetail> lstIntPanel = new List<DAL.InterviewPanelDetail>();
                    foreach (var item in PanelPersonId.Split(','))
                    {
                        if (item!=null && item!="")
                        {
                            DAL.InterviewPanelDetail interviewPanelDetail = new DAL.InterviewPanelDetail();
                            interviewPanelDetail.IntPersonId = Convert.ToInt32(item);
                            interviewPanelDetail.PanelId = interviewPanelViewModel.InterviewPanels.Id;
                            interviewPanelDetail.IsActive = true;
                            interviewPanelDetail.EmpId = hrEmployeePanel.GetByid(Convert.ToInt32(item)).EmpId;
                            lstIntPanel.Add(interviewPanelDetail);
                        }
                       
                    }
                    InterviewPanelDetail.AddRange(lstIntPanel);
                }

                senJsonResponse.status = true;
            }


            return Json(senJsonResponse, JsonRequestBehavior.AllowGet);
        }


        public void BindDropdowns()
        {
            //var GetEmployeeView = new SelectList(AdoNet.GetAllEmployeeView(), "EmployeeID", "EmployeeName").ToList();
            //GetEmployeeView.Insert(0, (new SelectListItem { Text = "Select Employee", Value = "" }));
            //var GetEmployeeView = new  SelectList();



            var UnitType = new List<SelectListItem>
            {
               new SelectListItem { Text = "Select", Value = "0"},
                new SelectListItem { Text = "Garments", Value = "Garments"},
                new SelectListItem { Text = "Denim", Value = "Denim" }

            };
            ViewBag.UnitTypeDropDown = UnitType;

            //var GetAllDepartment = new SelectList(AdoNet.GetAllDepartment(), "Department_Id", "Department_Name").ToList();
            //GetAllDepartment.Insert(0, (new SelectListItem { Text = "Select Department", Value = "Select" }));
            var GetAllDepartment = new List<SelectListItem>
            {
               new SelectListItem { Text = "Select", Value = "0"}
            };
            ViewBag.DepartmentDropDown = GetAllDepartment;


            var GetEmployeeView = new List<SelectListItem>
            {
               new SelectListItem { Text = "Select", Value = "0"}
            };
            ViewBag.EmployeeViewDropDown = GetEmployeeView;
        }

        [HttpPost]

        public JsonResult DtgetPanelEmployees() {
            SenJsonResponse senJsonResponse = new SenJsonResponse();

            var hrPanelEmployee = hrEmployeePanel.GetList();

            List<DAL.CustomModel.EmployeeView> EmployeeViewList = new List<DAL.CustomModel.EmployeeView>();
           
            foreach (var item in hrPanelEmployee)
            {
                var getEmployee = AdoNet.GetEmployeeInView(item.EmpId.Value);
                getEmployee.CustomTbId = item.Id;
                EmployeeViewList.Add(getEmployee);
            }

            return Json(new { data = EmployeeViewList }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DtgetInterviewPanel()
        {
            var getHrPanel = InterviewPanel.GetList();

            
            List<DAL.CustomModel.EmployeeView> EmployeeViewList = new List<DAL.CustomModel.EmployeeView>();

            var CustomPanelList = new[] { new { PanelName = "", PanelId = 0, Employees = "" } }.ToList();
            CustomPanelList.Clear();

            foreach (var item in getHrPanel)
            {
             
                string Employees="";
                foreach (var itemDetail in item.InterviewPanelDetails.Select(m=>m.InterviewPerson.EmpId))
                {
                    var getEmployee = AdoNet.GetEmployeeInView(itemDetail.Value);
                    if (Employees=="")
                    {
                        Employees += getEmployee.EmployeeName.ToString();
                    }
                    else
                    {
                        Employees +="," + getEmployee.EmployeeName.ToString();
                    }
                    
                    //EmployeeViewList.Add(getEmployee);
                }

                var Custompanel = new { PanelName = item.PanelName, PanelId = item.Id, Employees = Employees };
                CustomPanelList.Add(Custompanel);
            }
           

            return Json(new { data = CustomPanelList }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getInterviewPanel(int PanelId)
        {
            var getHrPanel = InterviewPanel.GetByid(PanelId);

                List<string> EmployeeId = new List<string>();
                foreach (var itemDetail in getHrPanel.InterviewPanelDetails.Select(m => m.InterviewPerson.Id))
                {

                EmployeeId.Add(itemDetail.ToString());

                    //if (EmployeeId == "")
                    //{
                    //EmployeeId += itemDetail.ToString();
                    //}
                    //else
                    //{
                    //EmployeeId += "," + itemDetail.ToString();
                    //}

                //EmployeeViewList.Add(getEmployee);
            }

                var Custompanel = new { PanelName = getHrPanel.PanelName, PanelId = getHrPanel.Id, Employees = EmployeeId };               
            


            return Json(new { data = Custompanel }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult FillDepartmentOnUnit(string UnitType) 
        {
            var GetAllDepartment = new SelectList(AdoNet.GetAllDepartment(UnitType, CareerGlobalFields.GetConnectionString()), "Department_Id", "Department_Name").ToList();
            GetAllDepartment.Insert(0, (new SelectListItem { Text = "Select Department", Value = "Select" }));

            return Json(GetAllDepartment, JsonRequestBehavior.AllowGet);   
        }


        public JsonResult FillEmployeeOnDepartment(int DepartmentId,string UnitType)
        {
            var GetAllEmployee = new SelectList(AdoNet.GetEmployeeByDeptIdInView(DepartmentId, UnitType), "EmployeeID", "EmployeenameWithCode").ToList();
            GetAllEmployee.Insert(0, (new SelectListItem { Text = "Select Employee", Value = "" }));

            return Json(GetAllEmployee, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FillEmployeeDetailOnEmployeeDrp(int EmployeeId, string UnitType)
        {
            var EmpDetail = AdoNet.GetEmployeeByEmpIdIdInView(EmployeeId, UnitType);

            return Json(EmpDetail, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPanelEmployeeTags()
        {
            var PanelEmployee = hrEmployeePanel.GetList();
    
            List<DAL.CustomModel.EmployeeView> EmployeeViewList = new List<DAL.CustomModel.EmployeeView>();

            foreach (var item in PanelEmployee)
            {
                var getEmployee = AdoNet.GetEmployeeByEmpIdIdInView(item.EmpId.Value, item.GarmentDivision == true ? "Garments" : "Denim");
                getEmployee.CustomTbId = item.Id;
                EmployeeViewList.Add(getEmployee);
            }

            var emp = EmployeeViewList.Select(m => m.EmployeenameWithCode).ToList();

            return Json(emp, JsonRequestBehavior.AllowGet);
        }
    }
}