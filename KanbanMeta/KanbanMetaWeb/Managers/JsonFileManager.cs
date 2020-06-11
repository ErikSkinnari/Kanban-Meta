using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanMetaWeb.Interfaces;
using Newtonsoft.Json;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Hosting;
using System.Collections;

namespace KanbanMetaWeb.Managers
{


    public class JsonFileService : IDbManager
    {
        public JsonFileService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        

        public IWebHostEnvironment WebHostEnvironment { get; }

        public void DeleteData()
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetData(string path)
        {
            var jsonFileName = Path.Combine(WebHostEnvironment.WebRootPath, "Data", path);

            var dbContent = File.ReadAllText(jsonFileName);
            if (string.IsNullOrWhiteSpace(dbContent))
            {
                return null;
            }

            var list = JsonConvert.DeserializeObject<List<object>>(dbContent);

            return list;
        }

        public void SaveData(object obj, string path)
        {
            var dbContent = File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(dbContent))
            {
                var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
                File.WriteAllText(path, json);
            }
            else
            {
                List<object> list = new List<object>();
                list = JsonConvert.DeserializeObject<List<object>>(dbContent);
                list.Add(obj);

                var json = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(path, json);
            }
        }

        public object UpdateData()
        {
            throw new NotImplementedException();
        }
    }
}
