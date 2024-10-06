namespace SalonSystem.APP.Services;

using SalonSystem.APP.Skills;
using SalonSystem.APP.Techinicians;



public class Service {
    public string Name {get;set;}
    public List<Skill> RequiredSkills {get;set;}

    public Service(string name, List<Skill> requiredSkills) 
    {
        Name = name;
        RequiredSkills = requiredSkills;
    }

    public Service(string name) 
    {
        Name = name;
        RequiredSkills = new List<Skill>();
    }

    public bool CanBePerformedBy(Technician technician)
    {
        return RequiredSkills.All(skill => technician.SkillSet.Contains(skill));
    }
}
