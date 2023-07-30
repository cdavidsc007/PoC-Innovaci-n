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
    public class ComercioService : IComercioService
    {
        private readonly IGenericRepository<Comercio> _ComercioRepository;


        public ComercioService(IGenericRepository<Comercio> ComercioRepository)
        {
            _ComercioRepository = ComercioRepository;

        }
        public Comercio GetById(int id)
        {
            return _ComercioRepository.GetByID(id);
        }
        public IEnumerable<Comercio> GetAll()
        {
            return _ComercioRepository.Get();
        }
        public void Insert(Comercio Comercio)
        {
            _ComercioRepository.Insert(Comercio);


        }
        public void Update(Comercio Comercio)
        {
            _ComercioRepository.Update(Comercio);
        }
        public void Delete(Comercio Comercio)
        {
            _ComercioRepository.Delete(Comercio);
        }
        public void Delete(int id)
        {
            _ComercioRepository.Delete(id);
        }


    }

}

