﻿using eCommerce.Data;
using eCommerce.Models.ShopItem;
using eCommerce.Models.UserModels;
using eCommerce.Service.Contracts;
using Newtonsoft.Json;

namespace eCommerce.Service.ShopService.CartService
{
    internal class DisplayCartService : IFileRead, IShowContent
    {
        public Dictionary<string, Item> ReadFromFile()
        {
            if (File.Exists(FilePathData.CartDataPath))
            {
                try
                {
                    var jsonData = JsonConvert.DeserializeObject<Dictionary<string, Item>>(File.ReadAllText(FilePathData.CartDataPath));
                    return jsonData;
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("File directory was not found.");
                    return new Dictionary<string, Item>();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File was not found");
                    return new Dictionary<string, Item>();
                }
                catch (Exception)
                {
                    Console.WriteLine("Other important error..Contact the developer.");
                    return new Dictionary<string, Item>();
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public void ShowContent(User currentUser)
        {
            string currUserId = currentUser.UserId.ToString();
            var cartDictionary = ReadFromFile();

            Console.WriteLine($"Users  cart information:");
            Console.WriteLine("Cart items:");
            Console.WriteLine();

            foreach (var item in cartDictionary)
            {
                if (item.Key == currUserId)
                {
                    Console.WriteLine("--------");
                    Console.WriteLine($"Title: {item.Value.ItemName}");
                    Console.WriteLine($"Type: {item.Value.ItemType}");
                    Console.WriteLine($"Price: {item.Value.ItemPrice}");
                    Console.WriteLine($"Decription: {item.Value.ItemDescription}");
                    Console.WriteLine("--------");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Cart is empty..");
                }
            }
        }
    }
}
