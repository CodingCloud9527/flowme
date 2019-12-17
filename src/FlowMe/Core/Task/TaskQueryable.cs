using System;
using System.Collections.Generic;
using FlowMe.Persistence;

namespace FlowMe.Core.Task
{
    class TaskQueryable : ITaskQueryable
    {
        private readonly BpmnDbContext _dbContext;

        public TaskQueryable()
        {
            _dbContext = new BpmnDbContext();
        }

        public ITaskAction Single { get; }
        public List<ITaskAction> All { get; }
        public int Count { get; }

        public ITaskQueryable WithProcName(params string[] procNames)
        {
            throw new NotImplementedException();
        }

        public ITaskQueryable WithReceiver(params string[] userIds)
        {
            throw new NotImplementedException();
        }
    }
}