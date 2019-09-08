using System.IO;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SWAPI.Library.Models;
using SWAPI.Library.Requests;

namespace SWAPI.Tests
{
    [TestFixture]
    public class RequestManagerTests
    {
        [Test]
        public async Task When_Get_By_Id_Is_Called_For_Type_Person_Then_The_Correct_Person_Instance_Is_Returned()
        {
            // Arrange
            var fakeResponse = File.ReadAllText("Files/Person1.json");
            var mockRequestClient = new Mock<IRequestClient>();
            mockRequestClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(fakeResponse));

            // Act
            var requestManager = new RequestManager(mockRequestClient.Object);
            var result =  await requestManager.GetById<Person>("person", 1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual("Luke Skywalker", result.Name);
                Assert.AreEqual("172", result.Height);
                Assert.AreEqual("77", result.Mass);
                Assert.AreEqual("blond", result.HairColor);
                Assert.AreEqual("fair", result.SkinColor);
                Assert.AreEqual("blue", result.EyeColor);
                Assert.AreEqual("19BBY", result.BirthYear);
                Assert.AreEqual("male", result.Gender);
                Assert.AreEqual("male", result.Gender);
                Assert.AreEqual("https://swapi.co/api/planets/1/", result.Homeworld);
                Assert.AreEqual("2014-12-09T13:50:51.644000Z", result.Created);
                Assert.AreEqual("2014-12-20T21:17:56.891000Z", result.Edited);
                Assert.AreEqual("https://swapi.co/api/people/1/", result.Url);
            });
        }

        [Test]
        public async Task When_Get_All_Is_Called_For_Type_Person_Then_The_Correct_List_Of_People_Is_Returned()
        {
            // Arrange
            var fakeResponse = File.ReadAllText("Files/People.json");
            var mockRequestClient = new Mock<IRequestClient>();
            mockRequestClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(fakeResponse));

            // Act
            var requestManager = new RequestManager(mockRequestClient.Object);
            var result = await requestManager.GetAll<Person>("people");
            var resultArray = result.ToArray();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual("Luke Skywalker", resultArray[0].Name);
                Assert.AreEqual("172", resultArray[0].Height);
                Assert.AreEqual("77", resultArray[0].Mass);
                Assert.AreEqual("blond", resultArray[0].HairColor);
                Assert.AreEqual("fair", resultArray[0].SkinColor);
                Assert.AreEqual("blue", resultArray[0].EyeColor);
                Assert.AreEqual("19BBY", resultArray[0].BirthYear);
                Assert.AreEqual("male", resultArray[0].Gender);
                Assert.AreEqual("https://swapi.co/api/planets/1/", resultArray[0].Homeworld);
                Assert.AreEqual("2014-12-09T13:50:51.644000Z", resultArray[0].Created);
                Assert.AreEqual("2014-12-20T21:17:56.891000Z", resultArray[0].Edited);
                Assert.AreEqual("https://swapi.co/api/people/1/", resultArray[0].Url);

                Assert.AreEqual("C-3PO", resultArray[1].Name);
                Assert.AreEqual("167", resultArray[1].Height);
                Assert.AreEqual("75", resultArray[1].Mass);
                Assert.AreEqual("n/a", resultArray[1].HairColor);
                Assert.AreEqual("gold", resultArray[1].SkinColor);
                Assert.AreEqual("yellow", resultArray[1].EyeColor);
                Assert.AreEqual("112BBY", resultArray[1].BirthYear);
                Assert.AreEqual("n/a", resultArray[1].Gender);
                Assert.AreEqual("https://swapi.co/api/planets/1/", resultArray[1].Homeworld);
                Assert.AreEqual("2014-12-10T15:10:51.357000Z", resultArray[1].Created);
                Assert.AreEqual("2014-12-20T21:17:50.309000Z", resultArray[1].Edited);
                Assert.AreEqual("https://swapi.co/api/people/2/", resultArray[1].Url);

                Assert.AreEqual("R2-D2", resultArray[2].Name);
                Assert.AreEqual("96", resultArray[2].Height);
                Assert.AreEqual("32", resultArray[2].Mass);
                Assert.AreEqual("n/a", resultArray[2].HairColor);
                Assert.AreEqual("white, blue", resultArray[2].SkinColor);
                Assert.AreEqual("red", resultArray[2].EyeColor);
                Assert.AreEqual("33BBY", resultArray[2].BirthYear);
                Assert.AreEqual("n/a", resultArray[2].Gender);
                Assert.AreEqual("https://swapi.co/api/planets/8/", resultArray[2].Homeworld);
                Assert.AreEqual("2014-12-10T15:11:50.376000Z", resultArray[2].Created);
                Assert.AreEqual("2014-12-20T21:17:50.311000Z", resultArray[2].Edited);
                Assert.AreEqual("https://swapi.co/api/people/3/", resultArray[2].Url);

                Assert.AreEqual("Darth Vader", resultArray[3].Name);
                Assert.AreEqual("202", resultArray[3].Height);
                Assert.AreEqual("136", resultArray[3].Mass);
                Assert.AreEqual("none", resultArray[3].HairColor);
                Assert.AreEqual("white", resultArray[3].SkinColor);
                Assert.AreEqual("yellow", resultArray[3].EyeColor);
                Assert.AreEqual("41.9BBY", resultArray[3].BirthYear);
                Assert.AreEqual("male", resultArray[3].Gender);
                Assert.AreEqual("https://swapi.co/api/planets/1/", resultArray[3].Homeworld);
                Assert.AreEqual("2014-12-10T15:18:20.704000Z", resultArray[3].Created);
                Assert.AreEqual("2014-12-20T21:17:50.313000Z", resultArray[3].Edited);
                Assert.AreEqual("https://swapi.co/api/people/4/", resultArray[3].Url);

                Assert.AreEqual("Leia Organa", resultArray[4].Name);
                Assert.AreEqual("150", resultArray[4].Height);
                Assert.AreEqual("49", resultArray[4].Mass);
                Assert.AreEqual("brown", resultArray[4].HairColor);
                Assert.AreEqual("light", resultArray[4].SkinColor);
                Assert.AreEqual("brown", resultArray[4].EyeColor);
                Assert.AreEqual("19BBY", resultArray[4].BirthYear);
                Assert.AreEqual("female", resultArray[4].Gender);
                Assert.AreEqual("https://swapi.co/api/planets/2/", resultArray[4].Homeworld);
                Assert.AreEqual("2014-12-10T15:20:09.791000Z", resultArray[4].Created);
                Assert.AreEqual("2014-12-20T21:17:50.315000Z", resultArray[4].Edited);
                Assert.AreEqual("https://swapi.co/api/people/5/", resultArray[4].Url);

                Assert.AreEqual("Owen Lars", resultArray[5].Name);
                Assert.AreEqual("178", resultArray[5].Height);
                Assert.AreEqual("120", resultArray[5].Mass);
                Assert.AreEqual("brown, grey", resultArray[5].HairColor);
                Assert.AreEqual("light", resultArray[5].SkinColor);
                Assert.AreEqual("blue", resultArray[5].EyeColor);
                Assert.AreEqual("52BBY", resultArray[5].BirthYear);
                Assert.AreEqual("male", resultArray[5].Gender);
                Assert.AreEqual("https://swapi.co/api/planets/1/", resultArray[5].Homeworld);
                Assert.AreEqual("2014-12-10T15:52:14.024000Z", resultArray[5].Created);
                Assert.AreEqual("2014-12-20T21:17:50.317000Z", resultArray[5].Edited);
                Assert.AreEqual("https://swapi.co/api/people/6/", resultArray[5].Url);

                Assert.AreEqual("Beru Whitesun lars", resultArray[6].Name);
                Assert.AreEqual("165", resultArray[6].Height);
                Assert.AreEqual("75", resultArray[6].Mass);
                Assert.AreEqual("brown", resultArray[6].HairColor);
                Assert.AreEqual("light", resultArray[6].SkinColor);
                Assert.AreEqual("blue", resultArray[6].EyeColor);
                Assert.AreEqual("47BBY", resultArray[6].BirthYear);
                Assert.AreEqual("female", resultArray[6].Gender);
                Assert.AreEqual("https://swapi.co/api/planets/1/", resultArray[6].Homeworld);
                Assert.AreEqual("2014-12-10T15:53:41.121000Z", resultArray[6].Created);
                Assert.AreEqual("2014-12-20T21:17:50.319000Z", resultArray[6].Edited);
                Assert.AreEqual("https://swapi.co/api/people/7/", resultArray[6].Url);

                Assert.AreEqual("R5-D4", resultArray[7].Name);
                Assert.AreEqual("97", resultArray[7].Height);
                Assert.AreEqual("32", resultArray[7].Mass);
                Assert.AreEqual("n/a", resultArray[7].HairColor);
                Assert.AreEqual("white, red", resultArray[7].SkinColor);
                Assert.AreEqual("red", resultArray[7].EyeColor);
                Assert.AreEqual("unknown", resultArray[7].BirthYear);
                Assert.AreEqual("n/a", resultArray[7].Gender);
                Assert.AreEqual("https://swapi.co/api/planets/1/", resultArray[7].Homeworld);
                Assert.AreEqual("2014-12-10T15:57:50.959000Z", resultArray[7].Created);
                Assert.AreEqual("2014-12-20T21:17:50.321000Z", resultArray[7].Edited);
                Assert.AreEqual("https://swapi.co/api/people/8/", resultArray[7].Url);

                Assert.AreEqual("Biggs Darklighter", resultArray[8].Name);
                Assert.AreEqual("183", resultArray[8].Height);
                Assert.AreEqual("84", resultArray[8].Mass);
                Assert.AreEqual("black", resultArray[8].HairColor);
                Assert.AreEqual("light", resultArray[8].SkinColor);
                Assert.AreEqual("brown", resultArray[8].EyeColor);
                Assert.AreEqual("24BBY", resultArray[8].BirthYear);
                Assert.AreEqual("male", resultArray[8].Gender);
                Assert.AreEqual("https://swapi.co/api/planets/1/", resultArray[8].Homeworld);
                Assert.AreEqual("2014-12-10T15:59:50.509000Z", resultArray[8].Created);
                Assert.AreEqual("2014-12-20T21:17:50.323000Z", resultArray[8].Edited);
                Assert.AreEqual("https://swapi.co/api/people/9/", resultArray[8].Url);

                Assert.AreEqual("Obi-Wan Kenobi", resultArray[9].Name);
                Assert.AreEqual("182", resultArray[9].Height);
                Assert.AreEqual("77", resultArray[9].Mass);
                Assert.AreEqual("auburn, white", resultArray[9].HairColor);
                Assert.AreEqual("fair", resultArray[9].SkinColor);
                Assert.AreEqual("blue-gray", resultArray[9].EyeColor);
                Assert.AreEqual("57BBY", resultArray[9].BirthYear);
                Assert.AreEqual("male", resultArray[9].Gender);
                Assert.AreEqual("https://swapi.co/api/planets/20/", resultArray[9].Homeworld);
                Assert.AreEqual("2014-12-10T16:16:29.192000Z", resultArray[9].Created);
                Assert.AreEqual("2014-12-20T21:17:50.325000Z", resultArray[9].Edited);
                Assert.AreEqual("https://swapi.co/api/people/10/", resultArray[9].Url);
            });
        }
    }
}
