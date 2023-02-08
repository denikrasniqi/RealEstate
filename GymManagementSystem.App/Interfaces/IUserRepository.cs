using GymManagementSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.App.Interfaces
{
    public interface IUserRepository : IRepository<AspNetUser>
    {
        AspNetUser? GetByStringId(string id);
        List<AspNetUser> GetAllWithRoles();
        //UserPicture? GetUserPicture(string id);
        //string GetProfilePicturePath(string userId, int thumbnail);
        //void DeleteUserPicture(UserPicture userPicture);
        //void AddUserPicture(UserPicture userPicture);
    }
}
