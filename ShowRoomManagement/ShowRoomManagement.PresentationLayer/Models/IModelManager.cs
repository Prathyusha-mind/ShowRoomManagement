using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShowRoomManagement.PresentationLayer.Models
{
    public interface IModelManager
    {
        Task AddBrand(BrandModel brandModel);
        Task<List<BrandModel>> GetBrands();
        Task AddBike(BikeModel bikeModel);
        Task<List<BikeModel>> GetBike();
        Task DeleteBike(int bikeId);
        Task<BikeModel> GetUpdate(int bikeId);
        Task UpdateBike(BikeModel bikeModel);
        Task AddCustomer(CustomerModel customerModel);
        Task< List<BikeModel>> CustomerChoice(string brandName);
        Task<BikeModel> GetBikeDetails(int bikeId);
        double CalculateEmi(double bikePrice, int months);
        Task AddTransaction(TransactionModel transactionModel);
        Task<CustomerModel> GetCustomer(string name);
    }
}
