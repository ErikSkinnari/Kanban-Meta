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
using Microsoft.AspNetCore.Mvc;

namespace KanbanMetaWeb.Controllers
{


    public class DataService : IDataManager
    {
        public DataService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }


        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName {get; set;}

        public async Task AddCard(Card card)
        {
            JsonFileName = Path.Combine(WebHostEnvironment.WebRootPath, "Data", "cards.json");


            var dbContent = await File.ReadAllTextAsync(JsonFileName);

            if (string.IsNullOrWhiteSpace(dbContent))
            {
                var json = JsonConvert.SerializeObject(card, Formatting.Indented);

                await File.WriteAllTextAsync(JsonFileName, json);
            }
            else
            {
                List<Card> dataContent = new List<Card>();
                dataContent = JsonConvert.DeserializeObject<List<Card>>(dbContent);
                dataContent.Add(card);

                var json = JsonConvert.SerializeObject(dataContent, Formatting.Indented);

                await File.WriteAllTextAsync(JsonFileName, json);
            }
            
        }

        public async Task DeleteCard(string cardId)
        {
            JsonFileName = Path.Combine(WebHostEnvironment.WebRootPath, "Data", "cards.json");

            var dbContent = await File.ReadAllTextAsync(JsonFileName);


            if (string.IsNullOrWhiteSpace(dbContent))
            {
                // Fix so the program doesnt crash later
                throw new FileNotFoundException();
            }
            else
            {
                List<Card> dataContent = new List<Card>();
                dataContent = JsonConvert.DeserializeObject<List<Card>>(dbContent);

                var card = dataContent.Single(i => i.Id == cardId);

                dataContent.Remove(card);

                var json = JsonConvert.SerializeObject(dataContent, Formatting.Indented);

                await File.WriteAllTextAsync(JsonFileName, json);
            }
        }

        public Task DeleteBoard(int boardId)
        {
            throw new NotImplementedException();
        }

        public Task EditCard(int cardId, Card card)
        {
            throw new NotImplementedException();
        }

        public Task<Board> GetBoard(int boardId)
        {
            throw new NotImplementedException();
        }







        //public void DeleteData(string id, string path)
        //{
        //    JsonFileName = Path.Combine(WebHostEnvironment.WebRootPath, "Data", path);

        //    var dbContent = File.ReadAllText(JsonFileName);
        //    if (string.IsNullOrWhiteSpace(dbContent))
        //    {
        //        return;
        //    }
        //    var list = JsonConvert.DeserializeObject<List<Card>>(dbContent);

        //    var item = list.Single(i => i.Id == id);

        //    list.Remove(item);


        //    var json = JsonConvert.SerializeObject(list, Formatting.Indented);
        //    File.WriteAllText(JsonFileName, json);
        //}

        //public IEnumerable GetData(string path)
        //{
        //    JsonFileName = Path.Combine(WebHostEnvironment.WebRootPath, "Data", path);

        //    var dbContent = File.ReadAllText(JsonFileName);
        //    if (string.IsNullOrWhiteSpace(dbContent))
        //    {
        //        return null;
        //    }

        //    var list = JsonConvert.DeserializeObject<List<Card>>(dbContent);

        //    return list;
        //}

        //public void SaveData(object obj, string path)
        //{
        //    JsonFileName = Path.Combine(WebHostEnvironment.WebRootPath, "Data", path);

        //    var dbContent = File.ReadAllText(JsonFileName);
        //    if (string.IsNullOrWhiteSpace(dbContent))
        //    {
        //        var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        //        File.WriteAllText(JsonFileName, json);
        //    }
        //    else
        //    {
        //        List<Card> list = new List<Card>();
        //        list = JsonConvert.DeserializeObject<List<Card>>(dbContent);
        //        list.Add((Card)obj);

        //        var json = JsonConvert.SerializeObject(list, Formatting.Indented);
        //        File.WriteAllText(JsonFileName, json);
        //    }
        //}

        //public object UpdateData()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
