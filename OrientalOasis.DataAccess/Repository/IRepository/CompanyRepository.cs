﻿using OrientalOasis.DataAccess.Data;
using OrientalOasis.DataAccess.Repository.IRepository;
using OrientalOasis.Model;
using System.Linq;

namespace OrientalOasis.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company obj)
        {
            var objFromDb = _db.Companies.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.StreetAddress = obj.StreetAddress;
                objFromDb.City = obj.City;
                objFromDb.State = obj.State;
                objFromDb.PostalCode = obj.PostalCode;
                objFromDb.PhoneNumber = obj.PhoneNumber;
                //objFromDb.IsAuthorizedCompany = obj.IsAuthorizedCompany;
            }
        }
    }
}
