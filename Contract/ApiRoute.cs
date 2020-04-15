namespace Al_Delal.Api.Contract
{
    public class ApiRoute
    {
         public static class Account
        {
            public const string Register = "api/account/register";
            public const string Login = "api/account/login"; 
            public const string VerifyPhone = "api/account/verify"; 
            public const string ResetPassword = "api/account/resetpassword";
            public const string ConfirmPasswordReset = "api/account/confirmpasswordreset";
        }
    }
}