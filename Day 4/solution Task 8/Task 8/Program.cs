namespace Task_8
{
    internal class Program
    {

        // getting input from user
        static int GetNumberInput()
        {
            int numInput;
            while (!int.TryParse(Console.ReadLine(), out numInput))
            {
                Console.WriteLine("Please enter only the number");
            }
            return numInput;
        }

        //getting doctor details

        static Doctor GetDoctorDetail(int sno)
        {
            int id = 1001 + sno;
            Console.WriteLine("Enter doctor name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter doctor age : ");
            int age = GetNumberInput();
            Console.WriteLine("Enter speciality of the doctor : ");
            string speciality = Console.ReadLine();
            Console.WriteLine("Enter qualification of the doctor : ");
            string qualification = Console.ReadLine();
            Console.WriteLine("Enter the experience of the doctor : ");
            int experience = GetNumberInput();

            Doctor doctor = new Doctor(id, name, age, speciality, qualification, experience);

            return doctor;

        }

        //Printing details of the doctor 
        static void PrintDoctorDetails(Doctor doctor)
        {
            Console.WriteLine($" Doctor id : {doctor.Id}\n Doctor name : {doctor.Name}\n Doctor age : {doctor.Age}\n Doctor qualification : {doctor.Qualification}\n Doctor experience : {doctor.Experience}\n Doctor speciality : {doctor.Speciality}");
        }

        //getting details of allDoctors

        static void PrintAllDoctorsDetails(Doctor[] doctorList , int sizeOfDoctorsList)
        {
            Console.WriteLine("------------ Print All doctors details ---------- ");
            for (int i=0;i<sizeOfDoctorsList;i++)
            {
                PrintDoctorDetails(doctorList[i]);
                Console.WriteLine("\n");
            }
        }

        //checking the matching of speciality for given doctor

        static bool IsGivenSpecialityMatchDoctor(Doctor doctor , string specialityGivenByUser)
        {
            return doctor.Speciality == specialityGivenByUser;
        }

        // getting doctor list for given speciality

        static void FindDoctorsForTheSpecialityGivenByUser(Doctor[] doctorList , int noOfDoctors)
        {
            Console.WriteLine("Enter the speciality to print doctor details : ");
            string specialityGivenByUser = Console.ReadLine();
            bool isSpecialityGivenByUserMatches = false;

            for(int i=0;i<noOfDoctors;i++)
            {
                if (IsGivenSpecialityMatchDoctor(doctorList[i] , specialityGivenByUser))
                {
                    if (!isSpecialityGivenByUserMatches)
                    {
                        Console.WriteLine("---------Details of the doctor for the given speciality-----");
                    }
                    PrintDoctorDetails(doctorList[i]);
                    isSpecialityGivenByUserMatches = true;
                }
            }
            if(!isSpecialityGivenByUserMatches)
            {
                Console.WriteLine("Speciality given by user does not match any doctors in the list.");
            }
        }

        //setting doctor details

        static Doctor[] SetDoctorDetails(int noOfDoctors)
        {
            Doctor[] doctorList = new Doctor[noOfDoctors];
            for (int i = 0; i < noOfDoctors; i++)
            {
                doctorList[i] = GetDoctorDetail(i);
            }
            return doctorList;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter no of Doctors details u need to store : ");
            int noOfDoctors = GetNumberInput();
            Doctor[] doctorList = SetDoctorDetails(noOfDoctors);
            PrintAllDoctorsDetails(doctorList, noOfDoctors);
            FindDoctorsForTheSpecialityGivenByUser(doctorList , noOfDoctors);  
        }
    }
}
