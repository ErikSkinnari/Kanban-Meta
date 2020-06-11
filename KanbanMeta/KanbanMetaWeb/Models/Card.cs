using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanMetaWeb.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ColimnId { get; set; }

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
