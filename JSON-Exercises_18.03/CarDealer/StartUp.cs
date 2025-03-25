using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext carDbContext = new CarDealerContext();
            //carDbContext.Database.Migrate();
            //Console.WriteLine("Database migrarted successfully!");
            string jsonString = File.ReadAllText(@"../../../Datasets/customers.json");
            string result = ImportCustomers(carDbContext, jsonString);
            Console.WriteLine(result);
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;
            ImportSupplierDto[]? supplierDtos 
                = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);
            if (supplierDtos != null)
            {
                ICollection<Supplier> validSuppliers = new HashSet<Supplier>();
                foreach (ImportSupplierDto supplierDto in supplierDtos)
                {
                    if (!IsValid(supplierDto))
                    {
                        continue;
                    }
                    bool isIsImpoterValid = bool.TryParse(supplierDto.IsImporter, out bool isImporter);
                    if (!isIsImpoterValid)
                    {
                        continue;
                    }
                    Supplier supplier = new Supplier()
                    {
                        Name = supplierDto.Name,
                        IsImporter = isImporter,
                    };
                    validSuppliers.Add(supplier);
                }
                context.Suppliers.AddRange(validSuppliers);
                context.SaveChanges();

                result = $"Successfully imported {validSuppliers.Count}.";
            }
            return result;
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;
            ImportPartDto[]? partDtos 
                = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);
            if (partDtos != null)
            {
                ICollection<Part> validParts = new List<Part>();
                foreach (ImportPartDto partDto in partDtos)
                {
                    if (!IsValid(partDto))
                    {
                        continue;
                    }
                    bool isPriceValid = decimal.TryParse(partDto.Price, out decimal price);
                    bool isQuantityValid = int.TryParse(partDto.Quantity, out int quantity);
                    if ((!isPriceValid) || (!isQuantityValid))
                    {
                        continue;
                    }
                    int? supplierId = null;
                    Supplier? supplier = null;
                    if (partDto.SupplierId != null)
                    {
                        bool isSupplierIdValid = int.TryParse(partDto.SupplierId, out int parsedBuyerId);
                        if (!isSupplierIdValid)
                        {
                            continue;
                        }
                        supplierId = parsedBuyerId;
                        supplier = context.Suppliers.FirstOrDefault(x => x.Id == parsedBuyerId);
                        if (supplier == null) 
                        {
                            continue;
                        }
                        //if (dbUsers.Contains(parsedSupplierId))
                        //{
                        //    continue;
                        //}
                    }
                    Part part = new Part()
                    {
                        Name = partDto.Name,
                        Price = price,
                        Quantity = quantity,
                        SupplierId = supplier!.Id
                    };
                    validParts.Add(part);
                }
                context.Parts.AddRange(validParts);
                context.SaveChanges();

                result = $"Successfully imported {validParts.Count}.";
            }
            return result;
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ImportCarDto[]? carsDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            var cars = new HashSet<Car>();
            var partsCars = new HashSet<PartCar>();

            foreach (var carDto in carsDtos)
            {
                var newCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };
                cars.Add(newCar);

                foreach (var partId in carDto.PartsId)
                {
                    partsCars.Add(new PartCar()
                    {
                        Car = newCar,
                        PartId = partId
                    });
                }
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partsCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;
            ImportCustomerDto[]? customerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);
            if (customerDtos != null)
            {
                ICollection<Customer>validCustomers = new List<Customer>();
                foreach (var customerDto in customerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                       continue;
                    }
                    bool isBirthDateValid = DateTime.TryParse(customerDto.BirthDate, out DateTime birthdate);
                    bool isIsYoungDriverValid = bool.TryParse(customerDto.IsYoungDriver, out bool isYoungDriver);
                    if ((!isBirthDateValid) || (!isIsYoungDriverValid))
                    {
                        continue;
                    }
                    Customer customer = new Customer()
                    {
                        Name = customerDto.Name,
                        BirthDate = birthdate,
                        IsYoungDriver = isYoungDriver
                    };
                    validCustomers.Add(customer);
                }
                context.Customers.AddRange(validCustomers);
                context.SaveChanges();

                result = $"Successfully imported {validCustomers.Count}.";
            }
            return result;
        }
        //Helper
        private static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validationResults, true);

            return isValid;
        }
    }
}