using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecord.Service
{
   public class Result: IResult
    {
        public Guid ID { get; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public Result()
            : this(false)
        {
        }

        public Result(bool success)
        {
            ID = Guid.NewGuid();
            Success = success;
            
        }
    }
}
