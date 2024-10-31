﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebdotNet.Models.ViewModels
{
    public class OrderVM
    {
        public OrderHeader orderHeader { get; set; }
        public IEnumerable<OrderDetail> orderDetail { get; set; }
    }
}
