using GymManagementSystem.App.Interfaces;
using GymManagementSystem.Data.Entities;
using GymManagementSystem.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GymManagementSystem.App.Constants;
using System.Linq.Expressions;
using Presentation.Areas.Admin.Models.UsersViewModels;

namespace Presantation.Areas.Admin.Controllers
{

    [Area(AreasConstants.Admin)]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IRolesRepository rolesRepository;
        private readonly ILogger _logger;

        public UsersController(IUserRepository userRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IRolesRepository rolesRepository, ILogger<UsersController> logger)
        {
            this.userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.rolesRepository = rolesRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new UserViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var model = new UserViewModel();
            model.Id = id;
            return View("Add",model);
        }

        [HttpPost]
       
        public IActionResult Add(UserViewModel model)
        {
            if(ModelState.IsValid)
            {

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetUsersJson()
        {
            var users = userRepository.GetAll();
            //users.ForEach(x => x.PasswordHash = userRepository.GetProfilePicturePath(x.Id, (int)ThumbnailsEnum.Grid));

            try
            {
                var result = users.Select(x => new
                {
                    id = x.Id,
                    name = x.Name,
                    surname = x.Surname,
                    email = x.Email,
                    EmailConfirmed = x.EmailConfirmed
                });

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    await _userManager.DeleteAsync(user);
                }
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
