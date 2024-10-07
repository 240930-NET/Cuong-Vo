

using SalonSystem.APP.Skills;
using SalonSystem.APP.Employees;
using SalonSystem.APP.Services;

namespace SalonSystem.APP.Technicians;
public class Technician : Employee
{
    public List<Skill> SkillSet {get; private set;}

    public Technician (int id, string name, int salary, PayPeriod payPeriodType = PayPeriod.Weekly)
        :base(id,name,salary,payPeriodType) 
    {
        SkillSet = new List<Skill>();
    }

    public bool CanPerformService(Service service)
    {
        return service.CanBePerformedBy(this);
    }
    
    public void AddSkill(string skill, int duration = -1) => SkillSet.Add(new Skill(skill,duration));
    public void AddSkill(Skill skill) => SkillSet.Add(skill);
}