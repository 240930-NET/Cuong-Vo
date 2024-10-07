namespace P0_SalonSystem;
using SalonSystem.APP.Salons;
using SalonSystem.APP.Techinicians;
using SalonSystem.APP.SalonMenu;
using SalonSystem.APP.SalonRepository;
using  SalonSystem.APP.PATH;
using SalonSystem.APP.MenuLogic;

class Program
{
    static void Main(string[] args)
    {
        //Load data
        List<Salon>? SalonList = SalonRepository.LoadSalon(FilePathConfig.SalonDataPath);
        //Start main menu
        Menu.DisplayMainMenu(SalonList);
        

    }
}
