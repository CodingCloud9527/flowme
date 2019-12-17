using System.Collections.Generic;

namespace FlowMe.Core.Task
{
    public interface ITaskQueryable
    {
        ITaskAction Single { get; }
        List<ITaskAction> All { get; }
        int Count { get; }

        ITaskQueryable WithProcName(params string[] procNames);
        ITaskQueryable WithReceiver(params string[] userIds);
    }
}