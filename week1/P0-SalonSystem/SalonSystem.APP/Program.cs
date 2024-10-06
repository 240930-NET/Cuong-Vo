namespace P0_SalonSystem;
using SalonSystem.APP.Salons;
using SalonSystem.APP.Techinicians;
using SalonSystem.APP.SalonMenu;
using SalonSystem.APP.SalonRepository;
using  SalonSystem.APP.PATH;

class Program
{
    static void Main(string[] args)
    {
        Menu.LoadingMessage();
        List<Salon> SalonList = SalonRepository.LoadSalon(FilePathConfig.SalonDataPath);
        Menu.Greeting();
        int option = Menu.getUserIntegerInput();
        switch(option)
        {
            case 1:
                
                int id = Menu.HandleLogin(List<Salon> salonList);
                if (id == -1) System.Environment.Exit(1);
                else DisplaySalonMenu(salonList[id]);
                break;
            case 2:
                 Console.WriteLine("Great. Let's create your salon!");
                 CreatNewSalon(List<Salon> salonList);
                 break;
        } 
    }
}
