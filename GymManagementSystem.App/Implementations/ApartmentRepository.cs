using GymManagementSystem.App.Interfaces;
using GymManagementSystem.Data.Context;
using GymManagementSystem.Data.Entities;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.App.Implementations
{
    public class ApartmentRepository : Repository<ApartmentTbl>, IApartmentRepository
    {
        protected readonly RealEstateDBContext _realestateDbContext;
        public ApartmentRepository(RealEstateDBContext realestateDbContext) : base(realestateDbContext)
        {
            _realestateDbContext = realestateDbContext;
        }
        public List<ApartmentsViewModel> GetAllMembers()
        {
            var apartments = _realestateDbContext.ApartmentTbls.Include(x => x).ToList();
            return new List<ApartmentsViewModel>();
        }
        public ApartmentTbl GetMember(string type)
        {
            var apartment = _realestateDbContext.ApartmentTbls.Where(x => x.Type == type).FirstOrDefault();
            return apartment!;
        }
        
    }
}
