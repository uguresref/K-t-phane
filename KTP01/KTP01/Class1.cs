using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTP01
{
    public class Class1
    {
        public string kitapadı { get; set; }
        public string yayınevi { get; set; }
        public string yazaradı { get; set; }
        public string baskısayısı { get; set; }
        public string yazarsayısı { get; set; }
        public string basımyılı { get; set; }
        public string tür { get; set; }
        public string ısb { get; set; }


        public override string ToString()
        {
            return $"{this.yazaradı} {this.kitapadı} {this.yayınevi}";
        }

    }
   
}

