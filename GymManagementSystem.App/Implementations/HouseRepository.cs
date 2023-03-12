using GymManagementSystem.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementSystem.App.Interfaces;
using GymManagementSystem.Data.Context;
using GymManagementSystem.Data.Entities;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.App.Implementations
{
    public class HouseRepository :Repository<HouseTbl> , IHouseRepository
    {
        protected readonly RealEstateDBContext _realestateDbContext;
        public HouseRepository(RealEstateDBContext realestateDbContext) : base(realestateDbContext)
        {
            _realestateDbContext = realestateDbContext;
        }
        public List<HousesViewModel> GetAllMembers()
        {
            var members = _realestateDbContext.HouseTbls.Include(x => x).ToList();
            return new List<HousesViewModel>();
        }
        public HouseTbl GetMember(string type)
        {
            var house = _realestateDbContext.HouseTbls.Where(x => x.Type == type).FirstOrDefault();
            return house!;
        }
    }
}
