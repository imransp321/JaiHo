using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostgreSQL.ModelsGenerated;
using PostgreSQL.Utility;

namespace PostgreSQL.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class LoginController : ControllerBase
    {        
        PotgreContext userDetailsDBContext = new PotgreContext();
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [Route("Login")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("Login")]
        [HttpPost]
        public HttpResponseMessage UserLogin(string email, string password)
        {
            _logger.LogInformation("LoginController.UserLogin method called!");
            var usrDetails = userDetailsDBContext.Userdetails.Where(x => x.Email.Equals(email) &&
                      x.Password.Equals(password) &&
                      x.Isactive == true).FirstOrDefault();

            if (usrDetails == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            else
                return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Route("Register")]
        [HttpPost]
        public HttpResponseMessage RegisterUser(string email, string name, string phone, string city, string state, string country, string password, string confirmpassword)
        {
            _logger.LogInformation("LoginController.RegisterUser method called!");
            try
            {
                Userdetails regUser = new Userdetails();

                if (regUser.Id == 0)
                {
                    regUser.Email = email;
                    regUser.Name = name;
                    regUser.Phone = phone;
                    regUser.City = city;
                    regUser.State = state;
                    regUser.Country = country;
                    regUser.Password = password;
                    regUser.Confirmpassword = confirmpassword;
                    regUser.Isactive = true;
                    userDetailsDBContext.Userdetails.Add(regUser);
                    userDetailsDBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Route("ChangePassword")]
        [HttpPost]
        public HttpResponseMessage ChangePassword(string email, string oldpassword, string newpassword)
        {
            _logger.LogInformation("LoginController.ChangePassword method called!");
            var userDetails = userDetailsDBContext.Userdetails.Where(x => x.Email.Equals(email) &&
                      x.Password.Equals(oldpassword) &&
                      x.Isactive == true).FirstOrDefault();

            if (userDetails == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            else
            {
                userDetails.Password = newpassword;
                userDetails.Confirmpassword = newpassword;
                userDetailsDBContext.SaveChanges();
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Route("ForgotPassword")]
        [HttpPost]
        public HttpResponseMessage ForgotPassword(string email)
        {
            _logger.LogInformation("LoginController.ForgotPassword method called!");
            var userDetails = userDetailsDBContext.Userdetails.Where(x => x.Email.Equals(email) &&
                      x.Isactive == true).FirstOrDefault();

            if (userDetails == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            else
            {
                try
                {
                    //Send Email with Reset-Password Link
                    SendMail.Email(email);
                }
                catch (Exception ex)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
        }

    }
}
