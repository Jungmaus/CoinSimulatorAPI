using CSApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSApi.Controllers
{
    public class CoinController : BaseController
    {
        [Route("api/coin/get")]
        public Coin Get(int id) => Service.Coin.FirstOrDefault(x => x.ID == id);

        [Route("api/coin/getlist")]
        public List<Coin> GetList() => Service.Coin.GetAll();  
    }
}