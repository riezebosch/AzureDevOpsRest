using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using AzureDevOpsRest.Data;
using AzureDevOpsRest.Data.WorkItems;
using FluentAssertions;
using Xunit;

namespace AzureDevOpsRest.Requests.Tests
{
    public class WorkItemTests : IClassFixture<TestConfig>
    {
        private readonly Client _client;

        public WorkItemTests(TestConfig config) => _client = new Client(config.Organization, config.Token);

        [Fact]
        public async Task Query()
        {
            var result = await _client.PostAsync(WorkItems.Query(), new WorkItemQuery { Query = "Select [System.Id] FROM WorkItems" });

           result.WorkItems.Should().NotBeEmpty();
           result
               .WorkItems
               .First()
               .Id
               .Should()
               .NotBe(default);
        }

        [Fact]
        public async Task Get()
        {
            var result = await _client.PostAsync(WorkItems.Query(),
                new WorkItemQuery {Query = "Select [System.Id] FROM WorkItems"});

            var item = await _client.GetAsync(WorkItems.WorkItem(result.WorkItems.First().Id, "System.Id"));

            item
                .Id
                .Should()
                .NotBe(default);

            item
                .Fields
                .Should()
                .ContainKeys("System.Id");
        }
    }
}