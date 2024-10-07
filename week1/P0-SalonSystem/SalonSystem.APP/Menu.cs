namespace SalonSystem.APP.SalonMenu;
using SalonSystem.APP.Salons;
using SalonSystem.APP.MenuLogic;
using SalonSystem.APP.Techinicians;
using SalonSystem.APP.Services;

public static class Menu {
    public static void LoadingMessage() {
        Console.Write("Loading......");
    }
    //Display main menu. The first menu when user use app.
    public static void DisplayMainMenu(List<Salon> salonList) 
    {
        Console.WriteLine("Welcome to Salon System!");
        Console.WriteLine("Please let us know if you are: ");
        Console.WriteLine("1. Existing user");
        Console.WriteLine("2. New User (Creating new Salon)");
        if (salonList is null) salonList = new List<Salon>();  
        int option = MenuLogic.getUserIntegerInput();
        switch(option)
        {
            case 1:
                int id = Menu.DisplayLoginMenu(salonList);
                if (id == -1) System.Environment.Exit(1);
                else Menu.DisplaySalonMenu(salonList[id]);
                break;
            case 2:
                 Console.WriteLine("Great. Let's create your salon!");
                 Menu.DisplaySalonMenu(MenuLogic.CreatNewSalon(salonList));
                 break;
        } 
    }


    //Display login menu where user login.
    public static int DisplayLoginMenu(List<Salon> salonList)
    {
        while (true) {
            Console.WriteLine("Please enter your ID or enter -1 to exit:");
            int id = MenuLogic.getUserIntegerInput();
            if (id == -1) return -1;
            if (id <= salonList.Count) 
            {
                Console.WriteLine("Log in successfully!");
                return id;
            }
            else 
            {
                Console.WriteLine("Cannot find your ID. Plesae try again");
            }
        }
    }

    //Display user's menu
    public static void DisplaySalonMenu(Salon salon) {
        Console.WriteLine($"Welcome owner of {salon.Name}");
        Console.WriteLine("Please choose the option: ");
        Console.WriteLine("1. Display All Technicians");
        Console.WriteLine("2. Display Your Services");
        Console.WriteLine("3. Add Technicians");
        Console.WriteLine("4. Add Services");
        Console.WriteLine("5. Show all appointments");
        int option = MenuLogic.getUserIntegerInput();
        switch(option) 
        {
            case 1:
                foreach(Technician technician in salon.TechnicianList)
                {
                    Console.WriteLine($"{technician.ID}. {technician.Name}");
                }
                break;
            case 2:
                foreach (Service service in salon.ServiceList)
                {
                    Console.WriteLine($"{service.ID}. {service.Name}");
                }
                break;

            case 3:
                break;
            case -1:
                Console.WriteLine("Not a valid option. Plesae choose again");
                break;
        }
    }



       
}