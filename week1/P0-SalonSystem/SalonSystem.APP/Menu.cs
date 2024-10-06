namespace SalonSystem.APP.SalonMenu;

public static class Menu {
    public staic void LoadingMessage() {
        Console.Write("Loading......")
    }
    public static void Greeting() 
    {
        Console.WriteLine("Welcome to Salon System!");
        Console.WriteLine("Please let us know if you are: ");
        Console.WriteLine("1. Existing user");
        Console.WriteLine("2. New User (Creating new Salon)");
    }

    public static int getUserIntegerInput()
     {
        try 
        {
            string? userInput = Console.ReadLine();
            int i = Int32.Parse(userInput);
            return i;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return -1;
        }
    }

    public static int ProcessLogin()
    {
        while (true) {
            Console.WriteLine("Please enter your ID or enter -1 to exit:");
            int id = Menu.getUserIntegerInput();
            if (id == -1) return -1;
            if (id <= SalonList.Count) 
            {
                Console.WriteLine("Log in successfully!")
                return id;
            }
            else 
            {
                Console.WriteLine("Cannot find your ID. Plesae try again")
            }
        }
    }

    public static void DisplaySalonMenu(Salon salon) {
        Console.WriteLine(" Welcome owner of {salon.Name}");

    }

    public static void CreatNewSalon(List<Salon> salonList) {
        Console.WriteLine("Please enter your salon name :");
        

    }
       
}