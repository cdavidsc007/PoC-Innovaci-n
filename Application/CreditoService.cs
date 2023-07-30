using Application.DTO;
using Application.Interfaces;
using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CreditoService : ICreditoService
    {
        private readonly IGenericRepository<Credito> _creditoRepository;
        private readonly IGenericRepository<Cliente> _clienteRepository;


        public CreditoService(IGenericRepository<Credito> creditoRepository, IGenericRepository<Cliente> clienteRepository)
        {
            _creditoRepository = creditoRepository;
            _clienteRepository = clienteRepository;

        }
        public Credito GetById(int id)
        {
            return _creditoRepository.GetByID(id);
        }
        public IEnumerable<Credito> GetAll()
        {
            return _creditoRepository.Get();
        }
        public void Insert(Credito Credito)
        {
            _creditoRepository.Insert(Credito);


        }
        public void Update(Credito Credito)
        {
            _creditoRepository.Update(Credito);
        }
        public void Delete(Credito Credito)
        {
            _creditoRepository.Delete(Credito);
        }
        public void Delete(int id)
        {
            _creditoRepository.Delete(id);
        }
        public void New(Credito credito) {
            var cliente = _clienteRepository.GetByID(credito.IdCliente);
            if (cliente.Cupo - cliente.Deuda > credito.Monto)
            {
                _creditoRepository.Insert(credito);
                cliente.Deuda += (double)credito.Monto;
                _clienteRepository.Update(cliente);
            }else
            {

            }
        }

    }
}