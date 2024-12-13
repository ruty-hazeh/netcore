using Pool.Core.models;
using Pool.Core.Repositories;
using Pool.Core.Services;
using Pool.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pool.Service
{
    public class SwimmerService: ISwimmerService
    {

        //private readonly ISwimmerRepository _swimmerRepository;
        private readonly IRepositoryManager _repositoryManager;

        public SwimmerService(ISwimmerRepository swimmerRepository, IRepositoryManager repositoryManager)
        {
            //_swimmerRepository = swimmerRepository;
            _repositoryManager = repositoryManager;
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
        public void Post(Swimmer swimmer)
        {
            //swimmer.Id = ++SwimmerCount;
            _repositoryManager.Swimmers.Post(swimmer);
            _repositoryManager.Save();
        }
        public void Put(int id, Swimmer swimmer)
        {
            _repositoryManager.Swimmers.Put(id, swimmer);
            _repositoryManager.Save();

        }
        public void PutStatus(int id, bool status)
        {
            _repositoryManager.Swimmers.PutStatus(id, status);
            _repositoryManager.Save();

        }

    }
}
