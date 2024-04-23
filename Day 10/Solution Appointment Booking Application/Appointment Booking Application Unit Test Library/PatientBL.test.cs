using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Appointment_Booking_application_BL_Library;

using Appointment_Booking_Application_Model_Library;

using AB_Appication_BL_Custom_Exception_Library;

using Appointment_Booking_Application_DAL_Library;

namespace Appointment_Booking_Application_Unit_Test_Library
{
    public class PatientBLTest
    {
        IRepository<int, Patient> repository;
        IPatientService patientService;

        [SetUp]
        public void SetUp()
        {
            repository = new PatientRepository();
            Patient patient = new Patient("sakthi", "123456678", new DateTime(2000, 10, 12), "heart");
            repository.Add(patient);
            patientService = new PatientBL(repository);
        }

        [Test]

        public void AddPatientSuccessTest()
        {
            Patient patient = new Patient("sachin", "123456678", new DateTime(2000, 10, 12), "heart");
            var result = patientService.AddPatient(patient);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void UpdatePatientSuccessTest()
        {
            Patient patient = new Patient("sakthi", "123456678", new DateTime(2000, 10, 12), "heart");
            patient.Id = 1;
            var result = patientService.UpdatePatient(patient);
            Assert.AreEqual(1, result);
        }

        [Test]

        public void UpdatePatientExceptionTest()
        {
            Patient patient = new Patient("sakthi", "123456678", new DateTime(2000, 10, 12), "heart");
            patient.Id = 5;
            var result = Assert.Throws<UpdatePatientDetailsException>(()=> patientService.UpdatePatient(patient));
            Assert.AreEqual("Error in updating the patient details , please check the given details and try again", result.Message);
        }

        [Test]

        public void GetPatientByIdSuccessTest()
        {
            var result = patientService.GetPatient(1);
            Assert.AreEqual(1, result.Id);
        }

        [Test]

        public void GetPatientByIdExceptionTest()
        {
            var result = Assert.Throws<GetPatientException>(()=>  patientService.GetPatient(10));
            Assert.AreEqual("error in getting patient details , please check the given id", result.Message);
        }

        [Test]

        public void DeletePatientSuccessTest()
        {
            var result = patientService.DeletePatient(1);
            Assert.AreEqual(1, result);
        }
        [Test]
        public void DeletePatientExceptionTest()
        {
            var result = Assert.Throws<DeletePatientDeatilsException>(()=>patientService.DeletePatient(5));
            Assert.AreEqual("Error in deleting patient details , check the given id of patient is correct", result.Message);

        }
    }
}
