using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShowRoomManagement.PresentationLayer.Controllers;
using ShowRoomManagement.PresentationLayer.Models;

namespace ControllerUnitTest
{
    [TestClass]
    public class CustomerUnitTest
    {
        [TestMethod]
        public async Task CustomerIndex_PositiveTest()
        {
            BrandModel brandModel = new BrandModel()
            {
                BrandName= "Honda"
            };
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            mockObject.Setup(x => x.GetBrands()).ReturnsAsync(new List<BrandModel>()
            {
                new BrandModel
                {
                    BrandName="Honda"
                }
            });
            CustomerController customerController = new CustomerController(mockObject.Object);
            var actionResult = await customerController.CustomerIndex() as ViewResult;
            var models = (IEnumerable<BrandModel>)actionResult.Model;
            foreach(BrandModel item in models)
            {
                Assert.AreEqual(item.BrandName, brandModel.BrandName);
            }
        }

        [TestMethod]

        public async Task CustomerIndex_NegativeTest()
        {
            BrandModel brandModel = new BrandModel()
            {
                BrandName = ""
            };
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            mockObject.Setup(x => x.GetBrands()).ReturnsAsync(new List<BrandModel>()
            {
                new BrandModel
                {
                    BrandName="Hero"
                }
            });
            CustomerController customerController = new CustomerController(mockObject.Object);
            var actionResult = await customerController.CustomerIndex() as ViewResult;
            var brands = (IEnumerable<BrandModel>)actionResult.Model;
            foreach(BrandModel item in brands)
            {
                Assert.AreNotEqual(item.BrandName, brandModel.BrandName);
            }
        }

        [TestMethod]

        public async Task CustomerIndex_NullTest()
        {
            List<BrandModel> brandModels = new List<BrandModel>();
            brandModels = null;
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            mockObject.Setup(x => x.GetBrands()).ReturnsAsync(brandModels);
            CustomerController customerController = new CustomerController(mockObject.Object);
            var actionResult = customerController.CustomerIndex();
            var response = await actionResult as ViewResult;
            Assert.AreEqual(response.ViewName, "Null");
        }

        [TestMethod]

        public async Task CustomerChoice_PositiveTest()
        {
            BikeModel bikeModel = new BikeModel()
            {
                BikeName = "herohonda",
                BikePrice = 1234567,
                DiscBrakes = 2,
                BikeCC = 120,
                Milage = 35
            };
            BrandModel brandModel = new BrandModel()
            {
                BrandName = "hero"
            };

            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            mockObject.Setup(x => x.CustomerChoice(brandModel.BrandName)).ReturnsAsync(new List<BikeModel>()
            {
                new BikeModel
               {
                   BikeName="herohonda",
                   BikePrice=1234567,
                   DiscBrakes=2,
                   BikeCC=120,
                   Milage=35
               }
            });
            CustomerController customerController = new CustomerController(mockObject.Object);
            var actionResult = await customerController.CustomerChoice(brandModel.BrandName) as ViewResult;
            var models = (IEnumerable<BikeModel>)actionResult.Model;
            foreach (BikeModel item in models)
            {
                Assert.AreEqual(item.BikeId, bikeModel.BikeId);
                Assert.AreEqual(item.BikeName, bikeModel.BikeName);
                Assert.AreEqual(item.BikeCC, bikeModel.BikeCC);
                Assert.AreEqual(item.BikePrice, bikeModel.BikePrice);
                Assert.AreEqual(item.DiscBrakes, bikeModel.DiscBrakes);
                Assert.AreEqual(item.Milage, bikeModel.Milage);
            }




        }

        [TestMethod]
        public async Task CustomerChoice_NullTest()
        {
            BrandModel brandModel = new BrandModel()
            {
                BrandName= "null"
            };
            List<BikeModel> bikeModels = new List<BikeModel>();
            bikeModels = null;
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            mockObject.Setup(x => x.CustomerChoice(brandModel.BrandName)).ReturnsAsync(bikeModels);

            CustomerController customerController = new CustomerController(mockObject.Object);
            var actionResult = customerController.CustomerChoice(brandModel.BrandName);
            var response = await actionResult as ViewResult;
            Assert.AreEqual(response.ViewName, "null");
        }

        [TestMethod]
        public async Task CustomerChoice_NegativeTest()
        {
           
            BrandModel brandModel = new BrandModel()
            {
                BrandName = ""
            };
            List<BikeModel> bikeModels=new List<BikeModel>()
            {
                new BikeModel
               {
                    BrandName="",
                   BikeName="herohonda",
                   BikePrice=1234567,
                   DiscBrakes=2,
                   BikeCC=120,
                   Milage=35
               }
            };
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            mockObject.Setup(x => x.CustomerChoice(brandModel.BrandName)).ReturnsAsync(bikeModels);
            CustomerController customerController = new CustomerController(mockObject.Object);
            var actionResult = customerController.CustomerChoice(brandModel.BrandName);
            var brands = (RedirectToRouteResult) await actionResult;
            Assert.AreNotEqual(brands.RouteValues["actionResult"], "CustomerChoice");
        }

        [TestMethod]
        public async Task EMICalculate_PositiveTestcase()
        {
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            mockObject.Setup(x => x.CalculateEmi(It.IsAny<double>(), It.IsAny<int>())).Returns(1234.56);
            BikeModel bikeModel = new BikeModel
            {
                BrandName = "",
                BikeName = "herohonda",
                BikePrice = 1234567,
                DiscBrakes = 2,
                BikeCC = 120,
                Milage = 35
            };
            mockObject.Setup(x => x.GetBikeDetails(It.IsAny<int>())).ReturnsAsync(bikeModel);
            CustomerController customerController = new CustomerController(mockObject.Object);
            customerController.TempData["id"] = 2;
            var response = await customerController.EMICalculate(2);
            var result = response as RedirectToRouteResult;
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            Assert.AreEqual(1234.56, customerController.TempData["EMI"]);
            Assert.AreEqual(result.RouteValues["action"], "PurchaseByEMI");
            
            
        }

        //[TestMethod]
        //public async Task EMICalculate_NullTest()
        //{
        //    Mock<IModelManager> mockObjects = new Mock<IModelManager>();

        //}

    }
}
