public class Technician : Employee
{
    private List<Skill> SkillSet;

    public Technician (string name, int salary, short salaryInterval = 1) {
        Name = name;
        Salary = salary;
        SalaryInterval = salaryInterval;
        SkillSet = new List<Skill>();
    }
    
    public void addSkill(string skill) {
        SkillSet.Add(new Skill(skill));
    }
}