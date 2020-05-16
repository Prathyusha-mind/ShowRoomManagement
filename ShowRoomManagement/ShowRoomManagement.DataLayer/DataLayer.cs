using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowRoomManagement.EntityLayer;

namespace ShowRoomManagement.DataLayer
{
    public class DataLayers : IDataLayers
    {
        public async Task  AddBike(Bike bike)
        {
            using (ShowRoomDbContext showRoomDbContext = new ShowRoomDbContext())
            {

                showRoomDbContext.Bikes.Add(bike);
                await showRoomDbContext.SaveChangesAsync();
            }

        }

        public async Task AddBrand(Brand brand)
        {
            using (ShowRoomDbContext showRoomDbContext = new ShowRoomDbContext())
            {
                showRoomDbContext.Brands.Add(brand);
                 await showRoomDbContext.SaveChangesAsync();
            }
        }

        public async Task AddCustomer(Customer customer)
        {
            using (ShowRoomDbContext showRoomDbContext = new ShowRoomDbContext())
            {
                showRoomDbContext.Customers.Add(customer);
                await showRoomDbContext.SaveChangesAsync();
            }
        }

        public async Task AddTransaction(Transaction transaction)
        {
            using (ShowRoomDbContext showRoomDbContext = new ShowRoomDbContext())
            {
                showRoomDbContext.Transactions.Add(transaction);
                await showRoomDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Brand>> CheckBrand()
        {
            using (ShowRoomDbContext showRoomDbContext = new ShowRoomDbContext())
            {
                List<Brand> brands = await showRoomDbContext.Brands.ToListAsync();
                return brands;


            }
        }

        public async Task<List<Bike>> CustomerChoice(string brandName)
        {
            using (ShowRoomDbContext showRoomDbContext = new ShowRoomDbContext())
            {
                List<Bike> bikes = await showRoomDbContext.Bikes.Where(x => x.BrandName == brandName).ToListAsync();
                return bikes;
            }
        }

        public async Task DeleteBike(int bikeId)
        {
            using (ShowRoomDbContext showRoomDbContext = new ShowRoomDbContext())
            {
                var d = showRoomDbContext.Bikes.Single(x => x.BikeId == bikeId);
                showRoomDbContext.Bikes.Remove(d);
                await showRoomDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Bike>> GetBike()
        {
            using (ShowRoomDbContext showRoomDbContext = new ShowRoomDbContext())
            {
                List<Bike> bikes = await showRoomDbContext.Bikes.ToListAsync();
                return bikes;
            }
        }

        public async Task<Bike> GetBikeDetails(int bikeId)
        {
            using (ShowRoomDbContext showRoomDbContext = new ShowRoomDbContext())
            {
                Bike bike = showRoomDbContext.Bikes.First(x => x.BikeId == bikeId);
                await showRoomDbContext.SaveChangesAsync();
                return bike;
            }
        }

        public async Task<Customer> GetCustomer(string name)
        {
            using (ShowRoomDbContext showRoomDbContext = new ShowRoomDbContext())
            {
                var nofcustomer = showRoomDbContext.Customers.First(x => x.Email.Equals(name));
                await showRoomDbContext.SaveChangesAsync();
                return nofcustomer;
            }
        }

        public async Task<Bike> GetUpdate(int bikeId)
        {
            using (ShowRoomDbContext showRoomDbContext = new ShowRoomDbContext())
            {
                var bike = showRoomDbContext.Bikes.First(x => x.BikeId == bikeId);
               
                await showRoomDbContext.SaveChangesAsync();
                return bike;
            }

        }

        public async  Task  UpdateBike(Bike bike)
        {
            using (ShowRoomDbContext showRoomDbContext = new ShowRoomDbContext())
            {
                Bike bikeUpdate = showRoomDbContext.Bikes.Find(bike.BikeId);

                bikeUpdate.BikeName = bike.BikeName;
                bikeUpdate.BikeCC = bike.BikeCC;
                bikeUpdate.DiscBrakes = bike.DiscBrakes;
                bikeUpdate.BikePrice = bike.BikePrice;
                bikeUpdate.Milage = bike.Milage;
                await showRoomDbContext.SaveChangesAsync();
            }
        }
    }
}
