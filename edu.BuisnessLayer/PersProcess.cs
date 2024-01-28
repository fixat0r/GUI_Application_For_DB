using edu.DataAccess;
using edu.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.BuisnessLayer
{
    public class PersProcess : IPersProcess
    {
        private readonly IPersDao persDao;
        public PersProcess() { 
            persDao = DaoFactory.getPersDao();
        }
        public PersDto Get(int id) {
            return DtoConverter.Convert(persDao.get(id));
        }
        public void Add(PersDto pers) {
            persDao.add(DtoConverter.Convert(pers));
        }
        public void Update(PersDto pers) {
            persDao.update(DtoConverter.Convert(pers));
        }
        public void Delete(int id) { 
            persDao.delete(id);
        }
        public IList<PersDto> GetPers() {
            return DtoConverter.Convert(persDao.getPers());
        }
        
    }
}
