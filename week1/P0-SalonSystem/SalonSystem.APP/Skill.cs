namespace SalonSystem.APP.Skills;

public class Skill 
{
    public string Name {set ; get;}
    public int Duration {set;get;}

    public Skill(string name, int duration = -1) => (Name, Duration) = (name, duration);

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is Skill otherSkill)
        {
            return Name == otherSkill.Name;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Name != null ? Name.GetHashCode() : 0;
    }
}