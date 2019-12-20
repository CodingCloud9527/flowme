using System.IO;
using FlowMe.Model.Loader;
using Xunit;

namespace FlowMe.Test.Model
{
    public class BpmnLoaderTest
    {
        [Fact]
        public void Should_Load_Correctly()
        {
            var bpmnContent = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "sample.xml"));
            BpmnLoader.Load(bpmnContent);
        }
    }
}