using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HealthRecord.Service;
using HealthRecord.Model;
using HealthRecord.Service.Factory;
using System.Web.Http.Cors;

namespace HealthRecord.API.Controllers
{
    //[RoutePrefix("Member")]
    [EnableCors(origins: "http://localhost:65519", headers: "*", methods: "*")]
    public class MemberApiController : ApiController
    {
        private IMemberService _memberservice;
        private INutritionService _nutritionservice;

        public MemberApiController()
        {
            _memberservice = GenericFactory.CreateInastance<IMemberService>(typeof(MemberService));
            _nutritionservice = GenericFactory.CreateInastance<INutritionService>(typeof(NutritionService));
        }
        //[Route("Login")]
        [HttpPost]
        public IHttpActionResult Login(string Account)
        {

            Human model = _memberservice.GetByID(Account);
            if (model == null)
                return NotFound();
            else
                return Ok(model);

        }
        //[Route("Register")]

        [HttpPost]
        public IHttpActionResult Register(Human model)
        {
            
            //檢查會員是否存在
            bool isExist = _memberservice.IsExists(model.Account);
            if (isExist)
                return BadRequest();

            IResult result = new Result();
            result = _memberservice.Create(model);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest();
        }

      
        //[Route("UpdateUserData")]
        [HttpPost]
        public IHttpActionResult UpdateUserData(Human model)
        {
            IResult result = new Result();
            result = _memberservice.Update(model);
            if (result.Success)
                return Ok();
            else
                return BadRequest();
        }
        //[Route("CalculateTdee")]
        [HttpPost]
        public IHttpActionResult CalculateTdee(Human model)
        {
            Nutrition nutrition;
            if (model.Gender == 0)
            {
                TdeeStrategy strategy = new ManTdeeStrategy();
                nutrition = strategy.Nutrituon;
            }
            else
            {
                TdeeStrategy strategy = new WomanTdeeStrategy();
                nutrition = strategy.Nutrituon;
            }
            IResult result = new Result();
            result = _nutritionservice.Create(nutrition);
            if (result.Success)
                return Ok();
            else
                return BadRequest();
        }
       //[Route("DeleteItem")]
       [HttpPost]
        public IHttpActionResult DeleteItem(int id)
        {
            IResult result = new Result();
            result = _nutritionservice.Delete(id);
            if (result.Success)
                return Ok();
            else
                return BadRequest();
        }
        //[Route("GetUserAllRecord")]
        [HttpPost]
        public IHttpActionResult GetUserAllRecord(int Id)
        {
            IEnumerable<Nutrition> all = _nutritionservice.GetAll(Id).OrderByDescending(c=>c.CreateDate);
            return Ok(all);
        }

    }
}
