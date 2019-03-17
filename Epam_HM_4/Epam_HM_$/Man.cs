using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_HM__
{
    class Man
    {
       protected string Name;
       protected int Age;
       protected string Gender;
       protected string Weight;

        public Man(string Name, int Age, string Gender, string Weight)
        {
            this.Name = Name;
            this.Age = Age;
            this.Gender = Gender;
            this.Weight = Weight;
        }

        public void ReName(string Name) => this.Name = Name;

        public void NewAge (int Age) => this.Age = Age;

        public void ReWeight(string Weight) => this.Weight = Weight;

    }
}
