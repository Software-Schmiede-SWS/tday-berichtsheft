using Berichtsheft.Data;
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
        Mock<IReportRepository> repoMock = new();
        repoMock.Setup(x => x.GetAll()).Returns(new List<Report>()
        {
            new Report()
            {
                ID = "1",
                KW = 1,
                State = EState.NotSubmitted.,
                Entries = new List<Entry>()
                {
                    new Entry()
                    {
                        ID = "1",
                        Content = "Test",
                        ReportID = "1"
                    }
                }
            }
        });
    }
}
