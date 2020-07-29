using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary2lab4
{
    
   
    public class User
    {
        private int _id;
        private string _UserName;
        private string _Password;
        private string _Email;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }        
    }
}
