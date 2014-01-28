using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NestedGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Fruit fruit = new Fruit();
            fruit.Color = 3;
            fruit.Name = "Apple";
            fruit.Types = new Type { FruitType = "as", Quantity = 2222 };

            List<Type> types = new List<Type>();
            types.Add(new Type { FruitType = "f1", Quantity = 2000 });
            types.Add(new Type { FruitType = "f2", Quantity = 3000 });

            fruit.ListTypes = types;

            List<Fruit> fruits = new List<Fruit>();
            fruits.Add(fruit);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = fruits;
        }
    }
}
