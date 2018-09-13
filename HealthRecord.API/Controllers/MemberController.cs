using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HealthRecord.Service;
using HealthRecord.Model;
using HealthRecord.Service.Factory;

namespace HealthRecord.API.Controllers
{
    [RoutePrefix("api/Member")]
    public class MemberController : ApiController
    {
        private IMemberService _memberservice;
        private INutritionService _nutritionservice;

        public MemberController()
        {
            _memberservice = GenericFactory.CreateInastance<IMemberService>(typeof(MemberService));
            _nutritionservice = GenericFactory.CreateInastance<INutritionService>(typeof(NutritionService));
        }

        [Route("Register")]
        [HttpPost]
        public IHttpActionResult Register(Human model)
        {
            
            //檢查會員是否存在
            bool isExist = _memberservice.IsExists(model.Account);
            if (isExist)
                return NotFound();

            IResult result = new Result();
            result = _memberservice.Create(model);
            if(result.Success)
                return Ok(result);
            else
                return NotFound();
        }
        [Route("Login")]
        [HttpPost]
        public IHttpActionResult Login(string Account) {

            Human model = _memberservice.GetByID(Account);
            if (model == null)
                return NotFound();
            else
                return Ok(model);

        }
        [Route("UpdateUserData")]
        [HttpPost]
        public IHttpActionResult UpdateUserData(Human model)
        {
            IResult result = new Result();
            result = _memberservice.Update(model);
            if (result.Success)
                return Ok();
            else
                return NotFound();
        }
        [Route("CalculateTdee")]
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
                return NotFound();
        }
        [Route("DeleteItem")]
        [HttpPost]
        public IHttpActionResult DeleteItem(int id)
        {
            IResult result = new Result();
            result = _nutritionservice.Delete(id);
            if (result.Success)
                return Ok();
            else
                return NotFound();
        }
        [Route("GetUserAllRecord")]
        [HttpPost]
        public IHttpActionResult GetUserAllRecord(int Id)
        {
            IEnumerable<Nutrition> all = _nutritionservice.GetAll(Id).OrderByDescending(c=>c.CreateDate);
            return Ok(all);
        }

    }
}
