using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthRecord.Model;
using HealthRecord.Service.Factory;

namespace HealthRecord.Service
{ 
   public class MemberService : IMemberService
{
    private IRepository<Human> _repository;

        public MemberService()
        {  //透過工廠建立實體
            _repository = GenericFactory.CreateInastance<IRepository<Human>>(typeof(GenericRepository<Human>));


        }
        //註冊資料
    public IResult Create(Human instance)
    {
            if (instance == null)
                throw new ArgumentException();
            IResult result = new Result(false);
            try
            {
                _repository.Create(instance);
                result.Success = true;

            }
            catch(Exception ex)
            {
                result.Exception = ex;
            }
            return result;
    }

    public IEnumerable<Human> GetAll(int humanId)
    {
            return _repository.GetAll();
    }

    public Human GetByID(string Account)
    {
            return _repository.Get(x => x.Account == Account);
        }

    public bool IsExists(string Account)
    {
            return _repository.GetAll().Any(x=>x.Account==Account);
    }

    public IResult Update(Human instance)
    {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this._repository.Update(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }
}
}
