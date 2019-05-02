using System;
using System.Collections.Generic;

namespace WebApi
{
    public class MyOptions
    {
        public string option1{get;set;}

        public string option2 {get;set;}

        public Dictionary<string,string> subsection {get;set;}
        
        public List<Student> student {get;set;}
    }

    public class Student
    {
        public string name {get;set;}

        public string age {get;set;}
    }

    public class Subsection
    {
        public string suboption1 {get;set;}
    }
}
