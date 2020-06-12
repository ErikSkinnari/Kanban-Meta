using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanMetaWeb.Models
{
    public class Card
    {
        public string id { get; set; }
        public string boardId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int columnId { get; set; }

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
