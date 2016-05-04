using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelatrixTest.UnitTest.Injectors;

namespace BelatrixTest.UnitTest.Interfaces
{
    public interface ITest
    {
        List<TestResult> GetResults();
    }
}
