 
using CarApp.Core.Domain;

namespace CarApp.Core.ServiceInterface;

public interface ICarService
{
    Task<IEnumerable<Car>> GetAllCarsAsync();
    Task<Car> GetCarByIdAsync(int id);
    Task<Car> CreateCarAsync(Car car);
    Task<Car> UpdateCarAsync(Car car);
    Task<bool> DeleteCarAsync(int id);
}
