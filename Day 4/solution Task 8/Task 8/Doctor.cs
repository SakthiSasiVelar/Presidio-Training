using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8
{
    /// <summary>
    /// Doctor class conatins info of doctors
    /// </summary>
    /// <param name="Id">Id of the doctor</param>
    /// <param name="Name">Name of the doctor</param>
    /// <param name="Age">Age of the doctor</param>
    /// <param name="Experience">Experience of the doctor</param>
    /// <param name="Qualification">Qualification of the doctor</param>
    /// <param name="Speciality">Speciality of the doctor</param>
    /// 
    internal class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }

        public Doctor(int id , String name , int age , string speciality , string qualification , int experience)     //initializing data members of the class
        {
            Id = id;
            Name = name;
            Age = age;
            Speciality = speciality;
            Qualification = qualification;
            Speciality = speciality;
            Experience = experience;
        }

    }
}
