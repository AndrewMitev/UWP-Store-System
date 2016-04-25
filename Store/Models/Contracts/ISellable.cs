using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models.Contracts
{
    public interface ISellable
    {
        string Name { get; set; }

        decimal Price { get; set; }
    }
}
