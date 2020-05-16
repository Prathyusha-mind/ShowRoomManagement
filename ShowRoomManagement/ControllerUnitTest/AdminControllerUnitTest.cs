using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShowRoomManagement.PresentationLayer.Controllers;
using ShowRoomManagement.PresentationLayer.Models;
using static System.Collections.Specialized.BitVector32;

namespace ControllerUnitTest
{
    [TestClass]
    public class AdminControllerUnitTest
    {
        [TestMethod]
        public async Task AddBrands_Positive()
        {
            BrandModel brandModel = new BrandModel() { BrandName = "Hero" };
            Mock<IModelManager> mockObject = new Mock<IModelManager>();


            mockObject.Setup(x => x.AddBrand(brandModel));
            var api = new AdminController(mockObject.Object);
            var res = (RedirectToRouteResult)await api.AddBrand(brandModel);
            Assert.AreEqual(res.RouteValues["action"], "AddBrand");
        }

        [TestMethod]
        public async Task AddBrands_NullTest()
        {
            BrandModel brandModel = new BrandModel() { BrandName = "Hero" };
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            brandModel = null;

            mockObject.Setup(x => x.AddBrand(brandModel));
            var api = new AdminController(mockObject.Object);
            var res = api.AddBrand(brandModel);

            var response = await res as ViewResult;

            Assert.AreEqual(response.ViewName, "Null");
        }

        [TestMethod]
        public async Task AddBrands_NegativeTest()
        {
            BrandModel brandModel = new BrandModel() { BrandName = "Hero" };
            Mock<IModelManager> mockObject = new Mock<IModelManager>();


            mockObject.Setup(x => x.AddBrand(brandModel));
            var api = new AdminController(mockObject.Object);
            var res = (RedirectToRouteResult)await api.AddBrand(brandModel);
            Assert.AreNotEqual(res.RouteValues["action"], "Brand");
        }


        [TestMethod]
        public async Task AddBike_PositiveTest()
        {
            BikeModel bikeModel = new BikeModel();
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            mockObject.Setup(x => x.AddBike(bikeModel));
            var api = new AdminController(mockObject.Object);
            var res = (RedirectToRouteResult)await api.AddBike(bikeModel);
            Assert.AreEqual(res.RouteValues["action"], "AddBike");
            
        }

        [TestMethod]
        public async Task AddBike_NullTest()
        {
            BikeModel bikeModel = new BikeModel() { BikeName = "Hero" };
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            bikeModel = null;

            mockObject.Setup(x => x.AddBike(bikeModel));
            var api = new AdminController(mockObject.Object);
            var res = api.AddBike(bikeModel);

            var response = await res as ViewResult;

            Assert.AreEqual(response.ViewName, "null");
        }
        [TestMethod]

        public async Task AddBike_NegativeTest()
        {
            BikeModel bikeModel = new BikeModel() { BikeName = "Hero" };
            Mock<IModelManager> mockObject = new Mock<IModelManager>();


            mockObject.Setup(x => x.AddBike(bikeModel));
            var api = new AdminController(mockObject.Object);
            var res = (RedirectToRouteResult)await api.AddBike(bikeModel);
            Assert.AreNotEqual(res.RouteValues["action"], "Brand");
        }
        [TestMethod]

