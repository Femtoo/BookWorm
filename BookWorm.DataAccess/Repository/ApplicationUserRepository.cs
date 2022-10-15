using BookWorm.DataAccess.Repository.IRepository;
using BookWorm.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDatabaseContext _db;       
        public ApplicationUserRepository(ApplicationDatabaseContext db) : base(db)
        {
            _db = db;
        }

    }
}
