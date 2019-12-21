using System;
using System.Linq;
using FlowMe.Persistence;
using FlowMe.Persistence.Entity;

namespace FlowMe.Engine.Operation.Definition.Deployment
{
    public class DeploymentBuilder
    {
        private readonly ProcessDefinition _definition = new ProcessDefinition();

        private readonly BpmnDbContext _dbContext;

        public DeploymentBuilder(ProcessEngineConfiguration configuration)
        {
            _dbContext = configuration.DbContext;
        }

        public void Deploy()
        {
            if (string.IsNullOrWhiteSpace(_definition.Key) || string.IsNullOrWhiteSpace(_definition.DefinitionXml) ||
                string.IsNullOrWhiteSpace(_definition.Name))
            {
                throw new ArgumentException($"Some property of deployment must not be null!");
            }

            var deploymentDb = _dbContext.ProcessDeployments;
            var definitionDb = _dbContext.ProcessDefs;

            var def = deploymentDb.FirstOrDefault(e => e.Name == _definition.Name);

            if (def == null)
            {
                var processDeployment = new ProcessDeployment
                {
                    Category = _definition.Category,
                    DeployTime = DateTime.UtcNow,
                    Name = _definition.Name
                };
                deploymentDb.Add(processDeployment);
                _definition.Version = 1;
                _definition.Deployment = processDeployment;
                definitionDb.Add(_definition);
            }
            else
            {
                var processDefinition = definitionDb.First(e => e.Name == _definition.Name);
                processDefinition.Version++;
                definitionDb.Update(processDefinition);
            }
        }

        public DeploymentBuilder Name(string name)
        {
            _definition.Name = name;
            return this;
        }

        public DeploymentBuilder Category(string category)
        {
            _definition.Category = category;
            return this;
        }

        public DeploymentBuilder Key(string key)
        {
            _definition.Key = key;
            return this;
        }

        public DeploymentBuilder BpmnContent(string content)
        {
            _definition.DefinitionXml = content;
            return this;
        }
    }
}