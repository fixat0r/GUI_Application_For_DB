using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.BuisnessLayer
{
    public class ProcessFactory
    {
        public static IUserProcess GetUserProcess() {
            return new UserProcess();
        }
        public static IPersProcess GetPersProcess()
        {
            return new PersProcess();
        }
    }
}
