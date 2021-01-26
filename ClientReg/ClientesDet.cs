using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientReg
{
    public class ClientesDet
    {
        public virtual Int32 Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Email { get; set; }
        public virtual String Telefone { get; set; }
        public virtual String Logradouro { get; set; }
        public virtual String Bairro { get; set; }
        public virtual String Numero { get; set; }
        public virtual String Complemento { get; set; }
        public virtual String CEP { get; set; }

        public virtual String Status { get; set; }


    }
}
