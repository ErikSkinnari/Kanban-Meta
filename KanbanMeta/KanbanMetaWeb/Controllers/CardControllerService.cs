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
using KanbanMetaWeb.Models;

namespace KanbanMetaWeb.Controllers
{


    public class CardControllerService : IDbManager
    {
        public CardControllerService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }


        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName {get; set;}

        public void DeleteData(string id, string path)
        {
            JsonFileName = Path.Combine(WebHostEnvironment.WebRootPath, "Data", path);

            var dbContent = File.ReadAllText(JsonFileName);
            if (string.IsNullOrWhiteSpace(dbContent))
            {
                return;
            }
            var list = JsonConvert.DeserializeObject<List<Card>>(dbContent);

            var item = list.Single(i => i.id == id);

            list.Remove(item);


            var json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(JsonFileName, json);
        }

        public IEnumerable GetData(string path)
        {
            JsonFileName = Path.Combine(WebHostEnvironment.WebRootPath, "Data", path);

            var dbContent = File.ReadAllText(JsonFileName);
            if (string.IsNullOrWhiteSpace(dbContent))
            {
                return null;
            }

            var list = JsonConvert.DeserializeObject<List<Card>>(dbContent);

            return list;
        }

        public void SaveData(object obj, string path)
        {
            JsonFileName = Path.Combine(WebHostEnvironment.WebRootPath, "Data", path);

            var dbContent = File.ReadAllText(JsonFileName);
            if (string.IsNullOrWhiteSpace(dbContent))
            {
                var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
                File.WriteAllText(JsonFileName, json);
            }
            else
            {
                List<Card> list = new List<Card>();
                list = JsonConvert.DeserializeObject<List<Card>>(dbContent);
                list.Add((Card)obj);

                var json = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(JsonFileName, json);
            }
        }

        public object UpdateData()
        {
            throw new NotImplementedException();
        }
    }
}
