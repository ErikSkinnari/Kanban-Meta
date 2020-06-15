using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanMetaWeb.Models
{
    public class Board
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("columns")]
        public IEnumerable<Column> Columns { get; set; } = new List<Column>();

        [JsonProperty("userIds")]
        public IEnumerable<string> UserIds { get; set; } 

        public IEnumerable<User> Users { get; set; } = new List<User>();

        public IEnumerable<Card> Cards { get; set; } = new List<Card>();


        public void AddColumn()
        {

        }

        public void RemoveColumn(int columnId)
        {

        }

        public void EditTitle(string title)
        {

        }

    }
}
