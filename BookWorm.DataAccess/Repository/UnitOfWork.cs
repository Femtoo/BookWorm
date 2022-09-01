using BookWorm.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDatabaseContext _db;
        public UnitOfWork(ApplicationDatabaseContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
        }

        public ICategoryRepository CategoryRepository { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
