using API.Models;
using API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        //private readonly IGetData _data;

        //public HomeController(IGetData data)
        //{
        //    _data = data;
        //}

        public List<List<string>> list1 = new List<List<string>>();
        public List<List<string>> list2 = new List<List<string>>();

        Service service = new Service();
       
        
        [HttpPost]
        [Route("kqkd")]
        public async Task<List<List<string>>> GetGKQKD([FromBody]Model input)
        {
            string tencongty = "";
            foreach (var item in service.lisst)
            {
                if (input.name.ToUpper() == item[0])
                {
                    tencongty = service.ChangeTen(item[1]);
                }
            }
            list1 = await service.GetDateKQKD(input.name, tencongty, input.year);
            return list1;
        }
        [HttpPost]
        [Route("cdkt")]
        public async Task<List<List<string>>> GetCDKT([FromBody] Model input)
        {
            string tencongty = "";
            foreach (var item in service.lisst)
            {
                if (input.name.ToUpper() == item[0])
                {
                    tencongty = service.ChangeTen(item[1]);
                }
            }

            return await service.GetDateCDKT(input.name, tencongty, input.year);
        }

        [HttpPost]
        [Route("lctt")]
        public async Task<List<List<string>>> GetLCTT([FromBody] Model input)
        {
            string tencongty = "";
            foreach (var item in service.lisst)
            {
                if (input.name.ToUpper() == item[0])
                {
                    tencongty = service.ChangeTen(item[1]);
                }
            }

            return await service.GetDateLCTT(input.name, tencongty, input.year);
        }

        [HttpPost]
        [Route("kqkd-quy")]
        public async Task<List<List<string>>> GetGKQKD_QUY([FromBody] Quy input)
        {
            string tencongty = "";
            foreach (var item in service.lisst)
            {
                if (input.name.ToUpper() == item[0])
                {
                    tencongty = service.ChangeTen(item[1]);
                }
            }
            list1 = await service.GetDateKQKD_Quy(input.name, tencongty,input.quy, input.year);
            return list1;
        }
        [HttpPost]
        [Route("cdkt-quy")]
        public async Task<List<List<string>>> GetCDKT_QUY([FromBody] Quy input)
        {
            string tencongty = "";
            foreach (var item in service.lisst)
            {
                if (input.name.ToUpper() == item[0])
                {
                    tencongty = service.ChangeTen(item[1]);
                }
            }

            return await service.GetDateCDKT_Quy(input.name, tencongty,input.quy, input.year);
        }

        [HttpPost]
        [Route("lctt-quy")]
        public async Task<List<List<string>>> GetLCTT_QUY([FromBody] Quy input)
        {
            string tencongty = "";
            foreach (var item in service.lisst)
            {
                if (input.name.ToUpper() == item[0])
                {
                    tencongty = service.ChangeTen(item[1]);
                }
            }

            return await service.GetDateLCTT_Quy(input.name, tencongty,input.quy, input.year);
        }


        [HttpGet]
        public string GetTenCongty(string mact)
        {
            foreach (var item in service.lisst)
            {
                if(mact == item[0])
                {
                    return item[1].ToString();
                }
              
            }
            return "";
        }


    }
}
