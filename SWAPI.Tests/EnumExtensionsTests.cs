using NUnit.Framework;
using SWAPI.Library.Enums;

namespace SWAPI.Tests
{
    [TestFixture]
    public class EnumExtensionsTests
    {
        [Test]
        public void When_Extension_Method_Called_Then_Correct_Resource_Names_Are_Returned()
        {
            var resources = new Resource[] { Resource.People, Resource.Films, Resource.Starships, Resource.Vehicles, Resource.Species, Resource.Planets };

            foreach (var resource in resources)
            {
                var expected = resource.ToString().ToLower();
                var actual = resource.GetName();

                Assert.AreEqual(expected, actual);
            }
        }
    }
}