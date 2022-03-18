using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//投票主题以及其投票项

namespace Models
{
    public class Subject
    {
        private int subject_id;
        private string subject_content;
        private string select_mode;
        private string deadline;
        private Boolean votable;
        private string user_name;//发表用户
        public int Subject_id
        {
            get { return subject_id; }
            set { subject_id = value; }
        }
        public string Subject_content
        {
            get { return subject_content; }
            set { subject_content = value; }
        }
        public string Select_mode
        {
            get { return select_mode; }
            set { select_mode = value; }
        }
        public string Deadline
        {
            get { return deadline; }
            set { deadline = value; }
        }
        public Boolean Votable
        {
            get { return votable; }
            set { votable = value; }
        }
        public string User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }
    }
}
