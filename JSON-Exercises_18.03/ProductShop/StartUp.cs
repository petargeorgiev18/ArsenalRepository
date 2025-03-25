using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();
            //context.Database.Migrate();
            //Console.WriteLine("Database migration successful!");
            //string jsonString = File.ReadAllText(@"../../../Datasets/categories-products.json");
            string result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportUserDto[]? userDtos = JsonConvert
                .DeserializeObject<ImportUserDto[]>(inputJson);
            if (userDtos != null)
            {
                ICollection<User> usersToAdd = new List<User>();
                foreach (ImportUserDto userDto in userDtos)
                {
                    if (!IsValid(userDto))
                    {
                        continue;
                    }

                    int? userAge = null;
                    if (userDto.Age != null)
                    {
                        bool isAgeValid = int.TryParse(userDto.Age, out int parsedAge);
                        if (!isAgeValid)
                        {
                            continue;
                        }

                        userAge = parsedAge;
                    }

                    User user = new User()
                    {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Age = userAge
                    };

                    usersToAdd.Add(user);
                }

                context.Users.AddRange(usersToAdd);
                context.SaveChanges();

                result = $"Successfully imported {usersToAdd.Count}";
            }

            return result;
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;
            ImportProductDto[]? productsDtos = JsonConvert.DeserializeObject<ImportProductDto[]>
                (inputJson);
            if (productsDtos != null)
            {
                ICollection<Product> validProducts = new List<Product>();
                ICollection<int> dbUsers = context.Users
                    .Select(x => x.Id).ToArray();
                foreach (ImportProductDto productDto in productsDtos)
                {
                    if (!IsValid(productDto))
                    {
                        continue;
                    }
                    bool isPriceValid = decimal.TryParse(productDto.Price, out decimal price);
                    bool isSellerIdValid = int.TryParse(productDto.SellerId, out int sellerId);
                    if ((!isPriceValid) || (!isSellerIdValid))
                    {
                        continue;
                    }
                    int? buyerId = null;
                    if (productDto.BuyerId != null)
                    {
                        bool isBuyerIdValid = int.TryParse(productDto.BuyerId, out int parsedBuyerId);
                        if (!isBuyerIdValid)
                        {
                            continue;
                        }
                        buyerId = parsedBuyerId;
                        //if (dbUsers.Contains(parsedBuyerId))
                        //{
                        //    continue;
                        //}
                    }
                    //if (!dbUsers.Contains(sellerId))
                    //{
                    //    continue;
                    //}
                    Product product = new Product
                    {
                        Name = productDto.Name,
                        Price = price,
                        SellerId = sellerId,
                        BuyerId = buyerId
                    };
                    validProducts.Add(product);
                }
                context.Products.AddRange(validProducts);
                context.SaveChanges();

                result = $"Successfully imported {validProducts.Count}";
            }
            return result;
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;
            ImportCategoryDto[]? categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>
                (inputJson);
            if (categoryDtos != null)
            {
                ICollection<Category> validCategories = new List<Category>();
                foreach (ImportCategoryDto categoryDto in categoryDtos)
                {
                    if (!IsValid(categoryDto))
                    {
                        continue;
                    }
                    Category category = new Category
                    {
                        Name = categoryDto.Name!
                    };
                    validCategories.Add(category);
                }
                context.Categories.AddRange(validCategories);
                context.SaveChanges();

                result = $"Successfully imported {validCategories.Count}";
            }
            return result;
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;
            ImportCategoryProductDto[]? categoryProductDtos = JsonConvert.DeserializeObject
                <ImportCategoryProductDto[]>(inputJson);
            if (categoryProductDtos != null)
            {
                ICollection<CategoryProduct> validCategoriesProducts = new List<CategoryProduct>();
                foreach (ImportCategoryProductDto categoryProductDto in categoryProductDtos)
                {
                    if (!IsValid(categoryProductDto))
                    {
                        continue;
                    }
                    bool isCategoryIdValid = int.TryParse(categoryProductDto.CategoryId, out int categoryId);
                    bool isProductIdIdValid = int.TryParse(categoryProductDto.ProductId, out int productId);
                    if ((!isCategoryIdValid) || (!isProductIdIdValid))
                    {
                        continue;
                    }
                    CategoryProduct categoryProduct = new CategoryProduct
                    {
                        CategoryId = categoryId,
                        ProductId = productId
                    };
                    validCategoriesProducts.Add(categoryProduct);
                }
                context.CategoriesProducts.AddRange(validCategoriesProducts);
                context.SaveChanges();

                result = $"Successfully imported {validCategoriesProducts.Count}";
            }
            return result;
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(p => p.Price)
                .ToArray();
            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            string jsonResult = JsonConvert.SerializeObject(products, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = camelCaseResolver
            });
            return jsonResult;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(u => u.ProductsSold.Any(b => b.BuyerId.HasValue))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold.Where(u => u.BuyerId.HasValue)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            BuyerFirstName = p.Buyer!.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName);
            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            string jsonResult = JsonConvert.SerializeObject(soldProducts, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver
            });
            return jsonResult;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories.Select(ct => new
            {
                Category = ct.Name,
                ProductsCount = ct.CategoriesProducts.Count(),
                AveragePrice = ct.CategoriesProducts.Average(p => p.Product.Price).ToString("F2"),
                TotalRevenue = ct.CategoriesProducts.Sum(p => p.Product.Price).ToString("F2")
            })
            .OrderByDescending(ct => ct.ProductsCount)
            .ToArray();
            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            string jsonResult = JsonConvert.SerializeObject(categories, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver
            });
            return jsonResult;
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count(p => p.BuyerId.HasValue),
                        Products = u.ProductsSold
                        .Where(p => p.BuyerId.HasValue)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                        .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToArray();
            var usersCount = new
            {
                UsersCount = usersWithSoldProducts.Length,
                Users = usersWithSoldProducts
            };
            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            };
            string jsonResult = JsonConvert.SerializeObject(usersCount, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver,
                NullValueHandling = NullValueHandling.Ignore
            });
            return jsonResult;
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