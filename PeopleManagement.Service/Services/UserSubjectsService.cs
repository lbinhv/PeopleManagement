using PeopleManagement.Data.Infrastructure;
using PeopleManagement.Data.Repositories;
using PeopleManagement.Model.Models;
using PeopleManagement.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleManagement.Service.Services
{
    public class UserSubjectsService : IUserSubjectsService
    {
        #region Global Variable
        private readonly IUserSubjectsRepository _userSubjectsRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Contructor
        public UserSubjectsService(IUserSubjectsRepository userSubjectsRepository,
            IUnitOfWork unitOfWork)
        {
            _userSubjectsRepository = userSubjectsRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Logic Implementation
        public void CreateUserSubjects(IEnumerable<UserSubject> userSubjectsData, Guid userId)
        {
            //Delete element Fisrt
            var existData = _userSubjectsRepository.GetAll().Where(m => m.UserId == userId);
            foreach (var item in existData)
            {
                _userSubjectsRepository.Delete(item);
            }

            //Create new element
            foreach (var item in userSubjectsData)
            {
                _userSubjectsRepository.Add(item);
            }
        }

        #endregion
    }
}
