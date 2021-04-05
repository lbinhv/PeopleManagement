using AutoMapper;
using PeopleManagement.Model.Models;
using PeopleManagement.Models;
using PeopleManagement.Service.CommonViewModels;
using PeopleManagement.Service.Helpers;
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
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public HomeController(IUserService userService,
            ISubjectService subjectService,
            IMapper mapper)
        {
            _userService = userService;
            _subjectService = subjectService;
            _mapper = mapper;
        }
        #endregion

        #region Action Result Method
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(string key = "")
        {
            try
            {
                HelperStoreSqlLog.WriteInformation(null, "Start get sybject");
                var people = new UserModel
                {
                    //Get Subject Data
                    Subjects = _mapper.Map<List<SubjectModel>>(_subjectService.GetSubjects())
                };
                HelperStoreSqlLog.WriteInformation(null, "End get sybject");

                if (!string.IsNullOrEmpty(key))
                {
                    HelperStoreSqlLog.WriteInformation(null, "Start get user by Id");
                    //Get Exist Data
                    var data = _userService.GetUserByKey(key);

                    people = ConvertModel(data, people);
                    HelperStoreSqlLog.WriteInformation(null, "End get user by Id");
                }

                return PartialView("Partial/_Register", people);
            }
            catch (Exception ex)
            {
                HelperStoreSqlLog.WriteError(ex, ex.Message);
                return RedirectToAction("Index");
            }
        }

        //POST: Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel userModel)
        {
            try
            {
                if (string.IsNullOrEmpty(userModel.Gender))
                {
                    ModelState.AddModelError(Const.Gender, Const.GenderRequired);
                }

                if (ModelState.IsValid)
                {
                    HelperStoreSqlLog.WriteInformation(null, "Check the NRIC is exist or not");
                    //Check Exist NRIC before save new data
                    var nricData = _userService.CheckNRIC(userModel.NRIC);
                    HelperStoreSqlLog.WriteInformation(null, "End check the NRIC");
                    if (!nricData)
                    {
                        var id = Guid.NewGuid();
                        var user = _mapper.Map<User>(userModel);
                        user.UserId = id;
                        user.Subjects = userModel.Subjects.Where(m => m.IsChecked).Select(m => new UserSubject
                        {
                            Id = Guid.NewGuid(),
                            SubjectId = m.Id,
                            UserId = id
                        });

                        HelperStoreSqlLog.WriteInformation(null, "Start to create new User");
                        _userService.CreateUser(user);
                        HelperStoreSqlLog.WriteInformation(null, "End create new user");
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError(Const.NRIC, Const.NRICExist);
                }
                return PartialView("Partial/_Register", userModel);
            }
            catch (Exception ex)
            {
                HelperStoreSqlLog.WriteError(ex, ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UserModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Gender))
                {
                    ModelState.AddModelError(Const.Gender, Const.GenderRequired);
                }
                if (ModelState.IsValid)
                {
                    var subjects = model.Subjects.Where(m => m.IsChecked).Select(m => new UserSubject
                    {
                        Id = Guid.NewGuid(),
                        SubjectId = m.Id,
                        UserId = model.UserId
                    });

                    HelperStoreSqlLog.WriteInformation(null, "Start Update existing user");
                    var user = _mapper.Map<User>(model);
                    user.Subjects = subjects;
                    var result = _userService.UpdateUser(user);
                    HelperStoreSqlLog.WriteInformation(null, "End update user");
                    if (!result.IsError)
                    {
                        return RedirectToAction("Index");
                    }

                    ModelState.AddModelError(result.Element, result.ErrorContent);
                }
                return PartialView("Partial/_Register", model);
            }
            catch (Exception ex)
            {
                HelperStoreSqlLog.WriteError(ex, ex.Message);
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region Json Method
        [HttpPost]
        public JsonResult GetUsers(DataTableAjaxPostModel model)
        {
            HelperStoreSqlLog.WriteInformation(null, "Start get all Register User");
            try
            {
                var data = _userService.GetUsers(model, out int filteredResultsCount, out int totalResultsCount);

                var result = _mapper.Map<List<UserViewModel>>(data);
                int i = 1;
                foreach (var item in result)
                {
                    item.SN = model.start + i;
                    i++;
                }

                return Json(new
                {
                    // this is what datatables wants sending back
                    draw = model.draw,
                    recordsTotal = totalResultsCount,
                    recordsFiltered = filteredResultsCount,
                    data = result
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                HelperStoreSqlLog.WriteError(ex, ex.Message);
                return null;
            }
        }
        #endregion

        #region Help Method
        private UserModel ConvertModel(User user, UserModel userModel)
        {
            var subjects = userModel.Subjects;
            foreach (var item in subjects)
            {
                if (user.Subjects.Any(m => m.SubjectId == item.Id))
                {
                    item.IsChecked = true;
                }
            }

            userModel = _mapper.Map<UserModel>(user);
            userModel.Subjects = subjects;
            userModel.IsEdit = true;

            return userModel;
        }

        #endregion
    }
}