namespace SalonSystem.APP.MenuLogic;

//using SalonSystem.APP.SalonMenu;
using SalonSystem.APP.Salons;
using SalonSystem.APP.Technicians;
using SalonSystem.APP.Services;
using SalonSystem.APP.Skills;
public static class MenuLogic 
{
    public static int getUserIntegerInput(TextReader reader, TextWriter writer)
    {
        try 
        {
            string? userInput = "";
            while (userInput is null || userInput == "") 
            {
                userInput = reader.ReadLine();
                if (userInput == "") writer.WriteLine("Input cannot be empty. Please enter again.");
            }
            int i = Int32.Parse(userInput!);
            return i;
        }
        catch (Exception ex)
        {
            writer.WriteLine(ex.Message);
            return -1;
        }
    }

    public static string GetStringInput(TextReader reader, TextWriter writer) 
    {
        try  
        {
            string? stringInput = "";
            while (stringInput == "" || stringInput is null) 
            {
                stringInput = reader.ReadLine();
                if (stringInput == "") writer.WriteLine("string input cannot be empty. Please enter again.");
            }
            return stringInput!;
        }
        catch (Exception ex)
        {
            writer.WriteLine(ex.Message);
            return "";
        }
    }

    public static void DisplaySalonInformation(TextWriter writer, Salon salon)
    {
        writer.WriteLine($"Salon {salon.Name} has {salon.TechnicianList.Count} Techncians and "
                            + $"{salon.ServiceList.Count} Services");
    }

    public static Salon CreatNewSalon(TextReader reader, TextWriter writer, List<Salon> salonList) 
    {
        writer.WriteLine("Please enter your salon name :");
        try  
        {
            string? salonName = GetStringInput(reader,writer);
            Salon currentSalon = new Salon(salonName);
            salonList.Add(currentSalon);
            return currentSalon;
        }
        catch (Exception ex)
        {
            writer.WriteLine(ex.Message);
            return new Salon("default");
        }
    }

    //Technician Logic related---------------------
    public static void AddNewTechnicianFor(TextReader reader, TextWriter writer, Salon salon) {
        writer.WriteLine("Please enter technician name: ");
        string techName = MenuLogic.GetStringInput(reader,writer);
        writer.WriteLine("Please enter salary for Weekly: ");
        int salary = MenuLogic.getUserIntegerInput(reader,writer);
        Technician technician = salon.AddTechnicianAndReturn(techName,salary);
        writer.WriteLine($"Please enter Skills for {techName}: ");
        writer.WriteLine("Mutilple skills should be separate by comma \",\"!");
        try 
        {
            string? stringInput = reader.ReadLine();
            if (stringInput is not null ) {
                stringInput = stringInput.Trim();
                if (stringInput != "") {
                    string[] skillNames = stringInput.Split(',');
                    foreach (string skillName in skillNames)
                    {
                        if (!string.IsNullOrWhiteSpace(skillName))
                        {
                            string trimmedSkillName = skillName.Trim();
                            technician.AddSkill(new Skill(trimmedSkillName));
                        }
                    }
                }
            }
        }
            catch (Exception ex)
        {
            writer.WriteLine(ex.Message);
        }
        writer.WriteLine("Added successfuly!");
    }
    
    public static void DisplayAllTechnician(TextWriter writer, List<Technician> technicianList)
    {
        foreach(Technician technician in technicianList)
        {
            writer.WriteLine($"{technician.ID}. {technician.Name}");
            foreach (Skill techSkill in technician.SkillSet) {
                writer.WriteLine($"\t {techSkill.Name}");
            }
        }
    }

    public static bool RemoveTechncianFrom(TextReader reader, TextWriter writer, Salon salon) {
        writer.WriteLine(" Please enter techncian name to delete: ");
        string techName = MenuLogic.GetStringInput(reader,writer);
        List<Technician> matchedTechnician =  salon.FindTechniciansByName(techName);
        if (matchedTechnician.Count == 0) writer.WriteLine("No matching technician!");
        else 
        {
            writer.WriteLine("Matching Techncian are: ");
            foreach(Technician technician in matchedTechnician) 
                writer.WriteLine($"{technician.ID}. {technician.Name}");
            writer.WriteLine("Plesae the technician ID for confirmation to delete or -1 to exit: ");
            int id = MenuLogic.getUserIntegerInput(reader,writer);
            if (id == -1)
                return false;
            if (salon.RemoveTechncianByID(id)) {
                writer.WriteLine("Remove successfuly");
                return true;
            }
            else {
                writer.WriteLine("There is no such ID");
                return false;
            }

        }
        return false;
    }
//Service Logic related ----------------------------
    public static void DisplayAllService(TextWriter writer, List<Service> serviceList)
    {
        foreach (var service in serviceList)
        {
            writer.WriteLine(service.Name);
        }
    }

    public static void AddNewServiceTo(TextReader reader, TextWriter writer, Salon salon) 
    {
        writer.WriteLine("Please enter Service name: ");
        string addServiceName = MenuLogic.GetStringInput(reader,writer);
        Service service = new Service(addServiceName);
        writer.WriteLine($"Please enter Skills required for {addServiceName}: ");
        writer.WriteLine("Mutilple skills should be separate by comma \",\"!");
        try 
        {
            string? stringInput = reader.ReadLine();
            if (stringInput is not null ) 
            {
                stringInput = stringInput.Trim();
                if (stringInput != "") {
                    string[] skillNames = stringInput.Split(',');
                    foreach (string skillName in skillNames)
                    {
                        if (!string.IsNullOrWhiteSpace(skillName))
                        {
                            string trimmedSkillName = skillName.Trim();
                            service.addRequiredSkill(new Skill(trimmedSkillName));
                        }
                    }
                }
            }
        }
            catch (Exception ex)
        {
            writer.WriteLine(ex.Message);
        }
        salon.AddService(service);
        writer.WriteLine("Added successfuly!");
    }

     public static bool RemoveServiceFrom(TextReader reader, TextWriter writer, Salon salon) {
        string serviceName = MenuLogic.GetStringInput(reader,writer);
        foreach (var service in salon.ServiceList)
            if (service.Name == serviceName) 
            {
                salon.ServiceList.Remove(service);
                writer.WriteLine("Remove Successfully");
                return true;
            }
        writer.WriteLine("Cannot find such Service. Remove unsuccessfully");
        return false;
     }
}