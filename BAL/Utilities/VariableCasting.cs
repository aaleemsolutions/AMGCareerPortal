using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BAL.Utilities
{
    public static class VariableCasting
    {
        public static int ConvertToInt(object value)
        {
            int v1 = 0;
            try
            {
                v1 = Convert.ToInt32(value);
            }
            catch (Exception ex)
            {

                
            }
            

            return v1;
        }

        public static DateTime ConvertToDatetime(object value)
        {
            DateTime v1 = new DateTime(1900,1,1);
            try
            {
                v1 = Convert.ToDateTime(value);
            }
            catch (Exception ex)
            {


            }


            return v1;
        }

        public static decimal Converttodecimal(object value)
        {
            decimal v1 = 0;
            try
            {
                v1 = Convert.ToDecimal(value);
            }
            catch (Exception ex)
            {


            }


            return v1;
        }


        public static string ToAgeString(DateTime dob)
        {
            DateTime today = DateTime.Today;

            int months = today.Month - dob.Month;
            int years = today.Year - dob.Year;

            if (today.Day < dob.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (today - dob.AddMonths((years * 12) + months)).Days;

            return string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                                 years, (years == 1) ? "" : "s",
                                 months, (months == 1) ? "" : "s",
                                 days, (days == 1) ? "" : "s");
        }

        public static SelectList GradeTypes()
        {
            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select Grade" });
            _list.Insert(1, new SelectListItem() { Value = "Grade", Text = "Grade" });
            _list.Insert(2, new SelectListItem() { Value = "CGPA", Text = "CGPA" });
            _list.Insert(3, new SelectListItem() { Value = "Perecentage", Text = "Percentage" });
            return new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
        }
        public static IEnumerable<SelectListItem> GetMonthsName
        {
            get
            {
                return DateTimeFormatInfo
                       .InvariantInfo
                       .MonthNames
                       .Select((monthName, index) => new SelectListItem
                       {

                           Value = (index + 1).ToString(),
                           Text = monthName
                       });
            }
        }
        public static IEnumerable<SelectListItem> GetYearName
        {
            get
            {
                return DateTimeFormatInfo
                       .InvariantInfo
                       .MonthNames
                       .Select((monthName, index) => new SelectListItem
                       {

                           Value = (index + 1).ToString(),
                           Text = monthName
                       });
            }
        }



    }
}
