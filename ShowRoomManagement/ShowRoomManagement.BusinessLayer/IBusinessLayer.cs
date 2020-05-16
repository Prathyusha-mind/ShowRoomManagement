using ShowRoomManagement.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoomManagement.BusinessLayer
{
    public interface IBusinessLayers
    {
        Task AddBrand(Brand brand);
        Task<List<Brand>> GetBrands();
        Task AddBike(Bike bike);
        Task<List<Bike>> GetBike();
        Task DeleteBike(int bikeId);
        Task UpdateBike(Bike bike);
        Task<Bike> GetUpdate(int bikeId);
        Task<List<Bike>> CustomerChoice(string brandName);
        Task AddCustomer(Customer customer);
        Task<Bike> GetBikeDetails(int bikeId);
        double CalculateEmi(double bikePrice, int months);
        Task AddTransaction(Transaction transaction);
        Task<Customer> GetCustomer(string name);
    }
}
