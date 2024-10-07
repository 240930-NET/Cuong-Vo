namespace SalonSystem.APP.Services;

using SalonSystem.APP.Skills;
using SalonSystem.APP.Technicians;



public class Service {
    public string Name {get;set;}
    public List<Skill> RequiredSkills {get;set;}

    public Service() {
        RequiredSkills = new List<Skill>();
    }
    public Service(string name, List<Skill> requiredSkills) 
    {
        Name = name;
        RequiredSkills = requiredSkills;
    }

    public  void addRequiredSkill(Skill skill) => RequiredSkills.Add(skill);

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
