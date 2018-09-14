using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace IsYonetim.Business
{
    class DatabaseEntities
    {
        public static IsYonetimEntities Bitirme { get { return new IsYonetimEntities(); } }
    }
}
