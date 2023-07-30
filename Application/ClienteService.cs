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

    public class ClienteService : IClienteService
    {
      private readonly IGenericRepository<Cliente> _clienteRepository;
      

        public ClienteService(IGenericRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
            
        }
        public Cliente GetById(int id)
        {
            return _clienteRepository.GetByID(id);
        }
        public IEnumerable<Cliente> GetAll()
        {
            return _clienteRepository.Get();
        }
        public void Insert(Cliente cliente)
        {
            _clienteRepository.Insert(cliente);
            
            
        }
        public void Update(Cliente cliente)
        {
            _clienteRepository.Update(cliente);
        }
        public void Delete(Cliente cliente)
        {
            _clienteRepository.Delete(cliente);
        }
        public void Delete(int id)
        {
            _clienteRepository.Delete(id);
        }


    }
}
