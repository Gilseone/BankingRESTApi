using BankingRESTApi.Data.Converter.Implementations;
using BankingRESTApi.Data.VO;
using BankingRESTApi.Models;
using BankingRESTApi.Repository;
using BankingRESTApi.Repository.Generic;
using System.Collections.Generic;

namespace BankingRESTApi.Business.Implementations
{
    public class ClienteBusinessImplementation : IClienteBusiness
    {
        private readonly IClienteRepository _repository;
        private readonly IRepository<Conta> _repositoryConta;

        private readonly ClienteConverter _converter;

        public ClienteBusinessImplementation(IClienteRepository repository)
        {
            _repository = repository;
            _converter = new ClienteConverter();
        }

        public List<ClienteVO> FindAll()
        {
            //var clientes = _converter.Parse(_repository.FindAll());
            //foreach (var cliente in clientes)
            //    cliente.Conta = _converter.Parse(_repositoryConta.FindByID((long)cliente.ContaId)):
            return _converter.Parse(_repository.FindAll());
        }

        public ClienteVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public ClienteVO Create(ClienteVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public ClienteVO Update(ClienteVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public ClienteVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}