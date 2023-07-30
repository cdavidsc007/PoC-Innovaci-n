using Application.DTO;
using Domain;

namespace Application.Interfaces
{
    public interface IComercioService
    {
        Comercio GetById(int id);
        IEnumerable<Comercio> GetAll();
        void Insert(Comercio Comercio);
        void Update(Comercio Comercio);
        void Delete(Comercio Comercio);
        void Delete(int id);

    }
}