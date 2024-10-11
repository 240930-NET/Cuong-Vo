namespace SalonSystem.Tests.TechnicianlUTest;
using SalonSystem.APP.Skills;
using SalonSystem.APP.Services;
using SalonSystem.APP.Technicians;

public class ServicelUnitTest {
    [Theory]
    [InlineData("Men haircut",30,"Women haircut",50,"Hair Perm",60)]
    public void AddRequiredSkillUnitTest(string skillName1, int duration1,
     string skillName2, int duration2, string skillName3, int duration3)
    {
          // Arrange
        Service service = new Service("Nail Service");
        Skill skill1 = new Skill(skillName1, duration1);
        var skill2 = new Skill(skillName2, duration2);
        var skill3 = new Skill(skillName3, duration3);
        // Act
        service.addRequiredSkill(skill1);
        service.addRequiredSkill(skill2);
        service.addRequiredSkill(skill3);
        //Assert
        Assert.Contains(skill3,service.RequiredSkills);
        Assert.Contains(skill2,service.RequiredSkills);
        Assert.Contains(skill1,service.RequiredSkills);
        Assert.Equal(3,service.RequiredSkills.Count);
    }

    //CanPerFormBy: test if service can be performed by a technician:
    // Case 1: have all required skill or even have more skills
    // case 2: Missing a skill or skills
    // case 3: Service doesn't have a required skill

    //Case 1: Have All Required Skill
    [Fact]
    public void CanPerformByUnitTestHaveAllSkills() {
        var requiredSkills = new List<Skill>
        {
            new Skill("Shellac", 30),
            new Skill("Nails Design", 45)
        };
        Service service = new Service("Shellac with Service", requiredSkills);

         var technicianSkills = new List<Skill>
        {
            new Skill("Manicure", 20),
            new Skill("Shellac", 30),
            new Skill("Nails Design", 15),
            new Skill("Acrylic",45)
        };

        var technician = new Technician(1, "John noCeeya",9999);
        technician.AddSkill(technicianSkills);
        // Act
        bool result = service.CanBePerformedBy(technician);
        // Assert
        Assert.True(result);

    }

    //Case 2: Have All Required Skill
    [Fact]
    public void CanPerformByUnitTestMissingSkills() {
        var requiredSkills = new List<Skill>
        {
            new Skill("Shellac", 30),
            new Skill("Nails Design", 45),
            new Skill("Acrylic")
        };
        Service service = new Service("Shellac with Service", requiredSkills);

         var technASkills = new List<Skill>
        {
            new Skill("Manicure", 20),
            new Skill("Design", 15),
            new Skill("Acrylic",45)
        };

        var technBSkills = new List<Skill>
        {
            new Skill("Flaming Nails", 20)
        };
        var techA = new Technician(1, "Azalea",9999);
        techA.AddSkill(technASkills);
        var techB = new Technician(1, "Hu Tao",9999);

        // Act
        bool result = service.CanBePerformedBy(techA);
        bool result2 =  service.CanBePerformedBy(techB);
        // Assert
        Assert.False(result);
        Assert.False(result2);
    }

    //Case 3: Service without required Skill -- always return true
    [Fact]
    public void CanPerformByUnitTestAlwaysTrue() {
        Service service = new Service("Serving Green Tea");  
         var technASkills = new List<Skill>
        {
            new Skill("Manicure", 20),
            new Skill("Design", 15),
            new Skill("Acrylic",45)
        };
        Technician techA = new Technician(1, "Tia",9999);
        techA.AddSkill(technASkills);
        Technician techB = new Technician(2,"Theo",1200);
        //Act
        bool result1 = service.CanBePerformedBy(techA);
        bool result2 = service.CanBePerformedBy(techB);
        //Assert
        Assert.True(result1);
        Assert.True(result2);


    }
}