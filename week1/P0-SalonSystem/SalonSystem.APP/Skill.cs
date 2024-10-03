public class Skill 
{
    public string Name {set ; get;}
    public int Duration {set;get;}

    public Skill(string name, int duration = -1) => (Name, Duration) = (name, duration);
}