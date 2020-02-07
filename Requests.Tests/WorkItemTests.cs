using System.Linq;
using System.Threading.Tasks;
using AzureDevOpsRest.Data;
using FluentAssertions;
using Xunit;

namespace AzureDevOpsRest.Requests.Tests
{
    public class WorkItemTests : IClassFixture<TestConfig>
    {
        private readonly TestConfig _config;

        public WorkItemTests(TestConfig config) => _config = config;

        [Fact]
        public async Task Query()
        {
           var client = new Client(_config.Organization, _config.Token);
           var result = await client.PostAsync(WorkItems.Query(), new WorkItemQuery { Query = "Select [System.Id] FROM WorkItems" });

           result.WorkItems.Should().NotBeEmpty();
           result
               .WorkItems
               .First()
               .Id
               .Should()
               .NotBe(default);
        }
    }
}