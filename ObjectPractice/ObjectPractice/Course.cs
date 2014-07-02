using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPractice
{
    class Course
    {
        //Defining the Properties of our class
        public string CourseName { get; set; }
        public int GradePoints { get; set; }
        
        //declaring a custom property for LetterGrade
        // Custom properties need to have it's own
        // private variable declared.
        // Code Snippet: propfull <tab><tab>
        private string _letterGrade;
        public string LetterGrade
        {
            get { 
                return _letterGrade; 
            }
            set 
            {
                _letterGrade = value;   
                //Letter Grade was set, change the 
                // value of the GradePoints.
                //if grade = A, set GP to 4
                if (value == "A")
                {
                    this.GradePoints = 4;
                }
                //if Grade = B, set GP to 3
                else if (value == "B")
                {
                    this.GradePoints = 3;
                }
                else if (value == "C")
                {
                    this.GradePoints = 2;
                }
                else if (value == "D")
                {
                    this.GradePoints = 1;
                }
                else
                {
                    //not an A, B, C, or D, must be an F.
                    this.GradePoints = 0;
                }
            }
        }

        //Declare our constructor
        public Course(string name, string grade)
        {
            this.CourseName = name;
            // setting the letter Grade automatically 
            // sets the GradePoints via the property's
            // setter.
            this.LetterGrade = grade;
        }
    }
}
