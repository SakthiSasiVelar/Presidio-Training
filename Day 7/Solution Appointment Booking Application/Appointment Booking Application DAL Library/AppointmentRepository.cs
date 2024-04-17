using Appointment_Booking_Application_Model_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Appointment_Booking_Application_Model_Library;

namespace Appointment_Booking_Application_DAL_Library
{
    public class AppointmentRepository
    {
        readonly Dictionary<int, Appointment> _appointments;

        public AppointmentRepository()
        {
            _appointments = new Dictionary<int, Appointment>();
        }

        int GenerateId()
        {
            if (_appointments.Count == 0) return 1;
            int id = _appointments.Keys.Max();
            return ++id;
        }
        public Appointment Add(Appointment item)
        {
            if (_appointments.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _appointments.Add(item.Id, item);
            return item;
        }

        public Appointment Delete(int key)
        {
            if (_appointments.ContainsKey(key))
            {
                Appointment Appointment = _appointments[key];
                _appointments.Remove(key);
                return Appointment;
            }
            return null;
        }

        public Appointment Get(int key)
        {
            if (_appointments.ContainsKey(key))
            {
                return _appointments[key];
            }
            return null;
        }

        public List<Appointment> GetAll()
        {
            if (_appointments.Count > 0)
            {
                return _appointments.Values.ToList();
            }
            return null;
        }

        public Appointment Update(Appointment item)
        {
            if (_appointments.ContainsKey(item.Id))
            {
                _appointments[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
}
