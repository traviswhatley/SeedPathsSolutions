using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPractice_Class4
{
    class Course
    {
        //STEP 1. Declare properties
        public string Name { get; set; }
        public int GradePoints { get; set; }

        //Declare a custom property for 
        // letter grade
        private string _letterGrade;

        public string LetterGrade
        {
            get { return _letterGrade; }
            set 
            { 
                _letterGrade = value.ToUpper();
                //letter grade was set
                // update the grade points
                if (_letterGrade == "A")
                {
                    this.GradePoints = 4;
                }
                else if (_letterGrade == "B")
                {
                    this.GradePoints = 3;
                }
                else if (_letterGrade == "C")
                {
                    this.GradePoints = 2;
                }
                else if (_letterGrade == "D")
                {
                    this.GradePoints = 1;
                }
                else
                {
                    //assume fail
                    this.GradePoints = 0;
                }
            }
        }
        
        //STEP 2. Constructors
        public Course(string name, string letterGrade)
        {
            //set the name of the course
            this.Name = name;
            //set the letter grade
            this.LetterGrade = letterGrade;
            //the setter for letterGrade, will
            // automatically set the GradePoints
        }

        //STEP 3. Methods and/or Functions
        public string GetCourseInfo()
        {
            return this.Name + " " + this.LetterGrade + " " + this.GradePoints;
        }


        
    }
}
