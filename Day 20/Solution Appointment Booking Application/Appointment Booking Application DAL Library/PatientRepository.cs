using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Appointment_Booking_Application_Model_Library;

namespace Appointment_Booking_Application_DAL_Library
{
    public class PatientRepository : IRepository<int, Patient>
    {
        readonly Dictionary<int, Patient> _patients;

        public PatientRepository()
        {
            _patients = new Dictionary<int, Patient>(); 
        }

        int GenerateId()
        {
            if (_patients.Count == 0) return 1;
            int id = _patients.Keys.Max();
            return ++id;
        }
        public Patient Add(Patient item)
        {
            if (_patients.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _patients.Add(item.Id, item);
            return item;
        }

        public Patient Delete(int key)
        {
            if (_patients.ContainsKey(key))
            {
                Patient patient = _patients[key];
                _patients.Remove(key);
                return patient;
            }
            return null;
        }

        public Patient Get(int key)
        {
            if(_patients.ContainsKey(key))
            {
                return _patients[key];
            }
            return null;
        }

        public List<Patient> GetAll()
        {
            if(_patients.Count > 0)
            {
               return _patients.Values.ToList();
            }
            return null;
        }

        public Patient Update(Patient item)
        {
            if(_patients.ContainsKey(item.Id))
            {
                _patients[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
