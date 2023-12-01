using Berichtsheft.Data;
using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berichtsheft.UnitTests.Services;

[TestClass]
internal class TraineeServiceTests
{
    [TestMethod]
    public void TestGetAllEntries()
    {
        Mock<ApplicationUser> mockedUser = new();
        mockedUser.Setup(x => x.Id).Returns("Test");
        Mock<ApplicationUser> mockedUser2 = new();
        mockedUser2.Setup(x => x.Id).Returns("Test");
        Mock<IReportRepository> mockedReport = new();
        mockedReport.Setup(x => x.GetAll()).Returns(new List<Report>()
        {
            new()
            {
                ID = new(),
                Creator = mockedUser.Object,
                Instructor = null,
                Entries = new List<Entry>()
                {
                    new()
                    {
                        ID = new(),
                        Text = "Test",
                        State = EReportState.Open
                    }
                }
            },
            new()
            {
                ID = new(),
                Creator = mockedUser2.Object,
                Instructor = null,
                Entries = new List<Entry>()
                {
                    new()
                    {
                        ID = new(),
                        Text = "Test2",
                        State = EReportState.Open
                    }
                }
            }
        });

        EntryDTO[] resultsEntries = new TraineeService(mockedReport.Object).GetAllEntries();

        resultsEntries.Should().HaveCount(1);
        resultsEntries.Should().AllSatisfy(entry => entry.Content.Should().Be("Test"));
    }
}
