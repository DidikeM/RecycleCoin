﻿using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Abstract
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        Customer GetByUserId(int userID);
        void Update(Customer customer);
        List<Customer> GetAll();
    }
}
