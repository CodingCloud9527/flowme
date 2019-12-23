using System;
using System.Linq;
using FlowMe.Command;
using FlowMe.Command.Context;
using FlowMe.Persistence.Entity;
using Microsoft.EntityFrameworkCore;

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

            var deployment = deploymentDb.FirstOrDefault(e => e.Name == definition.Name);

            if (deployment == null)
            {
                var processDeployment = new ProcessDeployment
                {
                    Category = definition.Category,
                    DeployTime = DateTime.UtcNow,
                    Name = definition.Name
                };
                deploymentDb.Add(processDeployment);
                definition.Version = 1;
                definition.Deployment = processDeployment;
                definitionDb.Add(definition);
            }
            else
            {
                deployment.DeployTime = DateTime.UtcNow;
                var processDefinition = definitionDb.Include(e => e.Deployment).OrderByDescending(e => e.Version).First(e => e.Name == definition.Name);
                processDefinition.Id = 0;
                processDefinition.Version++;
                definitionDb.Add(processDefinition);
            }

            return 0;
        }
    }
}