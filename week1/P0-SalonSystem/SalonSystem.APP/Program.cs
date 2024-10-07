namespace P0_SalonSystem;
using SalonSystem.APP.SalonMenu;
using  SalonSystem.APP.PATH;

class Program
{
    static void Main(string[] args)
    {
        Menu.DisplayMainMenu(FilePathConfig.SalonDataPath);

    }
}
