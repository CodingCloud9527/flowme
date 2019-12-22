using System;
using System.Linq;
using FlowMe.Command;
using FlowMe.Command.Context;
using FlowMe.Persistence.Entity;

namespace FlowMe.ConcreteCommand.Deployment
{
    public class DeployCmd : ICommand<int>
    {
        private readonly DeploymentBuilder _deploymentBuilder;

        public DeployCmd(DeploymentBuilder deploymentBuilder)
        {
            _deploymentBuilder = deploymentBuilder;
        }

        public int Execute(CommandContext commandContext)
        {
            var definition = _deploymentBuilder.Definition;
            var dbContext = _deploymentBuilder.BpmnDbContext;
            if (string.IsNullOrWhiteSpace(definition.Key) || string.IsNullOrWhiteSpace(definition.DefinitionXml) ||
                string.IsNullOrWhiteSpace(definition.Name))
            {
                throw new ArgumentException("Some property of deployment must not be null!");
            }

            var deploymentDb = dbContext.ProcessDeployments;
            var definitionDb = dbContext.ProcessDefs;

            var def = deploymentDb.FirstOrDefault(e => e.Name == definition.Name);

            if (def == null)
            {
                var processDeployment = new ProcessDeployment
                {
                    Category = definition.Category,
                    DeployTime = DateTime.UtcNow,
                    Name = definition.Name
                };
                processDeployment.Id = processDeployment.Name; // TODO: remember to delete 
                deploymentDb.Add(processDeployment);
                definition.Version = 1;
                definition.Deployment = processDeployment;
                definition.Id = definition.Name; // TODO: remember to delete 
                definitionDb.Add(definition);
            }
            else
            {
                var processDefinition = definitionDb.First(e => e.Name == definition.Name);
                processDefinition.Version++;
                definitionDb.Update(processDefinition);
            }

            return 0;
        }
    }
}