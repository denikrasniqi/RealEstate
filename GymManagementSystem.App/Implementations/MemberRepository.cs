﻿using Arch.EntityFrameworkCore;
using GymManagementSystem.App.Interfaces;
using GymManagementSystem.Data.Context;
using GymManagementSystem.Data.Entities;
using GymManagementSystem.Models;

namespace GymManagementSystem.App.Implementations
{
    public class MemberRepository : Repository<Antaresimi>, IMemberRepository
    {
        protected readonly GymSystemDBContext _gymSystemDbContext;
        public MemberRepository(GymSystemDBContext gymSystemDbContext) : base(gymSystemDbContext)
        {
            _gymSystemDbContext = gymSystemDbContext;
        }


        public List<MembersViewModel> GetAllMembers()
        {
            var members = _gymSystemDbContext.Antaresimis.Include(x=>x).ToList();
            return new List<MembersViewModel>();
        }
        /// <summary>
        /// GetMember by Name
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public AspNetUser GetMember(string name)
        {
            var user = _gymSystemDbContext.AspNetUsers.Where(x => x.Name == name).FirstOrDefault();
            return user!;
        }
    }
}
