using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Domain.Test.BmiEntityTest;

public class BmiEntityCreateTest
{
    /// <summary>
    ///     Der benyttes [Theory] så der kan testes med forskellige værdier.
    ///     TEST for de værdier der er givet i user story:
    ///     Acceptabel højde er (100; 250)
    ///     Acceptabel vægt er (40,0; 250,0)
    /// </summary>

    // Test af acceptabler værdier for HØJDE
    [Theory]
    [InlineData(200)] // Test for højde midt i interval
    [InlineData(250)] // Test for højde i top af interval
    [InlineData(100)] // Test for højde i bund af interval
    public void Given_Height_Is_Valid__Then_BmiEnitiy_Is_Created(double height)
    {
        // Arrange

        // Act
        var sut = new BmiEntity(height, 100);
        // Assert
    }

    // Test af uacceptabler værdier for HØJDE
    [Theory]
    [InlineData(250.01)] // Test for højde over interval
    [InlineData(99.99)] // Test for højde under interval
    public void Given_Height_Is_InValid__Then_ArgumentException_Is_Thrown(double height)
    {
        // Arrange

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => new BmiEntity(height, 100));
    }

    // Test af acceptable værdier for VÆGT - interval 40 til 250
    [Theory]
    [InlineData(100)] // Test for vægt midt i interval
    [InlineData(250)] // Test for vægt i top af interval
    [InlineData(40)] // Test for vægt i bund af interval
    public void Given_Weight_Is_Valid__Then_BmiEnitiy_Is_Created(double weight)
    {
        // Arrange

        // Act
        var sut = new BmiEntity(200, weight);
        // Assert
    }

    // Test af uacceptable værdier for VÆGT
    [Theory]
    [InlineData(250.01)] // Test for højde over interval
    [InlineData(39.99)] // Test for højde under interval
    public void Given_Weight_Is_InValid__Then_ArgumentException_Is_Thrown(double weight)
    {
        // Arrange

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => new BmiEntity(weight, 200));
    }
}