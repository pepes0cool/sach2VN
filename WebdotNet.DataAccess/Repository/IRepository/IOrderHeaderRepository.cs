﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdotNet.Models;
namespace WebdotNet.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader orderHeader);
        void UpdateStatus(int id, string status, string? paymentStatus = null );
        void UpdateStripePaymentID(int id, string sessionId, string paymentID);
    }
}
