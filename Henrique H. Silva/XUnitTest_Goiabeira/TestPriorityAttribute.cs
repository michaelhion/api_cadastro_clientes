using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTest_Goiabeira
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    class TestPriorityAttribute : Attribute
    {
        public int Priority { get; private set; }

        public TestPriorityAttribute(int priority) => Priority = priority;
    }
}
