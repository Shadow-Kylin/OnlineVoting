using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Item
    {
        private int item_id;
        private int subject_id;
        private string item_content;
        public int Item_id
        {
            get { return item_id; }
            set { item_id = value; }
        }
        public int Subject_id
        {
            get { return subject_id; }
            set { subject_id = value; }
        }
        public string Item_content
        {
            get { return item_content; }
            set { item_content = value; }
        }
    }
}
