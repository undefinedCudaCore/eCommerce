﻿namespace eCommerce.Service.RandomGenerators
{
    public static class RandomId
    {
        public static string RandomIdGenerator()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var randomId = new String(stringChars);

            return randomId;
        }
    }
}
