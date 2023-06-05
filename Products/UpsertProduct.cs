﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public record UpsertProduct
        (
        string product_name,
        string product_description,
        string product_image,
        decimal product_price,
        int product_quantity
        );
}
