namespace FlowMe.Service.Repository
{
    public class RepositoryService : ServiceBase, IRepositoryService
    {
        public DeploymentBuilder CreateDeployment()
        {
            return new DeploymentBuilder(Configuration);
        }
    }
}