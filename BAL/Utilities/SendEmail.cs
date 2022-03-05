using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BAL.Utilities
{
   public class SendEmail
    {
        public static string AccountOpeningEmail(string VerifyLink,string Username = "")
        {
            try
            {

                string verifyUrl = string.Format("{0}://{1}/Account/VerifyEmail?Token={2}&Email={3}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, VerifyLink, Username);
                string messageBody = "<p style='margin-top:0in;margin-right:0in;margin-bottom:8.0pt;margin-left:0in;line-height:107%;font-size:15px;font-family:'Calibri','sans - serif';'>Thank you for taking interest in Artistic Milliners.</p><p style='margin-top:0in;margin-right:0in;margin-bottom:8.0pt;margin-left:0in;line-height:107%;font-size:15px;font-family:'Calibri','sans - serif';'>To access your account, click on the big [color] button:</p><p><button><a href = '" + verifyUrl + "'>Click here to activate your account.</a></button></p>";
         
        
                return messageBody; // return HTML Table as string from this function  
            }
            catch (Exception ex)
            {
                return null;
            }



        }

        public static string CallForInterviewEmailBody(string fullname, string UnitName,string Intrdatetime,string officeaddress,string regards,string url="",bool IsJobForm = false ) {
            string messagebody = "<p style=margin-right:0;margin-left:0;font-size:15px;font-family:Calibri,sans-serif;margin-top:0;margin-bottom:8pt;line-height:107%>Hi&nbsp;<strong>"+ fullname + "</strong>,</p><p style=margin-right:0;margin-left:0;font-size:15px;font-family:Calibri,sans-serif;margin-top:0;margin-bottom:8pt;line-height:107%>As discussed, Your interview has been schedule at  <strong><span id='rtbInterviewTiming'></span></strong>, Our office address is<strong>&nbsp;" + officeaddress+ "</strong>. When you arrive, check in at the front desk. The security guard will give you a temporary elevator pass but please wear whatever you&rsquo;re most comfortable in.</p>"+(IsJobForm == true? "<div id='rtbJobAppForm'><p style='margin-right:0; margin-left:0; font-size:15px; font-family:Calibri,sans-serif; margin-top:0; margin-bottom:8pt; line-height:107%' >Kindly fill job application form at below link before interview.</p><p style='margin-right:0; margin-left:0; font - size:15px; font - family:Calibri,sans - serif; margin - top:0; margin - bottom:8pt; line - height:107 %; ' class='richtextJobButton'><a href='"+ url + "' class='btn btn-primary'>Job Application Form</a></p>" : "")+"</div><p style=margin-right:0;margin-left:0;font-size:15px;font-family:Calibri,sans-serif;margin-top:0;margin-bottom:8pt;line-height:107%>Best Regards,</p><p style=margin-right:0;margin-left:0;font-size:15px;font-family:Calibri,sans-serif;margin-top:0;margin-bottom:8pt;line-height:107%><strong>"+regards+"</strong></p>";

            return messagebody;
        }



        public static void Email(string htmlString, string subject, string TOAdress = "",string CCAddress = "", string BCCAddress = "")
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("HRIS (No Reply) <erp.alerts@artisticmilliners.com>");
                message.To.Add(new MailAddress(TOAdress));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 25;
                smtp.Host = "10.10.204.151"; 
                //smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                //smtp.Credentials = new NetworkCredential("FromMailAddress", "password");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

    }
}
