using PeopleManagement.Data.Infrastructure;
using PeopleManagement.Data.Repositories;
using PeopleManagement.Model.Models;
using PeopleManagement.Service.CommonViewModels;
using PeopleManagement.Service.Interfaces;
using System;
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

            return entities.Skip(skip).Take(take).ToList();
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
            var userData = new User();

            if (data != null)
            {
                userData = new User
                {
                    UserId = data.UserId,
                    NRIC = data.NRIC,
                    AvaiableDate = data.AvaiableDate,
                    Birthday = data.Birthday,
                    Subjects = data.Subjects.Select(m => new UserSubject
                    {
                        UserId = m.UserId,
                        SubjectId = m.SubjectId,
                    })
                };

                return userData;
            }
            return null;
        }
        #endregion
    }
}
