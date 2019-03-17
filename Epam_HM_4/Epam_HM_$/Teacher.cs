using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_HM__
{
    class Teacher : Man
    {

        int WorkExperience;

        public Teacher(string Name, int Age, string Gender, string Weight, int WorkExperience) : base(Name, Age, Gender, Weight)
        {
            this.WorkExperience = WorkExperience;
        }

        public void IncWorkExperience(int PlusExp) => this.WorkExperience += PlusExp;

        public void DecWorkExperience(int MinusExp) => this.WorkExperience -= MinusExp;

        public new void ReName(string Name) => this.Name = Name;

        public new void NewAge(int Age) => this.Age = Age;

        public new void ReWeight(string Weight) => this.Weight = Weight;
    }
}
