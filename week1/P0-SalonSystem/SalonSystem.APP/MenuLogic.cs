namespace SalonSystem.APP.MenuLogic;

using SalonSystem.APP.SalonMenu;
using SalonSystem.APP.Salons;
public static class MenuLogic 
{
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

    public static string GetStringInput() 
    {
        try  
        {
            string stringInput = "";
            while (stringInput != "") 
            {
                Console.ReadLine();
                if (stringInput == "") Console.WriteLine("string input cannot be empty. Please enter again.");
            }
            return stringInput;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return "";
        }
    }

    public static Salon CreatNewSalon(List<Salon> salonList) 
    {
        Console.WriteLine("Please enter your salon name :");
        try  
        {
            string? salonName = GetStringInput();
            Salon currentSalon = new Salon(salonName);
            salonList.Add(currentSalon);
            return currentSalon;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Salon("default");
        }
    }
}