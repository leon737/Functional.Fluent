using System.Collections.Generic;
using Functional.Fluent.Records;

namespace FluentTests.Records
{
    public class SimpleTypeWithCollection : Record<SimpleTypeWithCollection>
    {
        public int IntProperty { get; set; }

        public ICollection<int> IntCollection { get; set; }
    }
}