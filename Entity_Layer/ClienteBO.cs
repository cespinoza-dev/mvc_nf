using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
//DNI      CHAR(8)
//NOMBRE   VARCHAR2(35)
//APELLIDO VARCHAR2(35)
//EMAIL    VARCHAR2(35)
//TELEFONO NUMBER

    public class ClienteBO
    {
        public string DNI { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string EMAIL { get; set; }
        public int TELEFONO { get; set; }

    }
}
