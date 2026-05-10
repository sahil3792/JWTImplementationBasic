using Model.Model.Login;
using System;
using System.Collections.Generic;
using System.Text;


namespace BusinessAccessLayer.IBAL
{
    public interface ILoginBAL
    {
        public ResLoginModel Validate(string username, string password);
    }
}
