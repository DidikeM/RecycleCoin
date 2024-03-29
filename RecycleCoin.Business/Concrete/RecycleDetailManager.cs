﻿using RecycleCoin.Business.Abstract;
using RecycleCoin.DataAccess.Abstract;
using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Concrete
{
    public class RecycleDetailManager : IRecycleDetailService
    {
        IRecycleDetailDal _recycleDetailDal;

        public RecycleDetailManager(IRecycleDetailDal recycleDetailDal)
        {
            _recycleDetailDal = recycleDetailDal;
        }

        public void AddRecycleDetail(RecycleDetail recycleDetail)
        {
            _recycleDetailDal.Add(recycleDetail);
        }

        public List<RecycleDetail> GetByRecycleId(int recycleId)
        {
            return _recycleDetailDal.GetAll(p => p.RecycleId == recycleId);
        }

        public int SumOfCarbon()
        {
            return _recycleDetailDal.SumInt(p => p.SubTotalPrice);
        }

        public int SumOfCarbonToCustomerId(int customerId)
        {
            return _recycleDetailDal.SumInt(p=>p.SubTotalPrice, q=>q.Recycle.CustomerId == customerId);
        }

        public int SumOfProductQuantityToProductId(int productId)
        {
            return _recycleDetailDal.SumInt(p=>p.ProductQuantity, q=>q.ProductId == productId);
        }
    }
}
