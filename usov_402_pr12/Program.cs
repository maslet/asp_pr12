using usov_402_pr12;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { FirstName = "Іван", LastName = "А це його прізвище", Age = 20 },
                    new User { FirstName = "Іван другий", LastName = "Це прізвище другого", Age = 24 },
                    new User { FirstName = "Іван третій", LastName = "Це прізвище треього", Age = 52 }
                );
                context.SaveChanges();
            }

            var users = context.Users.ToList();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Користувачі:");
            foreach (var user in users)
            {
                Console.WriteLine($"Ім'я: {user.FirstName}, Прізвище: {user.LastName}, Вік: {user.Age}");
            }

            var firstUser = context.Users.FirstOrDefault();
            if (firstUser != null)
            {
                firstUser.Age += 1;
                context.SaveChanges();
            }

            var lastUser = context.Users.OrderByDescending(u => u.Id).FirstOrDefault();
            if (lastUser != null)
            {
                context.Users.Remove(lastUser);
                context.SaveChanges();
            }

            Console.WriteLine("Натисніть будь-яку кнопку для виходу...");
            Console.ReadKey();
        }

    }
}
