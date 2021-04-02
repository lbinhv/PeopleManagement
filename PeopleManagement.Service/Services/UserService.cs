using PeopleManagement.Data.Infrastructure;
using PeopleManagement.Data.Repositories;
using PeopleManagement.Model.Models;
using PeopleManagement.Service.Interfaces;
using System.Collections.Generic;

namespace PeopleManagement.Service.Services
{
    public class UserService : IUserService
    {
        #region Global Variable
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Contructor
        public UserService(IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Logic Implementation
        public void CreateUser(User user)
        {
            _userRepository.Add(user);
        }

        public void SaveUser()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<User> GetUsers()
        {
            var gadgets = _userRepository.GetAll();
            return gadgets;
        }

        #endregion
    }
}
