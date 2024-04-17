using Appointment_Booking_Application_Model_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Appointment_Booking_Application_Model_Library;

namespace Appointment_Booking_Application_DAL_Library
{
    public class DoctorRepository :IRepository<int , Doctor>
    {
        readonly Dictionary<int, Doctor> _doctors;

        public DoctorRepository()
        {
            _doctors = new Dictionary<int, Doctor>();
        }

        int GenerateId()
        {
            if (_doctors.Count == 0) return 1;
            int id = _doctors.Keys.Max();
            return ++id;
        }
        public Doctor Add(Doctor item)
        {
            if (_doctors.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _doctors.Add(item.Id, item);
            return item;
        }

        public Doctor Delete(int key)
        {
            if (_doctors.ContainsKey(key))
            {
                Doctor Doctor = _doctors[key];
                _doctors.Remove(key);
                return Doctor;
            }
            return null;
        }

        public Doctor Get(int key)
        {
            if (_doctors.ContainsKey(key))
            {
                return _doctors[key];
            }
            return null;
        }

        public List<Doctor> GetAll()
        {
            if (_doctors.Count > 0)
            {
                return _doctors.Values.ToList();
            }
            return null;
        }

        public Doctor Update(Doctor item)
        {
            if (_doctors.ContainsKey(item.Id))
            {
                _doctors[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
