using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowRoomManagement.EntityLayer;

namespace ShowRoomManagement.DataLayer
{
    public interface IDataLayers
    {
        Task AddBrand(Brand brand);
        Task<List<Brand>> CheckBrand();
        Task AddBike(Bike bike);
        Task<List<Bike>> GetBike();
        Task DeleteBike(int bikeId);
        Task UpdateBike(Bike bike);
        Task<Bike> GetUpdate(int bikeId);
        Task<List<Bike>> CustomerChoice(string brandName);
        Task AddCustomer(Customer customer);
        Task<Bike> GetBikeDetails(int bikeId);
        Task AddTransaction(Transaction transaction);
        Task<Customer> GetCustomer(string name);
    }
}
