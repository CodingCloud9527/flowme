namespace FlowMe.Event
{
    public static class ProcessEngineEventConst
    {
        public const string JOB_CANCELED = "JOB_CANCELED";

        public const string JOB_EXECUTION_SUCCESS = "JOB_EXECUTION_SUCCESS";

        public const string JOB_EXECUTION_FAILURE = "JOB_EXECUTION_FAILURE";

        public const string JOB_RETRIES_DECREMENTED = "JOB_RETRIES_DECREMENTED";

        public const string ENGINE_CREATED = "ENGINE_CREATED";

        public const string ENGINE_CLOSED = "ENGINE_CLOSED";

        public const string ACTIVITY_STARTED = "ACTIVITY_STARTED";

        public const string ACTIVITY_COMPLETED = "ACTIVITY_COMPLETED";

        public const string ACTIVITY_CANCELLED = "ACTIVITY_CANCELLED";

        public const string ACTIVITY_SIGNALED = "ACTIVITY_SIGNALED";

        public const string ACTIVITY_COMPENSATE = "ACTIVITY_COMPENSATE";

        public const string ACTIVITY_MESSAGE_WAITING = "ACTIVITY_MESSAGE_WAITING";

        public const string ACTIVITY_MESSAGE_RECEIVED = "ACTIVITY_MESSAGE_RECEIVED";

        public const string ACTIVITY_ERROR_RECEIVED = "HISTORIC_ACTIVITY_INSTANCE_CREATED";

        public const string HISTORIC_ACTIVITY_INSTANCE_CREATED = "HISTORIC_ACTIVITY_INSTANCE_CREATED";

        public const string HISTORIC_ACTIVITY_INSTANCE_ENDED = "HISTORIC_ACTIVITY_INSTANCE_ENDED";

        public const string SEQUENCEFLOW_TAKEN = "SEQUENCEFLOW_TAKEN";

        public const string UNCAUGHT_BPMN_ERROR = "UNCAUGHT_BPMN_ERROR";

        public const string VARIABLE_CREATED = "VARIABLE_CREATED";

        public const string VARIABLE_UPDATED = "VARIABLE_UPDATED";

        public const string VARIABLE_DELETED = "VARIABLE_DELETED";

        public const string TASK_CREATED = "TASK_CREATED";

        public const string TASK_ASSIGNED = "TASK_ASSIGNED";

        public const string TASK_COMPLETED = "TASK_COMPLETED";

        public const string PROCESS_STARTED = "PROCESS_COMPLETED";

        public const string PROCESS_COMPLETED = "PROCESS_COMPLETED";

        public const string PROCESS_COMPLETED_WITH_ERROR_END_EVENT = "PROCESS_COMPLETED_WITH_ERROR_END_EVENT";

        public const string PROCESS_CANCELLED = "PROCESS_CANCELLED";

        public const string HISTORIC_PROCESS_INSTANCE_CREATED = "HISTORIC_PROCESS_INSTANCE_CREATED";

        public const string HISTORIC_PROCESS_INSTANCE_ENDED = "HISTORIC_PROCESS_INSTANCE_ENDED";
    }
}