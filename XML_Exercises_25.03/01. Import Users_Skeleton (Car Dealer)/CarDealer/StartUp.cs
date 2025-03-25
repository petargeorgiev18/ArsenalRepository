using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.Models;
using CarDealer.Utilities;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();
            //context.Database.Migrate();
            //Console.WriteLine("Database migrated successfully!");
            //string xmlFile = File.ReadAllText("../../../Datasets/sales.xml");
            string result = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(result);
        }
        //public static string ImportSuppliers(CarDealerContext context, string inputXml)
        //{
        //    string result = string.Empty;
        //    ImportSupplierDto[]? supplierDtos =
        //        XmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");
        //    if (supplierDtos != null)
        //    {
        //        ICollection<Supplier> validSuppliers = new List<Supplier>();
        //        foreach (ImportSupplierDto supplierDto in supplierDtos)
        //        {
        //            if (!IsValid(supplierDto))
        //            {
        //                continue;
        //            }
        //            bool isImporterValid = bool.TryParse(supplierDto.IsImporter, out bool isImporter);
        //            if (!isImporterValid)
        //            {
        //                continue;
        //            }
        //            Supplier supplier = new Supplier()
        //            {
        //                Name = supplierDto.Name,
        //                IsImporter = isImporter
        //            };
        //            validSuppliers.Add(supplier);
        //        }
        //        context.Suppliers.AddRange(validSuppliers);
        //        context.SaveChanges();

        //        result = $"Successfully imported {validSuppliers.Count}";
        //    }
        //    return result;
        //}
        //public static string ImportParts(CarDealerContext context, string inputXml)
        //{
        //    string result = string.Empty;
        //    ImportPartDto[]? partDtos = XmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");
        //    if (partDtos != null)
        //    {
        //        ICollection<Part> validParts = new List<Part>();
        //        ICollection<int> supplierIds = context.Suppliers.Select(x => x.Id).ToList();
        //        foreach (ImportPartDto partDto in partDtos)
        //        {
        //            if (!IsValid(partDto))
        //            {
        //                continue;
        //            }
        //            bool isPriceValid = decimal.TryParse(partDto.Price, out decimal price);
        //            bool isQuantityValid = int.TryParse(partDto.Quantity, out int quantity);
        //            bool isSupplierIdValid = int.TryParse(partDto.SupplierId, out int supplierId);
        //            if ((!isPriceValid || (!isQuantityValid) || (!isSupplierIdValid)))
        //            {
        //                continue;
        //            }
        //            if (!supplierIds.Contains(supplierId))
        //            {
        //                continue;
        //            }
        //            Part part = new Part()
        //            {
        //                Name = partDto.Name,
        //                Price = price,
        //                Quantity = quantity,
        //                SupplierId = supplierId
        //            };
        //            validParts.Add(part);
        //        }
        //        context.Parts.AddRange(validParts);
        //        context.SaveChanges();

        //        result = $"Successfully imported {validParts.Count}";
        //    }
        //    return result;
        //}
        //public static string ImportCars(CarDealerContext context, string inputXml)
        //{
        //    string result = string.Empty;
        //    ImportCarDto[]? carDtos = XmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars");
        //    if (carDtos != null)
        //    {
        //        ICollection<int> partsId = context.Parts.Select(x => x.Id).ToList();
        //        ICollection<Car> validCars = new List<Car>();
        //        foreach (ImportCarDto carDto in carDtos)
        //        {
        //            if (!IsValid(carDto))
        //            {
        //                continue;
        //            }
        //            bool isTraveledDistanceValid = long.TryParse
        //                (carDto.TraveledDistance, out long traveledDistance);
        //            if (!isTraveledDistanceValid)
        //            {
        //                continue;
        //            }
        //            Car car = new Car()
        //            {
        //                Make = carDto.Make,
        //                Model = carDto.Model,
        //                TraveledDistance = traveledDistance
        //            };
        //            ICollection<PartCar> validParts = new List<PartCar>();
        //            if (carDto.Parts != null)
        //            {
        //                int[] partIds = carDto.Parts.Where(p => IsValid(p) && int.TryParse(p.Id, out int partId))
        //                    .Select(p => int.Parse(p.Id)).Distinct().ToArray();
        //                foreach (int partId in partIds)
        //                {
        //                    if (!partIds.Contains(partId))
        //                    {
        //                        continue;
        //                    }
        //                    PartCar partCar = new PartCar()
        //                    {
        //                        PartId = partId
        //                    };
        //                    validParts.Add(partCar);
        //                }
        //                car.PartsCars = validParts;
        //            }
        //            validCars.Add(car);
        //        }
        //        context.Cars.AddRange(validCars);
        //        context.SaveChanges();

        //        result = $"Successfully imported {validCars.Count}";
        //    }
        //    return result;
        //}
        //public static string ImportCustomers(CarDealerContext context, string inputXml)
        //{
        //    string result = string.Empty;
        //    ImportCustomerDto[]? customerDtos = XmlHelper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");
        //    if (customerDtos != null)
        //    {
        //        ICollection<Customer> validCustomers = new List<Customer>();
        //        foreach (ImportCustomerDto customerDto in customerDtos)
        //        {
        //            if (!IsValid(customerDto))
        //            {
        //                continue;
        //            }
        //            bool isBirthDateValid = DateTime.TryParse(customerDto.BirthDate.ToString(), out DateTime birthDate);
        //            bool isYoungDriverValid = bool.TryParse(customerDto.IsYoungDriver, out bool isYoungDriver);
        //            if ((!isBirthDateValid) || (!isYoungDriverValid))
        //            {
        //                continue;
        //            }
        //            Customer customer = new Customer()
        //            {
        //                Name = customerDto.Name,
        //                BirthDate = birthDate,
        //                IsYoungDriver = isYoungDriver
        //            };
        //            validCustomers.Add(customer);
        //        }
        //        context.Customers.AddRange(validCustomers);
        //        context.SaveChanges();

        //        result = $"Successfully imported {validCustomers.Count}";
        //    }
        //    return result;
        //}
        //public static string ImportSales(CarDealerContext context, string inputXml)
        //{
        //    string result = string.Empty;
        //    ImportSaleDto[]? saleDtos = XmlHelper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");
        //    if (saleDtos != null)
        //    {
        //        ICollection<int> validCarIds = context.Cars.Select(x => x.Id).ToList();
        //        ICollection<int> validCustomerIds = context.Customers.Select(x => x.Id).ToList();
        //        ICollection<Sale> validSales = new List<Sale>();
        //        foreach (var saleDto in saleDtos)
        //        {
        //            if (!IsValid(saleDto))
        //            {
        //                continue;
        //            }
        //            bool isCarIdValid = int.TryParse(saleDto.CarId, out int carId);
        //            bool isCustomerIdValid = int.TryParse(saleDto.CustomerId, out int customerId);
        //            bool isDiscountValid = decimal.TryParse(saleDto.Discount, out decimal discount);
        //            if ((!isCarIdValid) || (!isCustomerIdValid) || (!isDiscountValid))
        //            {
        //                continue;
        //            }
        //            if (!validCarIds.Contains(carId))
        //            {
        //                continue;
        //            }
        //            Sale sale = new Sale()
        //            {
        //                CarId = carId,
        //                CustomerId = customerId,
        //                Discount = discount
        //            };
        //            validSales.Add(sale);
        //        }
        //        context.Sales.AddRange(validSales);
        //        context.SaveChanges();

        //        result = $"Successfully imported {validSales.Count}";
        //    }
        //    return result;
        //}
        //public static string GetCarsWithDistance(CarDealerContext context)
        //{
        //    var cars = context.Cars.Where(c => c.TraveledDistance > 2_000_000).Select(c => new ExportCarsOverDistanceDto()
        //    {
        //        Make = c.Make,
        //        Model = c.Model,
        //        TraveledDistance = c.TraveledDistance.ToString()
        //    }).OrderBy(c => c.Make).ThenBy(c => c.Model).Take(10).ToArray();
        //    string result = XmlHelper.Serialize(cars, "cars");
        //    return result;
        //}
        //public static string GetCarsFromMakeBmw(CarDealerContext context)
        //{
        //    var cars = context.Cars.Where(c => c.Make == "BMW").Select(c => new ExportCarsFromMakeBMWDto()
        //    {
        //        Id = c.Id.ToString(),
        //        Model = c.Model,
        //        TraveledDistance = c.TraveledDistance.ToString()
        //    }).OrderBy(c => c.Model).ThenByDescending(c => long.Parse(c.TraveledDistance)).ToArray();
        //    string result = XmlHelper.Serialize(cars, "cars");
        //    return result;
        //}
        //public static string GetLocalSuppliers(CarDealerContext context)
        //{
        //    var suppliers = context.Suppliers.Where(s => !s.IsImporter).Select(s => new ExportLocalSuppliersDto()
        //    {
        //        Id = s.Id.ToString(),
        //        Name = s.Name,
        //        PartsCount = s.Parts.Count.ToString()
        //    }).ToArray();
        //    string result = XmlHelper.Serialize(suppliers, "suppliers");
        //    return result;
        //}
        //public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        //{
        //    var cars = context.Cars
        //        .OrderByDescending(c => c.TraveledDistance)
        //        .ThenBy(c => c.Model)
        //        .Select(c => new ExportCarsWithTheirListOfPartsDto()
        //        {
        //            Make = c.Make,
        //            Model = c.Model,
        //            TraveledDistance = c.TraveledDistance.ToString(),
        //            Parts = c
        //                  .PartsCars
        //                  .Select(pc => pc.Part)
        //                  .OrderByDescending(p => p.Price)
        //                  .Select(p => new ExportCarPartDto()
        //                  {
        //                      Name = p.Name,
        //                      Price = p.Price.ToString()
        //                  })
        //                  .ToArray()
        //        })
        //        .Take(5)
        //        .ToArray();
        //    string result = XmlHelper.Serialize(cars, "cars");
        //    return result;
        //}
        //public static string GetTotalSalesByCustomer(CarDealerContext context)
        //{
        //    var customers = context.Customers
        //        .Include(c => c.Sales)
        //        .ThenInclude(s => s.Car)
        //        .ThenInclude(c => c.PartsCars)
        //        .ThenInclude(pc => pc.Part)
        //        .Where(c => c.Sales.Any()) // Only customers who bought at least 1 car
        //        .Select(c => new
        //        {
        //            FullName = c.Name,
        //            BoughtCars = c.Sales.Count,
        //            Sales = c.Sales.Select(s => new
        //            {
        //                s.Car.PartsCars,
        //                IsYoungDriver = s.Customer.IsYoungDriver
        //            })
        //        })
        //        .AsEnumerable() // Switch to in-memory operations
        //        .Select(c => new
        //        {
        //            c.FullName,
        //            c.BoughtCars,
        //            SpentMoney = c.Sales.Sum(s =>
        //                s.PartsCars.Sum(pc => Math.Round(pc.Part.Price * (s.IsYoungDriver ? 0.95m : 1m), 2, MidpointRounding.AwayFromZero)) // Apply 5% discount for young drivers
        //            )
        //        })
        //        .OrderByDescending(c => c.SpentMoney) // Sort by total money spent (descending)
        //        .Select(c => new ExportTotalSalesByCustomerDto
        //        {
        //            FullName = c.FullName,
        //            BoughtCars = c.BoughtCars.ToString(),
        //            SpentMoney = c.SpentMoney.ToString("F2") // Format with 2 decimal places
        //        })
        //        .ToArray();

        //    return XmlHelper.Serialize(customers, "customers");
        //}

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Include(s => s.Car)
                .ThenInclude(c => c.PartsCars)
                .ThenInclude(pc => pc.Part)
                .Include(s => s.Customer)
                .ToList()
                .Select(s => new ExportSalesWithAppliedDiscount
                {
                    Car = new ExportCarsDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance.ToString()
                    },
                    Discount = s.Discount.ToString("0"), // No decimal places (e.g., "30" instead of "30.00")
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("0.00"), // 2 decimal places
                    PriceWithDiscount = Math.Round(
                        s.Car.PartsCars.Sum(pc => pc.Part.Price * (1m - s.Discount / 100m)),
                        3, MidpointRounding.AwayFromZero).ToString("0.000") // 3 decimal places
                })
                .ToArray();

            return XmlHelper.Serialize(sales, "sales");
        }


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