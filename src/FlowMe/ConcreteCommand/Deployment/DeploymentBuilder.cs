using FlowMe.Persistence;
using FlowMe.Persistence.Entity;
using FlowMe.Service.Repository;

namespace FlowMe.ConcreteCommand.Deployment
{
    public class DeploymentBuilder
    {
        private readonly RepositoryService _repositoryService;

        internal BpmnDbContext BpmnDbContext { get; set; }
        internal ProcessDefinition Definition { get; } = new ProcessDefinition();

        public DeploymentBuilder(RepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
            BpmnDbContext = _repositoryService.Configuration.DbContext;
        }

        public void Deploy()
        {
            _repositoryService.Deploy(this);
        }

        public DeploymentBuilder Name(string name)
        {
            Definition.Name = name;
            return this;
        }

        public DeploymentBuilder Category(string category)
        {
            Definition.Category = category;
            return this;
        }

        public DeploymentBuilder Key(string key)
        {
            Definition.Key = key;
            return this;
        }

        public DeploymentBuilder BpmnContent(string content)
        {
            Definition.DefinitionXml = content;
            return this;
        }
    }
}