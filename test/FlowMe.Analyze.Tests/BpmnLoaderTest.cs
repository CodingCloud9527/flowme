using System.IO;
using FlowMe.Analyze.Loader;
using Xunit;

namespace FlowMe.Analyze.Tests
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