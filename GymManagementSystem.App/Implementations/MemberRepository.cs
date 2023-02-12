using Arch.EntityFrameworkCore;
using GymManagementSystem.App.Interfaces;
using GymManagementSystem.Data.Context;
using GymManagementSystem.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.App.Implementations
{
    public class MemberRepository :Repository<Antaresimi>,IMemberRepository
    {
        protected readonly GymSystemDBContext _gymSystemDbContext;
        public MemberRepository(GymSystemDBContext gymSystemDbContext) : base(gymSystemDbContext)
        {
            _gymSystemDbContext = gymSystemDbContext;
        }


        public List<Antaresimi> GetAllMembers()
        {
            return _gymSystemDbContext.Antaresimis.Include(x => x.Antaresimi1).ToList();
        }




    }
}
