﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ICoverTypeRepository CoverTypeRepository { get; }
        IProductRepository ProductRepository { get; }
        void Save();
    }
}
