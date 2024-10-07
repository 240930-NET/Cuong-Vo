namespace SalonSystem.APP.SalonRepository;
using System.Text.Json;
using System.Collections.Generic;
using SalonSystem.APP.Salons;

public static class SalonRepository 
{
    /*Function to save 1 salon to the existing database when creating new salon*/
    public static void saveSalon(Salon salon, string filePath) {
        List<Salon>? salons = LoadSalon(filePath);
        if (salons is null) salons = new List<Salon>();
        salons.Add(salon);

        string jsonData = JsonSerializer.Serialize(salons, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText(filePath, jsonData);
    }
    /* Save the current state of all salon to file/database */
    public static void saveAllSalon(List<Salon> salons, string filePath) {
        string jsonData = JsonSerializer.Serialize(salons, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText(filePath, jsonData);
    }

    public static List<Salon>? LoadSalon(string filePath) {
        if (!File.Exists(filePath)) return new List<Salon>();

        string jsonData = File.ReadAllText(filePath);
        if (string.IsNullOrWhiteSpace(jsonData))
        {
        throw new InvalidOperationException("The file is empty or contains invalid JSON.");
        }
        return JsonSerializer.Deserialize<List<Salon>>(jsonData);
        
    }



    
}

