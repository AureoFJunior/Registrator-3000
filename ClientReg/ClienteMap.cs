using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientReg
{
    class ClienteMap : ClassMap<ClientesDet>
    {
        public ClienteMap()
        {
            Id(t => t.Id);
            Map(t => t.Nome);
            Map(t => t.Email);
            Map(t => t.Telefone);
            Map(t => t.Logradouro);
            Map(t => t.Bairro);
            Map(t => t.Numero);
            Map(t => t.Complemento);
            Map(t => t.CEP);
            Table("clientes");
        }
    }
}
