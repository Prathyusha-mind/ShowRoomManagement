using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowRoomManagement.DataLayer;
using ShowRoomManagement.EntityLayer;
using ShowRoomManagement.ExceptionLayer;

namespace ShowRoomManagement.BusinessLayer
{
    public class BusinessLayers : IBusinessLayers
    {
        IDataLayers dataLayer = new DataLayers();

        public async Task AddBike(Bike bike)
        {
            await dataLayer.AddBike(bike);
        }

        public async Task AddBrand(Brand brand)
        {
            int flag = await ValidateBrandName(brand);
            if (flag == 0)
            {
                await dataLayer.AddBrand(brand);
            }
            else
            {
                throw new BrandNameAlreadyPresent("BrandName already present");
            }
        }

        public async Task AddCustomer(Customer customer)
        {
            await dataLayer.AddCustomer(customer);
        }

        public async Task AddTransaction(Transaction transaction)
        {
            await dataLayer.AddTransaction(transaction);
        }

        public double CalculateEmi(double bikePrice, int months)
        {
            double rate = 0.2;
            double emi = (bikePrice * rate * (Math.Pow(1 + rate, months))) / ((Math.Pow(1 + rate, months)) - 1);
            return emi;
        }

        public async Task<List<Bike>> CustomerChoice(string brandName)
        {
            List<Bike> bikes = await dataLayer.CustomerChoice(brandName);
            return bikes;
        }

        public async Task DeleteBike(int bikeId)
        {
            await dataLayer.DeleteBike(bikeId);
        }

        public async Task<List<Bike>> GetBike()
        {
            List<Bike> bikes = await dataLayer.GetBike();
            return bikes;
        }

        public async Task<Bike> GetBikeDetails(int bikeId)
        {
            Bike bike = await dataLayer.GetBikeDetails(bikeId);
            return bike;
        }

        public async Task<List<Brand>> GetBrands()
        {
            List<Brand> brands = await dataLayer.CheckBrand();
            return brands;
        }

        public async Task<Customer> GetCustomer(string name)
        {
            Customer customer=await dataLayer.GetCustomer(name);
            return customer;
        }

        public async Task<Bike> GetUpdate(int bikeId)
        {

            Bike bike = await dataLayer.GetUpdate(bikeId);
            return bike;
        }

        public async Task UpdateBike(Bike bike)
        {
            await dataLayer.UpdateBike(bike);
        }

        public async Task<int> ValidateBrandName(Brand brand)
        {
            List<Brand> brandlist = new List<Brand>();
            int count = 0;
            brandlist = await dataLayer.CheckBrand();
            foreach (var i in brandlist)
            {
                if (brand.BrandName.Equals(i.BrandName))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
