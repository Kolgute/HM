using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_HM__
{
    class Student : Man
    {
        int YeaOfStudy;

        public Student (string Name, int Age, string Gender, string Weight, int YeaOfStudy) : base (Name,Age,Gender,Weight)
        {
            this.YeaOfStudy = YeaOfStudy;
        }

        public new void ReName(string Name) => this.Name = Name;

        public new void NewAge(int Age) => this.Age = Age;

        public new void ReWeight(string Weight) => this.Weight = Weight;

        public void NewYearOfStudy(int YeaOfStudy) => this.YeaOfStudy = YeaOfStudy;

        public void IncYear() => YeaOfStudy++;

        public void IncYear(int PlusYear) => YeaOfStudy += PlusYear;

        public void DecYear() => YeaOfStudy--;

        public void DecYear(int MinusYear) => YeaOfStudy -= MinusYear;



    }
}
