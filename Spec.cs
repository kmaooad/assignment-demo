using System;
using Xbehave;
using FluentAssertions;

namespace KmaOoad18.Assignments.Demo
{
    public class Spec
    {
        [Scenario]
        public void Not_Born_Yet(DateTime currentDate, DateTime birthDate, int actualAge)
        {
            "Given current date"
                .x(() => currentDate = DateTime.Now);

            "And birth date after current"
                .x(() => birthDate = currentDate.AddYears(1));

            "When I calculate age"
                .x(() => actualAge = HelloCsharp.CalculateAge(currentDate, birthDate));

            "Then I expect to get zero"
                .x(()=>actualAge.Should().Be(0, "age cannot be negative"));
        }

        [Scenario]
        public void Partial_Year_Does_Not_Count(DateTime currentDate, DateTime birthDate, int actualAge)
        {
            const int expectedAge = 2;

            "Given current date"
                .x(() => currentDate = new DateTime(2018, 9, 13));

            $"And birth date {expectedAge+1} years minus 1 day before current date"
                .x(() => birthDate = currentDate.AddYears(-(expectedAge+1)).AddDays(1));

            "When I calculate age"
                .x(() => actualAge = HelloCsharp.CalculateAge(currentDate, birthDate));

            $"Then I expect to get {expectedAge}"
                .x(()=>actualAge.Should().Be(expectedAge, "only full years count"));
        }
    }
}
