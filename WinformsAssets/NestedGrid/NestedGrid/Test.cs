using System.ComponentModel;

namespace NestedGrid
{
    [Browsable(true)]
    public class Type
    {
        [Browsable(false)]
        public string FruitType { get; set; }

        [Browsable(true)]
        public int Quantity { get; set; }

    }
}
