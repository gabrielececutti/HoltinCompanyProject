using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DiscuntPoliticies
{
    public class BaseDiscount : IDiscunt
    {
        public decimal GetDiscount()
        {
            return 0;
        }
    }
}
