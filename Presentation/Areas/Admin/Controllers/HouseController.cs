using GymManagementSystem.App.Constants;
using GymManagementSystem.App.Interfaces;
using GymManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using GymManagementSystem.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Admin.Models.HouseViewModel;

namespace Presentation.Areas.Admin.Controllers
{
    [Area(AreasConstants.Admin)]
    public class HouseController : Controller
    {
        private readonly IHouseRepository _context;
        
        public HouseController(IHouseRepository houseRepository)
        {
            _context = houseRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            var model = new ApartmentViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddAsync(ApartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.Id))
                {
                    var member = new HouseTbl {Type = model.Type, Address = model.Address!, City = model.City, Rooms = Convert.ToInt32(model.Rooms), Kitchens = Convert.ToInt32(model.Kitchens), Bathrooms = Convert.ToInt32(model.Bathrooms), Phonenumber = model.PhoneNumber, Price = Convert.ToInt32(model.Price)};
                    _context.Add(member);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetHousesJson()
        {
            var members = _context.GetAll();
            try
            {
                var result = members.Select(x => new
                {
                    id = x.Id,
                    type = x.Type,
                    address = x.Address,
                    city = x.City,
                    rooms = x.Rooms,
                    kitchens = x.Kitchens,
                    bathrooms = x.Bathrooms,
                    phonenumber = x.Phonenumber,
                    price = x.Price,
                });

                return new JsonResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
