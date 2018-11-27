using CSApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSApi.Controllers
{
    public class UserController : BaseController
    {
        [Route("api/user/login")]
        public User Login([FromBody]string username,string password) => Service.User.FirstOrDefault(x => x.Username == username && x.Password == password);

        public User Register([FromBody]User user)
        {
            if (Service.User.FirstOrDefault(x => x.Username == user.Username || x.Email == user.Email) == null)
            {
                user.Balance = 100;
                return Service.User.Insert(user);
            }
            else
                return null;
        } 

        [Route("api/user/getlist")]
        public List<User> GetList() => Service.User.GetAll();

        [Route("api/user/getlistorderbalance")]
        public List<User> GetListOrderBalance() => Service.User.GetAll().OrderBy(x => x.Balance).ToList();
    }
}
