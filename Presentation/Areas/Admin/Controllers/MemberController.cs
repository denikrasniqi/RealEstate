using GymManagementSystem.App.Interfaces;
using GymManagementSystem.Data.Entities;
using GymManagementSystem.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GymManagementSystem.App.Constants;
using System.Linq.Expressions;
using Presentation.Areas.Admin.Models.UsersViewModels;
using Presentation.Areas.Admin.Models.MembersViewModel;

namespace Presentation.Areas.Admin.Controllers
{
    [Area(AreasConstants.Admin)]
    public class MemberController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IRolesRepository rolesRepository;
        private readonly ILogger _logger;
        private readonly ISelectListService selectListService;
        private readonly IMemberRepository memberRepository;
        public MemberController(IUserRepository userRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IRolesRepository rolesRepository, ILogger<MemberController> logger, IMemberRepository memberRepository)
        {
            this.userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.rolesRepository = rolesRepository;
            _logger = logger;
            this.selectListService = selectListService;
            this.memberRepository = memberRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            var model = new MemberViewModel();
            model.Users = new SelectList(selectListService.GetTypesKeysValues(), "Key", "Value", model.UserId);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(MemberViewModel model,UserViewModel usermodel)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.Id))
                {
                    var member = new Antaresimi {UserId =model.UserId, StartDate = Convert.ToDateTime(model.StartDate), Statusi = model.Statusi, Qmimi = Convert.ToInt32(model.Qmimi), Antaresimi1 = model.Antaresimi };
                    memberRepository.Add(member);
                    memberRepository.SaveChanges();

                    return RedirectToAction("Index");
                }
                //else
                //{

                //    var postjob = memberRepository.GetById(model.Id);

                //    if (postjob != null)
                //    {
                //        postjob.Name = model.Name;
                //        postjob.Description = model.Description;
                //        postjob.Email = model.Email;
                //        postjob.Address = model.Address;
                //        postjob.JobTypeId = model.JobTypeId;

                //        postjobrepository.Update(postjob);
                //        postjobrepository.SaveChanges();

                //        return RedirectToAction("Index");

                //    }
                //}
            }

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        //public IActionResult Edit(string id)
        //{
        //    AspNetUser? user = userRepository.GetByStringId(id);
        //    if (user != null)
        //    {
        //        var model = new UserViewModel()
        //        {
        //            Id = id,
        //            Password = "",
        //            ConfirmPassword = "",
        //            Email = user.Email!,
        //            EmailConfirmed = user.EmailConfirmed,
        //            Name = user.Name!,
        //            PhoneNumber = user.PhoneNumber,
        //            PhoneNumberConfirmed = user.PhoneNumberConfirmed,
        //            RoleId = rolesRepository.GetByUserId(user.Id)!.Id,
        //            Surname = user.Surname!,
        //        };

        //        model.Roles = new SelectList(selectListService.GetRolesKeysValues(), "SKey", "Value", model.RoleId);

        //        return View("Add", model);
        //    }
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public IActionResult GetMembersJson()
        {
            var members = memberRepository.GetAll();
            try
            {
                var result = members.Select(x => new
                {
                    id = x.Id,
                    startdate = x.StartDate,
                    status = x.Statusi,
                    price = x.Qmimi,
                    membership = x.Antaresimi1
                });

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
