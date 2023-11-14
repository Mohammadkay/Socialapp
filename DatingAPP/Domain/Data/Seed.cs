using DatingAPP;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class Seed
    {
        public static async Task seedUsers(mkContext context)
        {
            if (await context.Users.AnyAsync()) return;
            var userDate = await File.ReadAllTextAsync("C:/Users/m.alkayyali/Desktop/test/DatingAPP/Domain/Data/UserSeedData.json");
            var option=new JsonSerializerOptions {PropertyNameCaseInsensitive = true };
            var users=JsonSerializer.Deserialize<List<User>>(userDate);
            foreach (var user in users)
            {
                using var hmac=new HMACSHA512();
                user.UserName=user.UserName.ToLower();
                user.HashPassword=hmac.ComputeHash(Encoding.UTF8.GetBytes("kayyali1"));
                user.Saltpassword = hmac.Key;
                context.Users.Add(user);
            }
            await context.SaveChangesAsync();
        }
    }
}
