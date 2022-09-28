using BookWorm.DataAccess.Repository.IRepository;
using BookWorm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDatabaseContext _db;
        public CompanyRepository(ApplicationDatabaseContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company obj)
        {
            var objFromDb = _db.Companies.FirstOrDefault(u => u.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.StreetAddress = obj.StreetAddress;
                objFromDb.PhoneNumber = obj.PhoneNumber;
                objFromDb.City = obj.City;
                objFromDb.PostalCode = obj.PostalCode;
                objFromDb.State = obj.State;
            }
        }
    }
}
