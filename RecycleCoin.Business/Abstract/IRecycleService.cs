﻿using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Abstract
{
    public interface IRecycleService
    {
        void AddRecycle(Recycle recycle);
        List<Recycle> GetByCustomerId(int customerId);
        List<Recycle> GetByUserId(int userId); 
    }
}