        public async Task GetBike_PositiveTest()
        {
            BikeModel bikeModel = new BikeModel()
            {

                BikeId = 1,
                BikeName = "HeroPro",
                BikeCC = 110,
                Milage = 40,
                BikePrice = 23568
            };
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            mockObject.Setup(x => x.GetBike()).ReturnsAsync(new List<BikeModel>()
            {
                 new BikeModel
                {
                    BikeId=1,
                    BikeName="HeroPro",
                    BikeCC=110,
                    Milage=40,
                    BikePrice=23568
                }
            });
            AdminController adminController = new AdminController(mockObject.Object);
            var actionResult = await adminController.GetBike() as ViewResult;
            var Bikes = (IEnumerable<BikeModel>)actionResult.Model;
            foreach (BikeModel item in Bikes)
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

        public async Task GetBike_NullTest()
        {
            List<BikeModel> bikeModels = new List<BikeModel>();
            bikeModels = null;
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            mockObject.Setup(x => x.GetBike()).ReturnsAsync(new
                List<BikeModel>());
            var api = new AdminController(mockObject.Object);
            var res = api.GetBike();
            var responce = await res as ViewResult;
            Assert.IsNotNull(responce.Model);
        }

        [TestMethod]
        public async Task GetBike_NegativeTest()
        {
            BikeModel bikeModel = new BikeModel()
            {

                BikeId = 1,
                BikeName = "HeroPro",
                BikeCC = 110,
                Milage = 40,
                BikePrice = 23568
            };
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            mockObject.Setup(x => x.GetBike()).ReturnsAsync(new List<BikeModel>()
            {
                 new BikeModel
                {
                    BikeId=1,
                    BikeName="HeroPro",
                    BikeCC=110,
                    Milage=40,
                    BikePrice=23568
                },
                 new BikeModel
                {
                    BikeId=2,
                    BikeName="HeroPr",
                    BikeCC=120,
                    Milage=40,
                    BikePrice=23568
                }
            });
            AdminController adminController = new AdminController(mockObject.Object);
            var responce = await adminController.GetBike() as ViewResult;
            var list = responce.Model as List<BikeModel>;
            Assert.AreNotEqual(list.Count, 1);
        }

        [TestMethod]

        public async Task DeleteBike_PositiveTest()
        {
            BikeModel bikeModel = new BikeModel();
            bikeModel.BikeId = 1;
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            AdminController adminController = new AdminController(mockObject.Object);
            mockObject.Setup(x => x.DeleteBike(1));
            var status = adminController.DeleteBike(1);
            var res = (RedirectToRouteResult)await adminController.DeleteBike(1);
            Assert.AreEqual(res.RouteValues["action"], "GetBike");



        }

        [TestMethod]

        public async Task DeleteBike_NullTest()
        {
            BikeModel bikeModel = new BikeModel();
            bikeModel.BikeId = 0;
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            AdminController adminController = new AdminController(mockObject.Object);
            mockObject.Setup(x => x.DeleteBike(0));
            var status = adminController.DeleteBike(0);
            var res = (RedirectToRouteResult)await adminController.DeleteBike(0);
            Assert.AreEqual(res.RouteValues["action"], "null");



        }

        [TestMethod]

        public async Task DeleteBike_NegativeTest()
        {
            BikeModel bikeModel = new BikeModel();
            bikeModel.BikeId = -1;
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            AdminController adminController = new AdminController(mockObject.Object);
            mockObject.Setup(x => x.DeleteBike(-1));
            var status = adminController.DeleteBike(-1);
            var res = (RedirectToRouteResult)await adminController.DeleteBike(0);
            Assert.AreNotEqual(res.RouteValues["action"], "GetBike");



        }

        [TestMethod]

        public async Task UpdateBike_PositiveTest()
        {
            int id = 1;
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            mockObject.Setup(x => x.GetUpdate(id)).ReturnsAsync(
                new BikeModel
                {
                    BikeId = 1,
                    BikeName = "HeroPro",
                    BikeCC = 110,
                    Milage = 40,
                    BikePrice = 23568

                }
            );
            AdminController adminController = new AdminController(mockObject.Object);
            var actionResult = await adminController.UpdateBike(id) as ViewResult;
            var Bikes = (BikeModel)actionResult.Model;
            Assert.AreEqual(Bikes.BikeId, id);
        }

        [TestMethod]
        public async Task UpdateBike_NegativeTest()
        {
            int id = 0;
            BikeModel bikeModel = new BikeModel
            {
                BikeId = 1,
                BikeName = "HeroPro",
                BikeCC = 110,
                Milage = 40,
                BikePrice = 23568
            };
         
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            mockObject.Setup(x => x.GetUpdate(id)).ReturnsAsync(bikeModel);
            AdminController adminController = new AdminController(mockObject.Object);
            var actionResult = adminController.UpdateBike(id);
            var Bikes = (RedirectToRouteResult)await actionResult;
            Assert.AreEqual(Bikes.RouteValues["action"], "GetBikes");
        }
        [TestMethod]
        public async Task UpdateBike_NullTest()
        {
            int id = 1;
            BikeModel bikeModel = new BikeModel();
            bikeModel = null;
            Mock<IModelManager> mockObject = new Mock<IModelManager>();
            mockObject.Setup(x => x.GetUpdate(id)).ReturnsAsync(bikeModel);
            AdminController adminController = new AdminController(mockObject.Object);
            var actionResult = adminController.UpdateBike(id);
            var Bikes = (RedirectToRouteResult)await actionResult;
            Assert.AreEqual(Bikes.RouteValues["action"], "GetBikes");
        }

      
    }
}
