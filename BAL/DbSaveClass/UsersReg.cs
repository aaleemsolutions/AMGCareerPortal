using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using DAL;



namespace BAL
{
    class UsersReg : IUsers<User>
    {
        CareerPortalEntities1 dbcontext;
        public UsersReg()
        {

            dbcontext = new CareerPortalEntities1();
        }

        public User AddUser(User user)
        {

            dbcontext.Users.Add(user);
            dbcontext.SaveChanges();

            return user;
             
        }

        public int Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User getUser(User user)
        {
            throw new NotImplementedException();
        }
        public List<User> GetAllUsers()
        {

            var dbuser = dbcontext.Users.ToList();

            return dbuser;
        }


        public User getUser(int UserId)
        {

            var dbuser = dbcontext.Users.Where(m => m.Id == UserId).FirstOrDefault();

            return dbuser;
        }

        public string IsUserExist(string Username)
        {

            var dbuser = dbcontext.Users.Where(m => m.UserEmail == Username).Select(m=>m.UserEmail).FirstOrDefault();

            return dbuser;
        }
        public bool UpdatePassword(User user)
        {

            throw new NotImplementedException();
 
         
        }

        public User UpdateUser(User userUpd)
        {
            try
            {
                User userupd = userUpd;
                dbcontext.Entry(userUpd).State = System.Data.Entity.EntityState.Modified;
                dbcontext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }


            return userUpd;
           
        }

        public User getUser(string emailAddress)
        {

            var dbuser = dbcontext.Users.Where(m => m.UserEmail == emailAddress).FirstOrDefault();

            return dbuser;

            
        }

       public  User getUserWithToken(string emailAddress, string Token)
        {

            var dbuser = dbcontext.Users.Where(m => m.UserEmail == emailAddress && m.EmailTokens == Token).FirstOrDefault();

            return dbuser;

            
        }

        public bool UpdateEmailTokenn(string EmailToken, string UserEmail)
        {
            throw new NotImplementedException();
        }

       internal User ValidateUserwithPassword(string username, string password)
        {
            var dbuser = dbcontext.Users.Where(m => m.UserEmail == username && m.UserPassword == password).FirstOrDefault();

            return dbuser;
        }

        User IUsers<User>.ValidateUserwithPassword(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
