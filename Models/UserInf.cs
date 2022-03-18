using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//用户信息

namespace Models
{
    public class UserInf
    {
        private int user_id;
        private string user_name;
        private string user_pwd;
        private int user_status;
        private string user_email;
        private string user_phone;
        private string user_sex;
        private string user_birthday;
        private string user_residence;//居住地
        private string user_photopath;//头像路径
        private string user_signature;//简介
        public int User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        public string User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }
        public string User_pwd
        {
            get { return user_pwd; }
            set { user_pwd = value; }
        }
        public int User_status
        {
            get { return user_status; }
            set { user_status = value; }
        }
        public string User_email
        {
            get { return user_email; }
            set { user_email = value; }
        }
        public string User_phone
        {
            get { return user_phone; }
            set { user_phone = value; }
        }
        public string User_sex
        {
            get { return user_sex; }
            set { user_sex = value; }
        }
        public string User_birthday
        {
            get { return user_birthday; }
            set { user_birthday = value; }
        }
        public string User_residence
        {
            get { return user_residence; }
            set { user_residence = value; }
        }
        public string User_photopath
        {
            get { return user_photopath; }
            set { user_photopath = value; }
        }
        public string User_signature
        {
            get { return user_signature; }
            set { user_signature = value; }
        }
    }
}
