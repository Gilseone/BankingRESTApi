using BankingRESTApi.Models;
using BankingRESTApi.Models.Context;
using BankingRESTApi.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingRESTApi.Repository.Implementations
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MySQLContext context) : base(context) { }

        public new List<Cliente> FindAll()
        {
            return _context.Clientes.Include(x => x.Conta).ToList();
        }

        public new Cliente FindByID(long id)
        {
            return _context.Clientes.Include(x => x.Conta).FirstOrDefault(p => p.Id.Equals(id));
        }

        public Cliente Disable(long id)
        {
            if (!_context.Clientes.Any(p => p.Id.Equals(id))) return null;

            var user = _context.Clientes.SingleOrDefault(p => p.Id.Equals(id));
            if (user != null)
            {
                user.Ativo = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return user;
        }
    }
}