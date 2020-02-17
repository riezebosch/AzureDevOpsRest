using System.Linq;
using AzureDevOpsRest.Data;
using AzureDevOpsRest.Data.WorkItems;

namespace AzureDevOpsRest.Requests
{
    public static class WorkItems
    {
        public static Request<WorkItemQueryResult> Query() =>
            new Request<WorkItemQueryResult>("_apis/wit/wiql", "5.1");

        public static IRequest<WorkItem> WorkItem(int id, params string[] fields) => 
            new Request<WorkItem>("_apis/wit/workitems", "5.1")
                .WithQueryParams(("id", id))
                .WithQueryParams(("fields", string.Join(",", fields)));
    }
}