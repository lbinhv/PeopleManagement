using PeopleManagement.Data.Infrastructure;
using PeopleManagement.Data.Repositories;
using PeopleManagement.Model.Models;
using PeopleManagement.Service.Interfaces;
using System.Collections.Generic;

namespace PeopleManagement.Service.Services
{
    public class SubjectService : ISubjectService
    {
        #region Global Variable
        private readonly ISubjectRepository _subjectRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Contructor
        public SubjectService(ISubjectRepository subjectRepository,
            IUnitOfWork unitOfWork)
        {
            _subjectRepository = subjectRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Logic Implementation
        public IEnumerable<Subject> GetSubjects()
        {
            return _subjectRepository.GetAll();
        }

        #endregion
    }
}
