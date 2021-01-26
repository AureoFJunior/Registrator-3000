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
            Id(t => t.Id, "clie_id").GeneratedBy.Native();
            Map(t => t.Nome, "clie_nome");
            Map(t => t.Email, "clie_email");
            Map(t => t.Telefone, "clie_telefone");
            Map(t => t.Logradouro, "clie_logradouro");
            Map(t => t.Bairro, "clie_bairro");
            Map(t => t.Numero, "clie_numero");
            Map(t => t.Complemento, "clie_compl");
            Map(t => t.CEP, "clie_cep");
            Map(t => t.Status, "clie_status");
            Table("clientes");
        }
    }
}
