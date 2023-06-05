using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public record ProductResponse
        (
        Guid id,
        string product_name,
        string product_description,
        string product_image,
        decimal product_price,
        int product_quantity,
        DateTime added_date
        );
}
