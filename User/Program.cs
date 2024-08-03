using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace User
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetailDto().Data)
            {
                Console.WriteLine(car.ModelYear + "Model/" + car.BrandName + "/" + car.CarModel + "/" + car.ColorName + "Renk/" );

            }







            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);

            //}

            // Console.WriteLine(carManager.GetById(1).CarName);
            //carManager.Add(new Entities.Concrete.Car { BrandId = 3, Description = "a" , DailyPrice= 3000, ModelYear=2002, ColorId=3});  araba ekleme

        } 
    }
}