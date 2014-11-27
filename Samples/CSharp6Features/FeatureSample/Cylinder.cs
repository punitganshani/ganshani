using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathSample
{
    public class Cylinder
    {
        //TODO: PI can be introduced as const

        private readonly double radius, height;
        public double Radius { get { return radius; } }

        public double Height { get { return height; } }

        //TODO: Area can be calculated at init only
        public Cylinder(double radius, double height)
        {
            this.radius = radius;
            this.height = height;
        }

        //TODO: Too much code for simple one line
        public double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

        public double CalculateVolume()
        {
            return CalculateArea() * height;
        }
    }
}
