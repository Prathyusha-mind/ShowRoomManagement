using ShowRoomManagement.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShowRoomManagement.PresentationLayer.Controllers
{
    [Authorize(Roles ="Customer")]
    public class CustomerController : Controller
    {


        private IModelManager _modelManager;
        // GET: Admin
        public CustomerController()
        {
            this._modelManager = new ModelManager();
        }
        public CustomerController(IModelManager modelManager)
        {
            this._modelManager = modelManager;
        }
        // GET: Customer

        //public ActionResult AddCustomer()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult AddCustomer(CustomerModel customerModel)
        //{
        //    _modelManager.AddCustomer(customerModel);
        //    TempData["message"] = "Customer Added!!!";
        //    return View("AddCustomer");
        //}

        public async Task<ActionResult> CustomerIndex()
        {
            List<BrandModel> brandModels = new List<BrandModel>();
            brandModels = await _modelManager.GetBrands();
            if (brandModels == null) { return View("Null"); }
            else
            {
                return View(brandModels);
            }
        }
        public async Task<ActionResult> CustomerChoice(string BrandName)
        {
            if (BrandName == "")
            {
                return RedirectToAction("CustomerChoice");
            }
            else
            {
                List<BikeModel> bikeModels = new List<BikeModel>();
                bikeModels = await _modelManager.CustomerChoice(BrandName);
                if (bikeModels == null) { return View("null"); }
                else
                {
                    return View(bikeModels);
                }
            }
        }

        public async Task<ActionResult> FullPurchase(int bikeId)
        {

            BikeModel bikeModel = await _modelManager.GetBikeDetails(bikeId);
            var customerModel = await  _modelManager.GetCustomer(User.Identity.Name);
            TransactionModel transactionModel = new TransactionModel
            {
                CustomerId = customerModel.CustomerId,
                BikeId = bikeId,
                BikePrice = bikeModel.BikePrice
                

            };
            // TempData.Keep("CustumerId");
            ViewBag.Customer = customerModel;
            ViewBag.transc = bikeModel;
            await _modelManager.AddTransaction(transactionModel);
            return View();
        }
        public  ActionResult PurchaseByEMI(int bikeId)
        {

            TempData["id"] = bikeId;
            ViewBag.EMI = TempData["EMI"];

            return View();
        }

        public async Task<ActionResult> EMICalculate(int months)
        {
            
            int bikeId = (int)TempData["id"];
            BikeModel bikeModel = await _modelManager.GetBikeDetails(bikeId);
            double emi = _modelManager.CalculateEmi(bikeModel.BikePrice, months);
            TempData["Months"] = months;
            TempData["EMI"] = emi;
            return RedirectToAction("PurchaseByEMI", new { bikeId = bikeId });
               
        }
        public async Task<ActionResult> PurchaseEMI()
        {

            int bikeId = (int)TempData["id"];
            int months = (int)TempData["Months"];
            var customerModel = await _modelManager.GetCustomer(User.Identity.Name);
            BikeModel bikeModel = await _modelManager.GetBikeDetails(bikeId);
            double emi =  _modelManager.CalculateEmi(bikeModel.BikePrice, months);
            TransactionModel transactionModel = new TransactionModel
            {
               CustomerId=customerModel.CustomerId,
              
                BikeId = bikeId,
                BikePrice = bikeModel.BikePrice,
                EMIMonths = months,
                EMI = emi
            };
            ViewBag.Customer = customerModel;
            ViewBag.EMI = emi;
            ViewBag.Months = months;
            await _modelManager.AddTransaction(transactionModel);
            return View(bikeModel);
        }

        public ActionResult Paymentcancel()
        {
            return View();

        }

    }
}