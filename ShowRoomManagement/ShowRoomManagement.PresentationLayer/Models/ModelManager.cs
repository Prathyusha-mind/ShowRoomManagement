using ShowRoomManagement.BusinessLayer;
using ShowRoomManagement.EntityLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShowRoomManagement.PresentationLayer.Models
{
    public class ModelManager : IModelManager
    {
        IBusinessLayers business = new BusinessLayers();
        public  async Task AddBrand(BrandModel brandModel)
        {
            Brand brand = new Brand();
            brand.BrandName = brandModel.BrandName;
            await business.AddBrand(brand);

        }

        public async Task<List<BrandModel>> GetBrands()
        {
            List<Brand> brandlist = await business.GetBrands();
            List<BrandModel> brandModels = new List<BrandModel>();
            foreach (Brand i in brandlist)
            {
                BrandModel brandModel = new BrandModel();
                brandModel.BrandName = i.BrandName;
                brandModels.Add(brandModel);
            }
            return brandModels;
        }

        public async Task<List<BikeModel>> CustomerChoice(string brandName)
        {

            List<BikeModel> bikeModels = new List<BikeModel>();
            List<Bike> bikes = await business.CustomerChoice(brandName);
            foreach (Bike bike in bikes)
            {
                BikeModel bikeModel = new BikeModel();
                bikeModel.BikeId = bike.BikeId;
                bikeModel.BikeName = bike.BikeName;
                bikeModel.BikePrice = bike.BikePrice;
                bikeModel.DiscBrakes = bike.DiscBrakes;
                bikeModel.BikeCC = bike.BikeCC;
                bikeModel.Milage = bike.Milage;
                bikeModel.BikeImages = bike.BikeImages;
                bikeModels.Add(bikeModel);
            }
            return bikeModels;
        }

        public async Task<BikeModel> GetBikeDetails(int bikeId)
        {
            BikeModel bikeModel = new BikeModel();
            Bike bike = await business.GetBikeDetails(bikeId);
            bikeModel.BikeId = bike.BikeId;
            bikeModel.BikeName = bike.BikeName;
            bikeModel.BikePrice = bike.BikePrice;
            bikeModel.DiscBrakes = bike.DiscBrakes;
            bikeModel.Milage = bike.Milage;
            return bikeModel;
        }


        public async Task AddCustomer (CustomerModel customerModel)
        {
            Customer customer = new Customer();
            customer.CustomerId = customerModel.CustomerId;
            customer.CustomerName = customerModel.CustomerName;
            customer.PhoneNumber = customerModel.PhoneNumber;
            customer.Email = customerModel.Email;
            customer.Address = customerModel.Address;

            await business.AddCustomer(customer);
        }

        public double CalculateEmi(double bikePrice, int months)
        {
            return business.CalculateEmi(bikePrice, months);
        }

        public async Task AddBike(BikeModel bikeModel)
        {
            int filesizeofBytes = bikeModel.File.ContentLength;
            MemoryStream memoryStream = new MemoryStream();
            bikeModel.File.InputStream.CopyTo(memoryStream);

            Bike bike = new Bike();
            bike.BikeName = bikeModel.BikeName;
            bike.BikePrice = bikeModel.BikePrice;
            bike.DiscBrakes = bikeModel.DiscBrakes;
            bike.BikeCC = bikeModel.BikeCC;
            bike.Milage = bikeModel.Milage;
            bike.BrandName = bikeModel.BrandName;
            bike.BikeImages = memoryStream.ToArray();
            await business.AddBike(bike);

        }

        public async Task<List<BikeModel>> GetBike()
        {
            List<Bike> bikes = await business.GetBike();
            List<BikeModel> bikeModels = new List<BikeModel>();
            foreach (var i in bikes)
            {
                BikeModel bikeModel = new BikeModel();
                bikeModel.BikeId = i.BikeId;
                bikeModel.BikeName = i.BikeName;
                bikeModel.BrandName = i.BrandName;
                bikeModel.BikePrice = i.BikePrice;
                bikeModel.DiscBrakes = i.DiscBrakes;
                bikeModel.BikeCC = i.BikeCC;
                bikeModel.Milage = i.Milage;
                bikeModel.BikeImages = i.BikeImages;
                bikeModels.Add(bikeModel);
            }
            return bikeModels;
        }

        public async Task DeleteBike(int bikeId)
        {
            await business.DeleteBike(bikeId);
        }

        public async Task<BikeModel> GetUpdate(int bikeId)
        {
            Bike bike = await business.GetUpdate(bikeId);
            BikeModel bikeModel = new BikeModel();
            bikeModel.BikeId = bike.BikeId;
            bikeModel.BikeName = bike.BikeName;
            bikeModel.BikeImages = bike.BikeImages;
            bikeModel.BikePrice = bike.BikePrice;
            bikeModel.BikeCC = bike.BikeCC;
            bikeModel.DiscBrakes = bike.DiscBrakes;
            bikeModel.Milage = bike.Milage;
            return bikeModel;
        }

        public async  Task UpdateBike(BikeModel bikeModel)
        {
            int filesizeofBytes = bikeModel.File.ContentLength;
            MemoryStream memoryStream = new MemoryStream();
            bikeModel.File.InputStream.CopyTo(memoryStream);

            Bike bike = new Bike();
            bike.BikeId = bikeModel.BikeId;
            bike.BikeName = bikeModel.BikeName;
            bike.BikePrice = bikeModel.BikePrice;
            bike.BikeCC = bikeModel.BikeCC;
            bikeModel.BikeImages = memoryStream.ToArray();
            bike.DiscBrakes = bikeModel.DiscBrakes;
            bike.Milage = bikeModel.Milage;
            await business.UpdateBike(bike);
        }

        public async Task  AddTransaction(TransactionModel transactionModel)
        {
            Transaction transaction = new Transaction();
            transaction.BikeId = transactionModel.BikeId;
            transaction.EMI = transactionModel.EMI;
            transaction.EMIMonths = transactionModel.EMIMonths;
            transaction.BikePrice = transactionModel.BikePrice;
            transaction.CustomerId = transactionModel.CustomerId;
            await business.AddTransaction(transaction);
        }

        public async Task<CustomerModel> GetCustomer(string name)
        {
            Customer customer = await business.GetCustomer(name);
            CustomerModel customerModel = new CustomerModel();
            customerModel.CustomerId = customer.CustomerId;
            customerModel.CustomerName = customer.CustomerName;
            customerModel.Address = customer.Address;
            customerModel.PhoneNumber = customer.PhoneNumber;
            customerModel.Email = customer.Email;
            return customerModel;
        }
    }
}