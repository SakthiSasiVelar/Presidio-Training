using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    internal class Doctor          // Doctor class
    {
        string name, id;
        int experience;

        public Doctor(string name , string id ,  int experience)   
        {
            this.name = name;
            this.id = id;
            this.experience = experience;
        }

        public  void printDoctorDetails()
        {
            Console.WriteLine($" Doctor Name  : {this.name}\n Doctor id : {this.id} \n Doctor Experience : {this.experience}");
        }
    }
}
