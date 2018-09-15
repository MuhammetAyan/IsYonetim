using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Business
{
    public static class IsYonetim
    {
        public static IsYonetimEntities DataBase { get { return new IsYonetimEntities(); } }
    }
}
