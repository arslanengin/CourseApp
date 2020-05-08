using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public interface IUserRepository
    {
        //User GetById(int userid);

        IEnumerable<User> GetUsers();

        //void CreateUser(User user);

        //void DeleteUser(int userid);
        //void UpdateUser(User user);


    }
}
