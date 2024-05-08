using Appointment_Booking_Application_DAL_Library.Models;
using Appointment_Booking_application_BL_Library;
using AB_Appication_BL_Custom_Exception_Library;

namespace AppointmentBookingBLTest_Library
{
    public class DoctorBLTests
    {
        AppointmentBookingDbContext context;
        DoctorBL doctorBL;

        [SetUp]        
        
        public void Setup()
        {
            context = new AppointmentBookingDbContext();
            doctorBL = new DoctorBL(context);
        }

        [Test]
        public void AddDoctorSuccessTest()
        {
            Doctor doctor = new Doctor(9 , "rohit" , "12345", "brain");
            doctorBL.AddDoctor(doctor);

            var checkAddDoctor = context.Doctors.Find(2);
            Assert.AreEqual( "rohit" , checkAddDoctor.Name);
        }

        [Test]

        public void AddDoctorExceptionTest()
        {
            Doctor doctor = new Doctor(1, "rohit", "12345", "brain");
            doctorBL.AddDoctor(doctor);

            var result = Assert.Throws<AddDoctorDetailsException>(() => doctorBL.AddDoctor(doctor));
            //Assert.AreEqual("Error in adding doctor details , check the details given by you", result.Message);
        }
        [TearDown]
        public void TearDown()
        {
            
            context.Dispose();
        }
    }
}