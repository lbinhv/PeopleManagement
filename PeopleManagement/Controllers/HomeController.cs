using AutoMapper;
using PeopleManagement.Model.Models;
using PeopleManagement.Models;
using PeopleManagement.Service.CommonViewModels;
using PeopleManagement.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PeopleManagement.Controllers
{
    public class HomeController : Controller
    {
        #region Global Variable
        private readonly IUserService _userService;
        private readonly ISubjectService _subjectService;
        private readonly IUserSubjectsService _userSubjectService;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public HomeController(IUserService userService,
            ISubjectService subjectService,
            IUserSubjectsService userSubjectService,
            IMapper mapper)
        {
            _userService = userService;
            _subjectService = subjectService;
            _userSubjectService = userSubjectService;
            _mapper = mapper;
        }
        #endregion


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetUsers(DataTableAjaxPostModel model)
        {
            var data = _userService.GetUsers(model, out int filteredResultsCount, out int totalResultsCount);

            var result = _mapper.Map<List<UserViewModel>>(data);

            return Json(new
            {
                // this is what datatables wants sending back
                draw = model.draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = result
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Register(string key = "")
        {
            var people = new UserModel();
            if (!string.IsNullOrEmpty(key))
            {
                //Get Exist Data
                var data = _userService.GetUserByKey(key);

                //people = _mapper.Map<UserModel>(data);
            }
            else
            {
                //Get Subject Data
                people.Subjects = _mapper.Map<List<SubjectModel>>(_subjectService.GetSubjects());
            }

            return PartialView("Partial/_Register", people);
        }

        //POST: Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel user)
        {
            if (string.IsNullOrEmpty(user.Gender))
            {
                ModelState.AddModelError("Gender", "Please Choose Your Gender.");
            }

            if (ModelState.IsValid)
            {
                //Check Exist NRIC before save new data
                var nricData = _userService.CheckNRIC(user.NRIC);

                if (nricData)
                {
                    ModelState.AddModelError("NRIC", "The NRIC is exist in the system");
                }
                var id = Guid.NewGuid();
                var peopleModel = new User
                {
                    UserId = id,
                    AvaiableDate = user.AvaiableDate,
                    Birthday = user.Birthday,
                    Gender = user.Gender.ToString(),
                    Name = user.Name,
                    NRIC = user.NRIC,
                    Subjects = user.Subjects.Where(m => m.IsChecked).Select(m => new UserSubject
                    {
                        Id = Guid.NewGuid(),
                        SubjectId = m.Id,
                        UserId = id
                    })
                };

                _userService.CreateUser(peopleModel);
                _userSubjectService.CreateUserSubjects(peopleModel.Subjects, id);

                return Redirect("Index");

            }
            return PartialView("Partial/_Register", user);
        }
    }
}