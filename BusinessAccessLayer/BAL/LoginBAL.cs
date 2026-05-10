using BusinessAccessLayer.IBAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.JsonWebTokens;
using Model.Model.Login;

namespace BusinessAccessLayer.BAL
{
    public class LoginBAL : ILoginBAL
    {
        private readonly IConfiguration _configuration;
        private readonly JWTService _jWTService;

        public LoginBAL(IConfiguration configuration, JWTService jWTService)
        {
            _configuration = configuration;
            _jWTService = jWTService;
        }

        public ResLoginModel Validate(string username, string password)
        {
            bool isValid = false;
            string message = string.Empty;
            ResLoginModel resLoginModel = new ResLoginModel();
            

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                if (username == "Sahil@123" && password == "Sahil@123")
                {
                    resLoginModel.ResponseMessage = "Login successful.";
                    var token = _jWTService.GenerateToken(username);
                    resLoginModel.Token = token;
                }
                else
                {
                    isValid = false;
                    resLoginModel.ResponseMessage = "Invalid username or password.";
                }
            }
            else
            {
                isValid = false;
                resLoginModel.ResponseMessage = "Username and password cannot be empty.";
            }

            return resLoginModel;
        }
    }
}
