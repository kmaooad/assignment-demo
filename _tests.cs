using System;
using NSubstitute;
using Xunit;

namespace KmaOoad18.Assignments.Demo
{
    // DON'T MODIFY THIS FILE
    public class _tests
    {
        [Theory]
        [InlineData(2018, 18)]
        [InlineData(2021, 21)]
        [InlineData(1990, 0)]
        public void CanCalculateCsharpAge(int supposedYear, int assertedAge)
        {
            // Given
            var s = Substitute.ForPartsOf<HelloCsharp>();

            s.GetCurrentYear().Returns(supposedYear);

            // When
            var age = s.GetCsharpAge();

            // Then
            Assert.Equal(assertedAge, age);
        }

        [Fact]
        public void CanGetCurrentYear()
        {
            // Given
            var hw = new HelloCsharp();

            // When
            var y = hw.GetCurrentYear();

            // Then
            Assert.Equal(y, DateTime.Now.Year);
        }
    }
}
