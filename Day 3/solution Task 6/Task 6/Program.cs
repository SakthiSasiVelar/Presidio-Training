namespace Task_6
{
    internal class Program
    {

        //get doctor info
        static void GetDoctorDetails(out string name , out string id , out int experience)
        {
            Console.WriteLine("Enter Doctor's Name : ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Doctor's id : ");
            id = Console.ReadLine();
            Console.WriteLine("Enter Doctors's experience :");
            experience = Convert.ToInt32(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            string name, id;
            int experience;

            GetDoctorDetails(out name, out id , out experience);
            Doctor doctor  = new Doctor(name, id, experience);
            doctor.PrintDoctorDetails();
        }
    }
}
