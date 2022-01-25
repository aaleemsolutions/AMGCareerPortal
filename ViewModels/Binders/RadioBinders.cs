using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BAL.Binders
{
    public class RadioBinders : IPropertyBinder
    { 
        readonly HttpContextBase _httpContext;

        public RadioBinders(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public object BindModel(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext,
            MemberDescriptor memberDescriptor)
        {
            //var timeString = _httpContext.Request.Form[memberDescriptor.Name].ToLower();
            var timeString = _httpContext.Request.Form["Englishradio0"].ToLower();
            var timeParts = timeString.Replace("am", "").Replace("pm", "").Trim().Split(':');
            return
                new TimeSpan(
                    int.Parse(timeParts[0]) + (timeString.Contains("pm") ? 12 : 0),
                    int.Parse(timeParts[1]),
                    0);
        }
    }
   
}
