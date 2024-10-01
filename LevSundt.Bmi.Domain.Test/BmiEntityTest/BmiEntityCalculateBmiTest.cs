using LevSundt.Bmi.Domain.DomainServices;
using LevSundt.Bmi.Domain.Model;
using Moq;

namespace LevSundt.Bmi.Domain.Test.BmiEntityTest;

public class BmiEntityCalculateBmiTest
{
    [Theory]
    [InlineData(200, 100, 25)]
    [InlineData(190, 90, 24.9)]
    public void Given_Height_And_Weight_Then__BMI_Is_Calculated_Correct( 
        double height, double weight, double expected)
    {
        // Arrange
        // Vi skal bruge en mock af IBmiDomainService
        var mock = new Mock<IBmiDomainService>();    
        var sut = new BmiEntityTest(mock.Object, height, weight);   // mock bruges som parameter

        // Act
        sut.CalculateBmi();

        // Assert
        Assert.Equal(expected, Math.Round(sut.Bmi, 1));
    }

    public class BmiEntityTest : BmiEntity
    {
        public BmiEntityTest(IBmiDomainService domainService, double height, double weight) : base(domainService,height, weight )
        {
        }

        /// <summary>
        ///     Vi vil teste metoden CalculateBmi() i BmiEntity modellen.
        ///     Da CalculateBmi() er protected, skal vi override metoden med new.
        ///     base.CalculateBmi() bruges for at kalde metoden fra BmiEntity
        /// </summary>
        public new void CalculateBmi()
        {
            base.CalculateBmi();
        }
    }
}