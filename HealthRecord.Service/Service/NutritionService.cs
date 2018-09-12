﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthRecord.Model;
using HealthRecord.Service.Factory;

namespace HealthRecord.Service.Service
{
    public class NutritionService : INutritionService
    {
        private IRepository<Nutrition> _repository;
        public NutritionService()
        {
            _repository= GenericFactory.CreateInastance<IRepository<Nutrition>>(typeof(GenericRepository<Human>));
        }
        public IResult Create(Nutrition instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this._repository.Create(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Delete(int categoryID)
        {
            IResult result = new Result(false);

            if (!this.IsExists(categoryID))
            {
                result.Message = "找不到資料";
            }

            try
            {
                var instance = this.GetByID(categoryID);
                this._repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IEnumerable<Nutrition> GetAll()
        {
            return this._repository.GetAll();
        }

        public Nutrition GetByID(int Id)
        {
            return this._repository.Get(x => x.Id == Id);
        }

        public bool IsExists(int id)
        {
            return this._repository.GetAll().Any(x => x.Id == id);
        }

        public IResult Update(Nutrition instance)
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