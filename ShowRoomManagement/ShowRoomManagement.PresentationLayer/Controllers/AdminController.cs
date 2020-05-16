using ShowRoomManagement.EntityLayer;
using ShowRoomManagement.ExceptionLayer;
using ShowRoomManagement.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShowRoomManagement.PresentationLayer.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private IModelManager _modelManager;
        // GET: Admin
        public AdminController()
        {
            this._modelManager = new ModelManager();
        }
        public AdminController(IModelManager modelManager)
        {
            this._modelManager = modelManager;
        }


      [HttpGet]
        public  ActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddBrand(BrandModel brandModel)
        {
            if (brandModel != null)
            {
                try
                {
                    await _modelManager.AddBrand(brandModel);
                    TempData["message"] = "Brand Added!!!";
                    return RedirectToAction("AddBrand");
                }
                catch (BrandNameAlreadyPresent e)
                {
                    TempData["message"] = e.Message;
                    return View("AddBrand");
                }
            }
            else
            {
                return View ("Null");
            }
        }

        [HttpGet]
        public async Task<ActionResult> AddBike()
        {
            List<BrandModel> brandModels = new List<BrandModel>();
            brandModels = await _modelManager.GetBrands();
            return View(brandModels);
        }
        [HttpPost]
        public async Task<ActionResult> AddBike(BikeModel bikeModel)
        {
            if (bikeModel != null)
            {
                await _modelManager.AddBike(bikeModel);
                TempData["message"] = "Bike Added!!!";
                return RedirectToAction("AddBike");
            }
            else
            {
                return View("null");
            }
        }

        public async Task<ActionResult> GetBike()
        {
            List<BikeModel> bikeModels = new List<BikeModel>();
            bikeModels = await _modelManager.GetBike();
            return View(bikeModels);
        }

        public async Task<ActionResult> DeleteBike(int BikeId)
        {
            if (BikeId != 0)
            {
                await _modelManager.DeleteBike(BikeId);
                return RedirectToAction("GetBike");
            }
            else
            {
                return RedirectToAction("null");
            }
        }

        [HttpGet]
        public async Task<ActionResult> UpdateBike(int BikeId)
        {
            if (BikeId != 0)
            {

           
            BikeModel bikeModel = await _modelManager.GetUpdate(BikeId);
                if (bikeModel == null) { return RedirectToAction("GetBikes"); }
                else
                {
                    return View(bikeModel);
                }
           
            }
            else
            {
                return RedirectToAction("GetBikes");
            }
        }
        [HttpPost]
        public async Task<ActionResult> UpdateBike(BikeModel bikeModel)
        {
            await _modelManager.UpdateBike(bikeModel);
            return RedirectToAction("GetBike");
        }
    }
}