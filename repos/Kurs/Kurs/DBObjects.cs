using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs
{
    public static class DBObjects
    {
        public static Kursovaya_ShDEntities Entities { get; } = new Kursovaya_ShDEntities();
    }
}
