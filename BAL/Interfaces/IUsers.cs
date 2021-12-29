namespace BAL.Interfaces
{
    interface IUsers<T>
    {
        T getUser(T user);
        T getUser(string emailAddress);
        
        T getUserWithToken(string emailAddress,string Token);
        T AddUser(T user);
        T UpdateUser(T userUpd);
        int Delete(T user);
        bool UpdatePassword(T User);

        bool UpdateEmailTokenn(string EmailToken,string UserEmail);

        T ValidateUserwithPassword(string username,string password);
        
    }
}
