using AutoMapper;
using Pool.Core.Dtos;
using Pool.Core.models;
using Pool.Core.Repositories;
using Pool.Core.Services;
using Pool.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pool.Service
{
    public class SwimmerService : ISwimmerService
    {

        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SwimmerService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public List<Swimmer> GetAll()
        {
            return _repositoryManager.Swimmers.GetAll();
        }
        public Swimmer GetById(int id)
        {
            return _repositoryManager.Swimmers.GetById(id);
        }
        public List<Swimmer> GetSwimmersByGender(Gender genderSwimmer)
        {
            return _repositoryManager.Swimmers.GetSwimmersByGender(genderSwimmer);
        }
        public Swimmer Post(SwimmerPostDTO swimmer)
        {
            var swimmeryMap = _mapper.Map<Swimmer>(swimmer);

            var res = _repositoryManager.Swimmers.Post(swimmeryMap);
            _repositoryManager.Save();
            return res;
        }

        public Swimmer Put(int id, SwimmerPutDTO swimmer)
        {
            var swimmeryMap = _mapper.Map<Swimmer>(swimmer);

            var res = _repositoryManager.Swimmers.Put(id, swimmeryMap);
            _repositoryManager.Save();
            return res;
        }
        public Swimmer PutStatus(int id, bool status)
        {
            var res = _repositoryManager.Swimmers.PutStatus(id, status);
            _repositoryManager.Save();
            return res;
        }

    }
}
