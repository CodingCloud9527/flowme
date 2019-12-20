namespace FlowMe.Model.Loader
{
    public static class BpmnLoader
    {
        public static IBpmnModel Load(string bpmnContent)
        {
            return new BpmnModel(bpmnContent);
        }
    }
}