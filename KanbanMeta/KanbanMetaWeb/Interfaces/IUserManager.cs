using KanbanMetaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanMetaWeb.Interfaces
{
    public interface IUserManager
    {
        public Task<List<User>> GetUsers();

        public Task PostUser(User user);
    }
}
