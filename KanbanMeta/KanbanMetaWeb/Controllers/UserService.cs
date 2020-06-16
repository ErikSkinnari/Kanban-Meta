using KanbanMetaWeb.Interfaces;
using KanbanMetaWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanMetaWeb.Controllers
{
    public class UserService : IUserManager
    {
        public UserService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName { get; set; }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public async Task<List<User>> GetUsers()
        {
            JsonFileName = Path.Combine(WebHostEnvironment.WebRootPath, "Data", "users.json");

            var dbContent = await File.ReadAllTextAsync(JsonFileName);

            var users = JsonConvert.DeserializeObject<List<User>>(dbContent);

            return users;
        }

        public Task PostUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
