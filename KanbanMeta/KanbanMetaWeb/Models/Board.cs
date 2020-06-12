using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanMetaWeb.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Column> Columns { get; set; } = new List<Column>();
        public List<User> Users { get; set; } = new List<User>();
        public List<Card> Cards { get; set; } = new List<Card>();


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
