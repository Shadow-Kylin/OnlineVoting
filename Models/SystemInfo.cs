using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SystemInfo
    {
        private int regiterUserSum;
        private int publishedSubjectSum;
        private int visitSum;
        public int RegiterUserSum { 
            get { return regiterUserSum; } 
            set { regiterUserSum = value; } 
        }
        public int PublishedSubjectSum
        {
            get { return publishedSubjectSum; }
            set { publishedSubjectSum = value; }
        }
        public int VisitSum
        {
            get { return visitSum; }
            set { visitSum = value; }
        }
    }
}
