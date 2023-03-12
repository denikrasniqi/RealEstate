using GymManagementSystem.Data.Entities;
using GymManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.App.Interfaces
{
    public interface IHouseRepository : IRepository<HouseTbl>
    {
        List<HousesViewModel> GetAllMembers();
        HouseTbl GetMember(string name);
    }
}
