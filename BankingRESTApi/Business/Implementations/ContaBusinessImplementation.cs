using BankingRESTApi.Data.Converter.Implementations;
using BankingRESTApi.Data.VO;
using BankingRESTApi.Models;
using BankingRESTApi.Repository;
using BankingRESTApi.Repository.Generic;
using System.Collections.Generic;

namespace BankingRESTApi.Business.Implementations
{
    public class ContaBusinessImplementation : IContaBusiness
    {
        private readonly IContaRepository _repository;

        private readonly ContaConverter _converter;

        public ContaBusinessImplementation(IContaRepository repository)
        {
            _repository = repository;
            _converter = new ContaConverter();
        }

        public List<ContaVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public ContaVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        //Depositar valor na conta
        public ContaVO Depositar(int agencia, int numero, decimal valor)
        {
            var conta = _repository.FindByAgenciaNumero(agencia, numero);
            if (conta is null)
                return null;
            conta.Saldo += valor;
            _repository.Update(conta);

            return _converter.Parse(conta);
        }

        //Sacar valor da conta
        public ContaVO Sacar(int agencia, int numero, decimal valor)
        {
            var conta = _repository.FindByAgenciaNumero(agencia, numero);
            if (conta is null)
                return null;

            if ((conta.Saldo - valor) < conta.Limite)
                return null;

            conta.Saldo -= valor;
            _repository.Update(conta);

            return _converter.Parse(conta);
        }

        //Transferir valor da conta
        public List<ContaVO> Transferir(int agenciaOrigem, int numeroOrigem,
                                  int agenciaDestino, int numeroDestino, decimal valor)
        {
            var contaOrigem = _repository.FindByAgenciaNumero(agenciaOrigem, numeroOrigem);
            if (contaOrigem is null)
                return null;

            var contaDestino = _repository.FindByAgenciaNumero(agenciaDestino, numeroDestino);
            if (contaDestino is null)
                return null;

            if ((contaOrigem.Saldo - valor) < contaOrigem.Limite)
                return null;

            contaOrigem.Saldo -= valor;
            _repository.Update(contaOrigem);

            contaDestino.Saldo += valor;
            _repository.Update(contaDestino);

            return _converter.Parse(new List<Conta> { contaOrigem , contaDestino});
        }

        public ContaVO Create(ContaVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public ContaVO Update(ContaVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}