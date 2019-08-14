using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{

    public class ModelResult
    {
        public bool IsValid
        {
            get;
            set;
        }
    }

    public class ModelResult<T> : ModelResult
    {
        public T Item
        {
            get;  set;
        }
    }


 
}
