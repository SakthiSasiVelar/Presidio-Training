using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System.Reflection;

namespace RequestTrackerBLLibrary
{
    public class EmployeeLoginBL : IEmployeeLoginBL
    {
        private readonly IRepository<int, Employee> _repository;
        public EmployeeLoginBL()
        {
            IRepository<int, Employee> repo = new EmployeeRequestRepository(new RequestTrackerContext());
            _repository = repo;
        }

        public async Task<Employee> Login(Employee employee)
        {
           
           var emp = await _repository.GetById(employee.Id);
            if (emp != null)
            {
                if (emp.Password == employee.Password)
                    return emp;
            }
            return null;
        }

        public async Task<Employee> Register(Employee employee)
        {
            try
            {
                var result = await _repository.Add(employee);
                if(result != null)
                {
                    return result;
                }
                throw new Exception("Cannot get employee details");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in registering employee");
            }
            
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                var emp = await _repository.GetById(id);
                if (emp != null)
                {
                    return emp;
                }
                throw new Exception("Employee id is wrong");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
