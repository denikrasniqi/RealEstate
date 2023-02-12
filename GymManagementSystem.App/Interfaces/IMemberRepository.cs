using GymManagementSystem.App.Implementations;
using GymManagementSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.App.Interfaces
{
    public interface IMemberRepository :IRepository<Antaresimi>
    {
        List<Antaresimi> GetAllMembers();

    }
}
