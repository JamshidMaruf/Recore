//using Recore.Domain.Entities.Users;
//using Recore.Service.Services;

//namespace Recore.Views.Users;

//public class UserServiceView
//{
//    private readonly UserService userService = new UserService();

//    public async void Create()
//    {
//        Console.Write("FirstName: ");
//        string firstName = Console.ReadLine();

//        Console.Write("LastName: ");
//        string lastName = Console.ReadLine();

//        Console.Write("Email (example@gmail.com): ");
//        string email = Console.ReadLine();

//        Console.Write("Phone (998xxxxxxxxx): ");
//        string phone = Console.ReadLine();

//        Console.Write("Date of birth (yyyy.mm.dd): ");
//        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

//        User user = new User
//        {
//            Email = email,
//            Phone = phone,
//            LastName = lastName,
//            FirstName = firstName,
//            DateOfBirth = dateOfBirth
//        };

//        var result = await this.userService.CreateAsync(user);
//        if (result.StatusCode != 200)
//            Console.WriteLine($"Exception: {result.Message}");
//        else
//            Console.WriteLine($"ID: {user.Id} | FirstName: " +
//                $"{user.FirstName}| LastName: {user.LastName}");
//    }

//    public async void Update()
//    {
//        Console.Write("Email (example@gmail.com): ");
//        string email = Console.ReadLine();

//        var existEmail = await this.userService.CheckEmailAsync(email);
//        if (existEmail.StatusCode != 200)
//            // return MainPage

//            Console.Write("FirstName: ");
//        string firstName = Console.ReadLine();

//        Console.Write("LastName: ");
//        string lastName = Console.ReadLine();

//        Console.Write("Phone (998xxxxxxxxx): ");
//        string phone = Console.ReadLine();

//        Console.Write("Date of birth (yyyy.mm.dd): ");
//        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

//        User user = new User
//        {
//            Email = email,
//            Phone = phone,
//            LastName = lastName,
//            FirstName = firstName,
//            DateOfBirth = dateOfBirth
//        };

//        var result = await this.userService.UpdateAsync(user);
//        if (result.StatusCode != 200)
//            Console.WriteLine($"Exception: {result.Message}");
//        else
//            Console.WriteLine($"ID: {user.Id} | FirstName: {user.FirstName}| LastName: {user.LastName}");
//    }

//    public async void Delete()
//    {
//        Console.Write("ID: ");
//        long id = long.Parse(Console.ReadLine());
//        var result = await this.userService.DeleteAsync(id);
//        Console.WriteLine($"{result.Message}");
//    }

//    public async void GetById()
//    {
//        Console.Write("ID: ");
//        long id = long.Parse(Console.ReadLine());

//        var result = await this.userService.GetByIdAsync(id);

//        if (result.StatusCode != 200)
//            Console.WriteLine($"{result.Message}");
//        else
//            Console.WriteLine($"ID: {result.Data.Id} | FirstName: {result.Data.FirstName}| LastName: {result.Data.LastName}");
//    }

//    public async void GetAll()
//    {
//        var result = await this.userService.GetAllAsync();
//        foreach (var item in result.Data)
//            Console.WriteLine($"ID: {item.Id} | FirstName: {item.FirstName}| LastName: {item.LastName}");
//    }
//}
