using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//用户参与的投票主题及其所选选项

namespace Models
{
    public class UserVote
    {
        private int user_id;
        private int votedSubject_id;
        private int votedItem_id;
        public int User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        public int VotedSubject_id
        {
            get { return votedSubject_id; }
            set { votedSubject_id = value; }
        }
        public int VotedItem_id
        {
            get { return votedItem_id; }
            set { votedItem_id = value; }
        }
    }
}
