using edu.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.BuisnessLayer
{
    public interface IPersProcess
    {
        PersDto Get(int id);
        void Add(PersDto pers);
        void Update(PersDto pers);
        void Delete(int id);
        IList<PersDto> GetPers();
    }
}
