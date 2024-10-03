public class Technician : Employee
{
    private List<Skill> SkillSet;

    public Technician (int id, string name, int salary, short salaryInterval = 1)
        :base(id,name,salary,salaryInterval) 
    {
        SkillSet = new List<Skill>();
    }
    
    public void addSkill(string skill, int duration = -1) => SkillSet.Add(new Skill(skill,duration));
}