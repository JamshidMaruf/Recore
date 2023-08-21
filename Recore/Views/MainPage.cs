//using Recore.Views.Users;

//namespace Recore.Views;

//public class MainPage
//{
//    UserServiceView userServiceView = new UserServiceView();
//    public void MainView()
//    {
//        Console.WriteLine("------------- Pages -------------");
//        Console.Write("1. User \n" +
//            "2. Product category \n" +
//            "3. Product \n" +
//            "0. Exit \n");
//        Console.Write(">>>>>>>");

//        int choice = int.Parse(Console.ReadLine());
//        switch (choice)
//        {
//            case 1:
//                UserView();
//                break;
//            case 2:
//                break;
//            case 3:
//                break;
//            case 0:
//                break;
//            default:
//                MainView();
//                break;
//        }

//    }

//    public void UserView()
//    {
//        Console.Write("1. Create \n" +
//            "2. Update \n" +
//            "3. Delete \n" +
//            "4. Get \n" +
//            "5. Get all \n" +
//            "0. Exit \n");
//        Console.Write(">>>>>>>");

//        int choice = int.Parse(Console.ReadLine());
//        switch (choice)
//        {
//            case 1:
//                userServiceView.Create();
//                break;
//            case 2:
//                userServiceView.Update();
//                break;
//            case 3:
//                userServiceView.Delete();
//                break;
//            case 4:
//                userServiceView.GetById();
//                break;
//            case 5:
//                userServiceView.GetAll();
//                break;
//            case 0:
//                MainView();
//                break;
//            default:
//                UserView();
//                break;
//        }
//    }
//}
