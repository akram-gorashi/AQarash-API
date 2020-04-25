namespace Al_Delal.Api.Contract
{
    public class ApiRoutes
    {
        #region account
        public static class Account
        {
            public const string Register = "api/account/register";
            public const string Login = "api/account/login";
            public const string VerifyPhone = "api/account/verify";
            public const string ResetPassword = "api/account/resetpassword";
            public const string ConfirmPasswordReset = "api/account/confirmpasswordreset";
        }
        #endregion
        #region user
        public static class Users
        {
            public const string User = "api/user";

        }
        #endregion

        #region Vehicle
        public static class Vehicles
        {
            public const string Vehicle = "api/vehicle";
        }
            
        #endregion
    }
}