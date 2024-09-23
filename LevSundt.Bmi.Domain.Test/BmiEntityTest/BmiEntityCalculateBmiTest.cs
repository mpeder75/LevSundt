using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Domain.Test.BmiEntityTest
{
    public class BmiEntityCalculateBmiTest
    {
        // Her vil vi teste metoden CalculateBmi() i BmiEntity moddellen
        [Theory]
        [InlineData(200, 100, 25)]
        [InlineData(190, 90, 24.9)]
        public void Given_Height_And_Weight_Then__BMI_Is_Calculated_Correct(double height, double weight, double expected)
        {
            // Arrange
            // Vi opretter en instans af BmiEntityTest, hvor base class constructor kaldes
            var sut = new BmiEntityTest(height, weight);

            // Act
            sut.CalculateBmi();

            // Assert
            Assert.Equal(expected, Math.Round(sut.Bmi,1));
        }



        public class BmiEntityTest : BmiEntity
        {
            public BmiEntityTest(double height, double weight) : base(height, weight, 1)
            {
            }

            /// <summary>
            /// Vi vil teste metoden CalculateBmi() i BmiEntity modellen.
            /// Da CalculateBmi() er protected, skal vi override metoden med new.
            /// base.CalculateBmi() bruges for at kalde metoden fra BmiEntity
            /// </summary>
            public new void CalculateBmi()
            {
                base.CalculateBmi();
            }
        }
    }
}
