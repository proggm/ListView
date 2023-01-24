using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView.Model
{
   public partial class InfoUser
    {
        public string GetPhoto
        {
            get
            {
                return Environment.CurrentDirectory + "\\" + Photo;
            }
            set
            {
                Photo = value;
            }
        }
    }
}
