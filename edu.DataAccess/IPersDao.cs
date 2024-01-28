using edu.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.DataAccess
{
    public interface IPersDao
    {
        public Pers get(int id);
        void add(Pers pers);
        void update(Pers pers);
        void delete(int id);
        IList<Pers> getPers();
    }
}
