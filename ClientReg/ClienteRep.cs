using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientReg
{
    public class Repositorio<T> where T : class, new()
    {
        public void Inserir(T entidade)
        {
            using (ISession session = NhibernateFactory.openSec())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entidade);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir Cliente : " + ex.Message);
                    }
                }
            }
        }
        public void Alterar(T entidade)
        {
            using (ISession session = NhibernateFactory.openSec())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entidade);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao Alterar Cliente : " + ex.Message);
                    }
                }
            }
        }
        public void Excluir(T entidade)
        {
            using (ISession session = NhibernateFactory.openSec())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entidade);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao Excluir Cliente : " + ex.Message);
                    }
                }
            }
        }
        public T RetornarPorId(int Id)
        {
            using (ISession session = NhibernateFactory.openSec())
            {
                return session.Get<T>(Id);
            }
        }
        public IList<T> Consultar()
        {
            using (ISession session = NhibernateFactory.openSec())
            {
                return (from c in session.Query<T>() select c).ToList();
            }
        }
    }
}
