using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KanbanMetaWeb.Models
{
    public class Card
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("boardId")]
        public string BoardId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("columnId")]
        public int ColumnId { get; set; }

        public void MoveCardRight() 
        { 
        
        }

        public void MoveCardLeft()
        {

        }

        public void EditCard(string str)
        {

        }
    }
}
