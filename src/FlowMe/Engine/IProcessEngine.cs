﻿using FlowMe.Engine.Operation;

namespace FlowMe.Engine
{
    public interface IProcessEngine
    {
        ITaskOp TaskOp { get; }
        IRuntimeOp RuntimeOp { get; }
        IHisOp HisOp { get; }
        IDeployOp DeployOp { get; }
        
        ICommonOp CommonOp { get; }
    }
}