using PeopleManagement.Data.Infrastructure;
using PeopleManagement.Data.Repositories;
using PeopleManagement.Model.Models;
using PeopleManagement.Service.CommonViewModels;
using PeopleManagement.Service.Helpers;
using PeopleManagement.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using static PeopleManagement.Service.Helpers.Enums;

namespace PeopleManagement.Service.Services
{
    public class UserService : IUserService
    {
        #region Global Variable
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserSubjectsService _userSubjectsService;
        public readonly IUserSubjectsRepository _userSubjectsRepository;
        #endregion

        #region Contructor
        public UserService(IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IUserSubjectsService userSubjectsService,
            IUserSubjectsRepository userSubjectsRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _userSubjectsService = userSubjectsService;
            _userSubjectsRepository = userSubjectsRepository;
        }
        #endregion

        #region Logic Implementation
        public void CreateUser(User user)
        {
            _userRepository.Add(user);
            _userSubjectsService.CreateUserSubjects(user.Subjects, user.UserId);

            _unitOfWork.Commit();
        }

        public IEnumerable<User> GetUsers(DataTableAjaxPostModel model, out int filteredResultsCount, out int totalResultsCount)
        {
            var searchBy = (model.search != null) ? model.search.value : null;
            var take = model.length;
            var skip = model.start;

            string sortBy = "";
            bool sortDir = true;

            if (model.order != null)
            {
                sortDir = model.order[0].dir.ToLower() == SortDir.ASC.ToString().ToLower();
            }

            if (sortBy == "")
            {
                sortBy = "DateCreated";
                sortDir = false;
            }

            // search the dbase taking into consideration table sorting and paging
            var entities = _userRepository.GetAll();
            // have value search
            if (!string.IsNullOrEmpty(searchBy))
            {
                entities = entities.Where(a => a.NRIC.Contains(searchBy) || a.Name.Contains(searchBy));
            }

            totalResultsCount = entities.Count();

            var propertyinfo = typeof(User).GetProperties().Where(t => t.Name.ToLower() == sortBy.ToLower()).FirstOrDefault();

            if (propertyinfo != null)
            {
                entities = sortDir ? entities.OrderBy(i => propertyinfo.GetValue(i, null)) : entities.OrderByDescending(i => propertyinfo.GetValue(i, null));
            }

            filteredResultsCount = entities.Count();

            var listUser = entities.Skip(skip).Take(take).ToList();
            foreach (var user in listUser)
            {
                user.Subjects = _userSubjectsRepository.GetAll().Where(m => m.UserId == user.UserId);
            }
            return listUser;
        }

        public bool CheckNRIC(string value)
        {
            var data = _userRepository.FirstOne(m => m.NRIC == value);
            if (data != null)
            {
                return true;
            }
            return false;
        }

        public User GetUserByKey(string key)
        {
            var data = _userRepository.Get(m => m.NRIC == key);

            if (data != null)
            {
                data.Subjects = _userSubjectsRepository.GetAll().Where(m => m.UserId == data.UserId);
                return data;
            }
            return null;
        }

        public ErrorModel UpdateUser(User user)
        {
            var error = new ErrorModel();
            var existUser = _userRepository.FirstOne(m => m.UserId == user.UserId);
            if (existUser != null)
            {
                //If the NRIC is changed
                if (user.NRIC != existUser.NRIC)
                {
                    //Check if the new NRIC value is exist
                    var nRICChanged = _userRepository.FirstOne(m => m.NRIC.Equals(user.NRIC));
                    if (nRICChanged != null)
                    {
                        error.IsError = true;
                        error.ErrorContent = Const.NRICExist;
                        error.Element = Const.NRIC;
                        return error;
                    }
                }
                _userRepository.Update(user.UserId, user);
                _userSubjectsService.CreateUserSubjects(user.Subjects, user.UserId);

                _unitOfWork.Commit();
            }
            return error;
        }
        #endregion
    }
}
