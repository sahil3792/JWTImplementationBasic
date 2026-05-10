namespace JWTImplementation.Model.Login
{
    public class  ReqLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ResLoginModel
    {
        public string ResponseMessage { get; set; }
        public string Token { get; set; }
        
    }
}
