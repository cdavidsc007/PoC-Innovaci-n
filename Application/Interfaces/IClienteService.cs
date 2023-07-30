using Application.DTO;
using Domain;
namespace Application.Interfaces
{
    public interface IClienteService
    {
        Cliente GetById(int id);
        IEnumerable<Cliente> GetAll();
        void Insert(Cliente cliente);
        void Update(Cliente cliente); 
        void Delete(Cliente cliente);
        void Delete(int id);

    }
}