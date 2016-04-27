using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models.Contracts
{
    public interface ISellable
    {
        int Id { get; set; }

        string Name { get; set; }

        decimal Price { get; set; }

        string Measurement { get; set; }

        int Quantity { get; set; }

        decimal Total { get; }
    }
}
