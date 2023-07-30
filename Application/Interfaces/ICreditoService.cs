using Application.DTO;
using Domain;

namespace Application.Interfaces
{
    public interface ICreditoService
    {
        Credito GetById(int id);
        IEnumerable<Credito> GetAll();
        void Insert(Credito credito);
        void Update(Credito credito);
        void Delete(Credito credito);
        void Delete(int id);
        void New(Credito credito);

    }
}