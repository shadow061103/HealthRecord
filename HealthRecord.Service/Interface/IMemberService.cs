using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthRecord.Model;
namespace HealthRecord.Service
{
    interface IMemberService
    {
        IResult Create(Human instance);
        IResult Update(Human instance);

        bool IsExists(string Account);
        Human GetByID(string Account);

        IEnumerable<Human> GetAll(int humanId);
    }
}
