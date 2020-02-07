using AzureDevOpsRest.Data;

namespace AzureDevOpsRest.Requests
{
    public static class WorkItems
    {
        public static Request<WorkItemQueryResult> Query() =>
            new Request<WorkItemQueryResult>("_apis/wit/wiql", "5.1");
    }
}