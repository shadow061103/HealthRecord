using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthRecord.Model;
namespace HealthRecord.Service
{
   public interface INutritionService
    {
        IResult Create(Nutrition instance);

        IResult Update(Nutrition instance);

        IResult Delete(int categoryID);

        bool IsExists(int categoryID);

        Nutrition GetByID(int categoryID);

        IEnumerable<Nutrition> GetAll(int Id);
    }
}
