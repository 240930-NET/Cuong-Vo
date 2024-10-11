namespace SalonSystem.APP.SalonMenu;
using SalonSystem.APP.Salons;
using SalonSystem.APP.MenuLogic;
using SalonSystem.APP.Technicians;
using SalonSystem.APP.Services;
using SalonSystem.APP.SalonRepository;
using SalonSystem.APP.Skills;
using System.ComponentModel.DataAnnotations;
using System.Collections;

public static class Menu {
  //  public static void LoadingMessage() {
  //    writer.Write("Loading......");
  //  }
    //Display main menu. The first menu when user use app.
    public static void DisplayMainMenu(string filePath, TextReader reader, TextWriter writer) 
    {
        List<Salon>? SalonList = SalonRepository.LoadSalon(filePath);
        writer.WriteLine("Welcome to Salon System!");
        writer.WriteLine("Please let us know if you are: ");
        writer.WriteLine("1. Existing user");
        writer.WriteLine("2. New User (Creating new Salon)");
        writer.WriteLine("3. Exit");
        if (SalonList is null) SalonList = new List<Salon>();  
        int option = MenuLogic.getUserIntegerInput(reader,writer);
        int saveOption = 0;
        switch(option)
        {
            case 1:
                int id = Menu.DisplayLoginMenu(reader,writer,SalonList);
                if (id == -1) System.Environment.Exit(1);
                else saveOption = Menu.DisplaySalonMenu(reader,writer,SalonList[id-1]);
                break;
            case 2:
                 writer.WriteLine("Great. Let's create your salon!");
                 saveOption = Menu.DisplaySalonMenu(reader,writer,MenuLogic.CreatNewSalon(reader,writer,SalonList));
                 break;
            case 3:
                break;
        } 
        if (saveOption == 1) SalonRepository.saveAllSalon(SalonList, filePath);
    }


    //Display login menu where user login.
    public static int DisplayLoginMenu(TextReader reader, TextWriter writer,List<Salon> salonList)
    {
        while (true) {
            writer.WriteLine("Please enter your ID or enter -1 to exit:");
            int id = MenuLogic.getUserIntegerInput(reader,writer);
            if (id == -1) return -1;
            if (id <= salonList.Count) 
            {
                writer.WriteLine("Log in successfully!");
                return id;
            }
            else 
            {
                writer.WriteLine("Cannot find your ID. Plesae try again");
            }
        }
    }

    //Display text for Salon's User
        public static void DislayTextSalonMenu(TextWriter writer)
    {
            writer.WriteLine("");
            writer.WriteLine("----------- Salon Menu -----------");
            writer.WriteLine("Please choose the option: ");
            writer.WriteLine("1. Display Salon Information");
            writer.WriteLine("2. Display Technician Menu");
            writer.WriteLine("3. Display ServiceMenu");
            writer.WriteLine("4. Show all appointments <Under Development>");
            writer.WriteLine("5. Customer come in. What's service they want?");
            writer.WriteLine("7. Display all tech with their skills");
            writer.WriteLine("9. Exit");
    }

    //Display user's menu
    public static int DisplaySalonMenu(TextReader reader, TextWriter writer,Salon salon) 
    {
        int option = 10;
        writer.WriteLine($"Welcome owner of {salon.Name}");
        while (option != 9) {
            Menu.DislayTextSalonMenu(writer);
            option = MenuLogic.getUserIntegerInput(reader,writer);
            switch(option) 
            {
                case 1:
                    MenuLogic.DisplaySalonInformation(writer,salon);
                    break;
                case 2:
                    Menu.DisplayTechnicianMenu(reader,writer,salon);
                    break;
                case 3:
                    Menu.DisplayServicenMenu(reader,writer,salon);
                    break;
                case 5: 
                    writer.WriteLine("Please enter service name:");
                    string serviceName = MenuLogic.GetStringInput(reader,writer);
                    Service? foundService = salon.findServiceByName(serviceName);
                    if (foundService is null ){
                        writer.WriteLine("Service cannot be found!");
                        break;
                    }
                    writer.WriteLine($"Current Techncian can perform {serviceName}: ");
                    List<Technician> qualifiedTech = salon.FindTechnicianToPerform(foundService);
                    foreach (Technician tech in qualifiedTech) {
                        writer.WriteLine(tech.Name);
                    }
                    break;
                case 7:

                    break;

                case 9:
                    writer.WriteLine("Exiting");
                    return 1;
                default:
                    writer.WriteLine("Not a valid option. Plesae choose again");
                    break;
                /*case 8:
                    Technician newTech = new Technician(3,"Cecelia", 1200, PayPeriod.Weekly);
                    newTech.AddSkill("Women Haircut");
                    newTech.AddSkill("Manicure");
                    newTech.AddSkill("Acrylic Nails");
                    newTech.AddSkill("Shellac");
                    salon.AddTechnician(newTech);
                    break;
                    */
            }   
        }
        return 0;
        
    }

    public static void DisplayTextTechnicianMenu(TextWriter writer) 
    {
        writer.WriteLine("");
        writer.WriteLine("----------- Technician Menu -----------");
        writer.WriteLine("Please choose the option from Technician Menu: ");
        writer.WriteLine("1. Display All Technicians");
        writer.WriteLine("2. Add a technicians");
        writer.WriteLine("3. Delete  a technicians");
        writer.WriteLine("4. Edit a Techncian -- under development");
        writer.WriteLine("5. Return to Main Menu");
    }

    public static void DisplayTechnicianMenu(TextReader reader, TextWriter writer,Salon salon) 
    {
        int option = 10;
        while (option != 5) 
        {
            Menu.DisplayTextTechnicianMenu(writer);
            option = MenuLogic.getUserIntegerInput(reader,writer);
            switch(option) 
            {
                case 1:
                    MenuLogic.DisplayAllTechnician(writer,salon.TechnicianList);
                    break;
                case 2:
                    MenuLogic.AddNewTechnicianFor(reader,writer,salon);
                    break;
                case 3:
                    MenuLogic.RemoveTechncianFrom(reader,writer,salon);
                    break;
                case 5:
                    break;
                default:
                    writer.WriteLine("Not a valid Input");
                    break;
            }
        }
    }

        public static void DisplayTextServiceMenu(TextWriter writer) 
    {
        writer.WriteLine("");
        writer.WriteLine("----------- Service Menu -----------");
        writer.WriteLine("Please choose the option from Service Menu: ");
        writer.WriteLine("1. Display All Servicess");
        writer.WriteLine("2. Add a Service");
        writer.WriteLine("3. Delete  a Service");
        writer.WriteLine("4. Edit a Service <under development>");
        writer.WriteLine("5. Return to Main Menu");
    }

        public static void DisplayServicenMenu(TextReader reader, TextWriter writer,Salon salon) 
    {
        int option = 10;
        while (option != 5) 
        {
            Menu.DisplayTextServiceMenu(writer);
            option = MenuLogic.getUserIntegerInput(reader,writer);
            switch(option) 
            {
                case 1:
                    MenuLogic.DisplayAllService(writer,salon.ServiceList);
                    break;
                case 2:
                    MenuLogic.AddNewServiceTo(reader,writer,salon);
                    break;
                case 3:
                    MenuLogic.RemoveServiceFrom(reader,writer,salon);
                    break;
                case 5:
                    break;
                //case 6:
                //    Environment.Exit(1);
                //   break;
                default:
                    writer.WriteLine("Not a valid Input");
                    break;
            }
        }
    }

       
}