using Cheques.UNA.Cheques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheques
{
    class ArchivoManager
    {
        public List<Cheque> ChequesList { get; set; }
        public ArchivoManager()
        {
            ChequesList = new List<Cheque>();
        }

        public void LeerArchivo()
        {

        }
    }
}
