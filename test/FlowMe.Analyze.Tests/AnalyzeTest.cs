using System;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace FlowMe.Analyze.Tests
{
    public class AnalyzeTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public AnalyzeTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test_Load_Xml_File()
        {
            _testOutputHelper.WriteLine(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(),"sample.bpmn")));
        }
    }
}