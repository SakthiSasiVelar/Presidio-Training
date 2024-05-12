using RequestTrackerBLLibrary;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System.Threading.Channels;

namespace RequestTrackerFEAPP
{
    internal class RequestTrackerApp
    {
        IEmployeeLoginBL employeeLoginBL;

        public RequestTrackerApp()
        {
            employeeLoginBL = new EmployeeLoginBL();
        }

        async Task CallEmployee(Employee employee)
        {
            if(employee.Role.ToLower() == "admin")
            {
                await new Admin().StartAdmin(employee);
            }
            else if(employee.Role.ToLower() == "user")
            {
                await new User().StartUser(employee);
            }
        }
        async Task EmployeeLoginAsync(int username, string password)
        {
            try
            {
                Employee employee = new Employee() { Password = password, Id = username };
                var result = await employeeLoginBL.Login(employee);
                if (result != null)
                {
                    await Console.Out.WriteLineAsync("Login Success");
                    await CallEmployee(result);
                    
                }
                else
                {
                    Console.Out.WriteLine("Invalid username or password");
                }
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
           
        }
        async Task GetLoginDeatils()
        {
            await Console.Out.WriteLineAsync("-------Login-------");
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            await EmployeeLoginAsync(id,password);
        }

        async Task GetRegisterDetails()
        {
            await Console.Out.WriteLineAsync("-------Register-------");
            await Console.Out.WriteLineAsync("Enter your name :");
            string name = Console.ReadLine();
            await Console.Out.WriteLineAsync("Create password :");
            string password = Console.ReadLine();
            await Console.Out.WriteLineAsync("Choose your role :\n 1.Admin\n 2.User");
            int roleChoice = Convert.ToInt32(Console.ReadLine());
            string role = string.Empty;
            if (roleChoice == 1) role = "Admin";
            else if (roleChoice == 2) role = "User";
            await Register(name , password , role);
        }

        async Task Register(string name , string password , string role)
        {
            try
            {
                Employee newEmployee = new Employee()
                {
                    Name = name,
                    Password = password,
                    Role = role
                };
                var result = await employeeLoginBL.Register(newEmployee);
                await Console.Out.WriteLineAsync($"Your registeration is successfull and the registered id is : {result.Id}");
                await GetLoginDeatils();
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        async Task GetSignInOption()
        {
            await Console.Out.WriteLineAsync("Enter your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    await GetRegisterDetails();
                    break;
                case 2:
                    await GetLoginDeatils();
                    break;
            }
        }

        async Task SignInMenu()
        {
            await Console.Out.WriteLineAsync(" 1.Register\n 2.Login");
            await GetSignInOption();
        }

        static async Task Main(string[] args)
        {

            await new RequestTrackerApp().SignInMenu();
        }
    }
}
