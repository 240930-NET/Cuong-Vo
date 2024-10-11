namespace SalonSystem.Tests.SkillUTest;
using SalonSystem.APP.Skills;

public class SkillUnitTest
{
    [Fact]
    public void SKillCreationTest() {
        //Arange && Act
        Skill noDurationSkill = new Skill("Skill without duration");
        Skill skillWithDuration = new Skill ("withDuration",45);
        //Assert
        Assert.Equal(-1,noDurationSkill.Duration);
        Assert.Equal("Skill without duration",noDurationSkill.Name);
        Assert.Equal(45,skillWithDuration.Duration);
        Assert.Equal("withDuration",skillWithDuration.Name);
    }

    [Theory]
    [InlineData("Manicure", 25, "Manicure", 25, true)]  // Same skill name, same durations - Equal
    [InlineData("Dipping Powder", 45, "Dipping Powder", 60, true)] // Same skill name, differemt duration - Equal
    [InlineData("Manicure", 30, "Pedicure", 30, false)] // Different skill names, same duration - not equal
    [InlineData("Acrylic Nails", 40, "Manicure", 30, false)] // Different skill names, different duration - not equal
    public void ComparisonsTest(string skillName1, int duration1, string skillName2, int duration2, bool expectedResult)
    {
        // Arrange
        var skill1 = new Skill(skillName1, duration1);
        var skill2 = new Skill(skillName2, duration2);

        // Act
        bool areEqual = skill1.Equals(skill2);

        // Assert
        Assert.Equal(expectedResult, areEqual);
    }

    //need to test Hash
}