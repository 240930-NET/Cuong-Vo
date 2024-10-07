namespace SalonSystem.APP.SalonMenu;
using SalonSystem.APP.Salons;
using SalonSystem.APP.MenuLogic;
using SalonSystem.APP.Technicians;
using SalonSystem.APP.Services;
using SalonSystem.APP.SalonRepository;
using SalonSystem.APP.Skills;
public static class Menu {
    public static void LoadingMessage() {
        Console.Write("Loading......");
    }
    //Display main menu. The first menu when user use app.
    public static void DisplayMainMenu(string filePath) 
    {
        List<Salon>? SalonList = SalonRepository.LoadSalon(filePath);
        Console.WriteLine("Welcome to Salon System!");
        Console.WriteLine("Please let us know if you are: ");
        Console.WriteLine("1. Existing user");
        Console.WriteLine("2. New User (Creating new Salon)");
        if (SalonList is null) SalonList = new List<Salon>();  
        int option = MenuLogic.getUserIntegerInput();
        int saveOption = 0;
        switch(option)
        {
            case 1:
                int id = Menu.DisplayLoginMenu(SalonList);
                if (id == -1) System.Environment.Exit(1);
                else saveOption = Menu.DisplaySalonMenu(SalonList[id-1]);
                break;
            case 2:
                 Console.WriteLine("Great. Let's create your salon!");
                 saveOption = Menu.DisplaySalonMenu(MenuLogic.CreatNewSalon(SalonList));
                 break;
        } 
        if (saveOption == 1) SalonRepository.saveAllSalon(SalonList, filePath);
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

    public static int DisplaySalonMenu(Salon salon) {
        int option = 10;
        Console.WriteLine($"Welcome owner of {salon.Name}");
        while (option != 9) {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Please choose the option: ");
            Console.WriteLine("1. Display All Technicians");
            Console.WriteLine("2. Display Your Services");
            Console.WriteLine("3. Add Technicians");
            Console.WriteLine("4. Add Services");
            Console.WriteLine("5. Show all appointments");
            Console.WriteLine("6. Customer come in. What's service they want?");
            Console.WriteLine("9. Exit");
            option = MenuLogic.getUserIntegerInput();
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
                        Console.WriteLine($"{service.Name}");
                    }
                    break;
                case 3:
                    Console.WriteLine("Please enter technician name: ");
                    break;
                case 6: 
                    Console.WriteLine("Please enter service name:");
                    string serviceName = MenuLogic.GetStringInput();
                    Console.WriteLine($"Current Techncian can perform {serviceName}: ");
                    List<Technician> qualifiedTech = salon.FindTechnicianToPerform(new Service(serviceName));
                    foreach (Technician tech in qualifiedTech) {
                        Console.WriteLine(tech.Name);
                    }
                    break;
                case 8:
                    Technician newTech = new Technician(3,"Cecelia", 1200, PayPeriod.Weekly);
                    newTech.AddSkill("Women Haircut");
                    newTech.AddSkill("Manicure");
                    newTech.AddSkill("Acrylic Nails");
                    newTech.AddSkill("Shellac");
                    salon.AddTechnician(newTech);
                    break;
                case 9:
                    Console.WriteLine("Exiting");
                    return 1;
                case -1:
                    Console.WriteLine("Not a valid option. Plesae choose again");
                    break;
            }   
        }
        return 0;
        
    }



       
}