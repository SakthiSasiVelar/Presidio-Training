using Appointment_Booking_Application_Model_Library;

using Appointment_Booking_Application_DAL_Library;

using Appointment_Booking_application_BL_Library;
using System.Numerics;
using AB_Appication_BL_Custom_Exception_Library;



namespace Appoint_Booking_Unit_Test_Library
{
    public class DoctorBLTest
    {
        IRepository<int, Doctor> repository;
        IDoctorService doctorService;

        [SetUp]
        public void Setup()
        {
            repository = new DoctorRepository();
            List<DateTime> dates = new List<DateTime>
            {
                new DateTime(2022, 4, 1),
                new DateTime(2022, 4, 15),
                new DateTime(2022, 4, 30)
            };
            Doctor doctor1 = new Doctor("sakthi", "9361253164", "heart", dates);
            Doctor doctor2 = new Doctor("sachin", "9361253164", "heart", dates);
            repository.Add(doctor1);
            repository.Add(doctor2 );
            doctorService = new DoctorBL(repository);
        }

        [Test]
        public void AddDoctorSuccessTest()
        {
            List<DateTime> dates = new List<DateTime>
            {
                new DateTime(2022, 4, 1),
                new DateTime(2022, 4, 15),
                new DateTime(2022, 4, 30)
            };
            var result = doctorService.AddDoctor(new Doctor("sasi", "9361253164", "heart", dates));
            Assert.AreEqual(3, result);
        }

        [Test]

        public void GetDoctorByIdSuccessTest()
        {
            var result = doctorService.GetDoctor(1);
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void GetDoctorByIdExceptionTest()
        {
            var result = Assert.Throws<GetDoctorException>(()=> doctorService.GetDoctor(3));
            Assert.AreEqual("error in getting doctor details , please check the given id" , result.Message);

        }
        [Test]

        public void GetAllDoctorSuccessTest()
        {
            var result = doctorService.GetAllDoctors();
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetAllDoctorExceptionTest()
        {
            IRepository<int, Doctor> repository2 = new DoctorRepository();
            IDoctorService doctorService2 = new DoctorBL(repository2);

            var result = Assert.Throws<GetAllDoctorException>(()=>doctorService2.GetAllDoctors());
            Assert.AreEqual("Error in fetching all doctors list , please try again", result.Message);
        }

        [Test]

        public void UpdateDoctorSuccessTest()
        {
            List<DateTime> dates = new List<DateTime>
            {
                new DateTime(2022, 4, 1),
                new DateTime(2022, 4, 15),
                new DateTime(2022, 4, 30)
            };
            Doctor doctor = new Doctor("rohit", "9361253164", "heart", dates);
            doctor.Id = 1;

            var result = doctorService.UpdateDoctor(doctor);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void UpdateDoctorExceptionTest()
        {
            List<DateTime> dates = new List<DateTime>
            {
                new DateTime(2022, 4, 1),
                new DateTime(2022, 4, 15),
                new DateTime(2022, 4, 30)
            };
            Doctor doctor = new Doctor("rohit", "9361253164", "heart", dates);
            doctor.Id = 10;

            var result = Assert.Throws<UpdateDoctorDeatilsException>(()=>doctorService.UpdateDoctor(doctor));
            Assert.AreEqual("Error in updating the doctor details , please check the given details and try again", result.Message);
        }

        [Test]

        public void DeleteDoctorSuccessTest()
        {
            var result = doctorService.DeleteDoctor(1);
            Assert.AreEqual(1, result);
        }

        [Test]

        public void DeleteDoctorExceptionTest()
        {
            var result = Assert.Throws<DeleteDoctorDetailsException>(()=>doctorService.DeleteDoctor(5));
            Assert.AreEqual("Error in deleting doctor details , check the given id of doctor is correct" ,  result.Message);
        }
    }
}