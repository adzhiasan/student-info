using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentINFO.Models
{
    public class PerformanceTable
    {
        private List<(Student, int?[])> table = new List<(Student, int?[])>();
        public List<(Student, int?[])> Table
        {
            get { return table; }
            set { table = value; }
        }
        public PerformanceTable() { }
        public Student GetStudent(int noteIndex)
        {
            return Table[noteIndex].Item1;
        }

        public int?[] GetGrades(int studentIndex)
        {
            return Table[studentIndex].Item2;
        }
    }
}