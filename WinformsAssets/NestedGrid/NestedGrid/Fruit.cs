using System.ComponentModel;
using System.Collections.Generic;

namespace NestedGrid
{
    public class Fruit
    {
        public string Name { get; set; }
        public int Color { get; set; }

        [Browsable(true)]
        public Type Types { get; set; }

        public List<Type> ListTypes { get; set; }
    }
}
