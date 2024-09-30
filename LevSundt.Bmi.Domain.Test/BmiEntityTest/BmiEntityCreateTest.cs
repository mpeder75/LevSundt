using LevSundt.Bmi.Domain.DomainServices;
using LevSundt.Bmi.Domain.Model;
using Moq;

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
        var mock = new Mock<IBmiDomainService>();

        // Act
        var sut = new BmiEntity(mock.Object, height, 100, 1);
        // Assert
    }

    // Test af uacceptabler værdier for HØJDE
    [Theory]
    [InlineData(250.01)] // Test for højde over interval
    [InlineData(99.99)] // Test for højde under interval
    public void Given_Height_Is_InValid__Then_ArgumentException_Is_Thrown(double height)
    {
        // Arrange
        var mock = new Mock<IBmiDomainService>();
        // uanset hvilken data, vil den altid returner false - HUSK vi tester her for invalid
        mock.Setup(m => m.BmiExistsOnDate(It.IsAny<DateTime>(), It.IsAny<int>())).Returns(false);
        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => new BmiEntity(mock.Object, height, 100, 1 ));
    }

    // Test af acceptable værdier for VÆGT - interval 40 til 250
    [Theory]
    [InlineData(100)] // Test for vægt midt i interval
    [InlineData(250)] // Test for vægt i top af interval
    [InlineData(40)] // Test for vægt i bund af interval
    public void Given_Weight_Is_Valid__Then_BmiEnitiy_Is_Created(double weight)
    {
        // Arrange
        var mock = new Mock<IBmiDomainService>();
        // Act
        var sut = new BmiEntity(mock.Object, 200, weight, 1);
        // Assert
    }

    // Test af uacceptable værdier for VÆGT
    [Theory]
    [InlineData(250.01)] // Test for højde over interval
    [InlineData(39.99)] // Test for højde under interval
    public void Given_Weight_Is_InValid__Then_ArgumentException_Is_Thrown(double weight)
    {
        // Arrange
        var mock = new Mock<IBmiDomainService>();
        mock.Setup(m => m.BmiExistsOnDate(It.IsAny<DateTime>(),It.IsAny<int>())).Returns(false);

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => new BmiEntity(mock.Object, weight, 200, 1));
    }

    // Test af uacceptable værdier for VÆGT
    [Theory]
    [InlineData(200, 100, 25)] 
    [InlineData(190, 90, 24.9)]
    public void Given_Height_And_Weight__The_Bmi_Is_Calculated_Correct(double height, double weight, double expected)
    {
        // Arrange
        var mock = new Mock<IBmiDomainService>();

        // Act
        var sut = new BmiEntity(mock.Object, height, weight, 1);
        // Assert
        Assert.Equal(expected, Math.Round(sut.Bmi, 1));
    }
    

   [Fact]
    public void Given_Date_Is_Valid__Then_BmiEnitiy_Is_Created()
    {
        // Arrange
        var mock = new Mock<IBmiDomainService>();
        mock.Setup(m => m.BmiExistsOnDate(It.IsAny<DateTime>(),It.IsAny<int>())).Returns(false);
        // Act
        var sut = new BmiEntity(mock.Object, 100, 100, 1);
        // Assert
    }
    

    [Fact]
    public void Given_Date_Is_InValid__Then_ArgumentException_Is_Thrown()
    {
        // Arrange
        var mock = new Mock<IBmiDomainService>();
        mock.Setup(m => m.BmiExistsOnDate(It.IsAny<DateTime>(), It.IsAny<int>())).Returns(true);
        // Act
        // Assert
        Assert.Throws<ArgumentException>(() => new BmiEntity(mock.Object, 100, 100, 1 ));
    }

   

}