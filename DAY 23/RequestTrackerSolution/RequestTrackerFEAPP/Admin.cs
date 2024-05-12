using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    public class Admin
    {
        Employee admin;
        async Task ShowAdminMenu()
        {
            await Console.Out.WriteLineAsync(" 1.Raise Request\n 2. View Request status\n 3. View Solutions\n 4. Give Feedback\n " +
                "5.Respond to Solution\n 6. Provide Solution\n 7. Mark Request as Closed\n 8. View Feedbacks\n 9.Exit");
        }

        async Task GetSolutionDetails()
        {
            await ViewRequests();
            await Console.Out.WriteLineAsync("Enter the request id :");
            int requestId = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Enter the solution you need to provide :");
            string providedSolution = Console.ReadLine();
            await ProvideSolution(requestId, providedSolution);
        }

        async Task ProvideSolution(int requestId , string providedSolution)
        {
            try
            {
                EmployeeSolutionBL employeeSolutionBL = new EmployeeSolutionBL();
                SolutionRequest solutionRequest = new SolutionRequest()
                {
                    RequestId = requestId,
                    SolutionDescription = providedSolution,
                    SolvedBy = admin.Id,
                    SolvedDate = DateTime.Now,
                    IsSolved = true,
                };
                var result = await employeeSolutionBL.AddSolution(solutionRequest);
                await Console.Out.WriteLineAsync($"Solution added to the request id : {requestId} is successfull and the solution Id is {result}");
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }   
        }

        async Task ViewSolutions()
        {
            try
            {
                EmployeeSolutionBL employeeSolutionBL = new EmployeeSolutionBL();
                var solutionList = await employeeSolutionBL.ViewAllSolutions();
                await Console.Out.WriteLineAsync("----------------------------------------------------------");
                await Console.Out.WriteLineAsync("Solution Id  | Request Id  | solvedby (Id) | solution  | solved Date  | Raiser comment");
                foreach (var solution in solutionList)
                {
                    if (solution.RequestRaiserComment == null) solution.RequestRaiserComment = "No Comments";
                    await Console.Out.WriteLineAsync($"{solution.SolutionId}  | {solution.RequestId} | {solution.SolvedBy} | " +
                    $"{solution.SolutionDescription} | {solution.SolvedDate}  | {solution.RequestRaiserComment} ");
                }
                await Console.Out.WriteLineAsync("----------------------------------------------------------");
            }
            catch( Exception ex )
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
           
        }

        async Task ViewRequestStatus()
        {
            try
            {
                EmployeeRequestBL employeeRequestBL = new EmployeeRequestBL();
                var requestList = await employeeRequestBL.ViewAllRequest();
                await Console.Out.WriteLineAsync("----------------------------------------------------------");
                await Console.Out.WriteLineAsync("Request Id  | Request Status");
                foreach ( var request in requestList )
                {
                    await Console.Out.WriteLineAsync($"{request.RequestNumber}   |   {request.RequestStatus}");
                }
                await Console.Out.WriteLineAsync("----------------------------------------------------------");
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        async Task ShowAllOpenRequest()
        {
            try
            {
                EmployeeRequestBL employeeRequestBL = new EmployeeRequestBL();
                var openRequestList = await employeeRequestBL.ViewAllOpenRequest();
                await Console.Out.WriteLineAsync("----------------------------------------------------------");
                await Console.Out.WriteLineAsync("Request Id  |  Raised By (id) | Request message  | Request Date  | Request Status");
                foreach (var request in openRequestList)
                {
                    await Console.Out.WriteLineAsync($"{request.RequestNumber} | {request.RequestRaisedBy} | {request.RequestMessage} | {request.RequestDate} | {request.RequestStatus}");
                }
                await Console.Out.WriteLineAsync("----------------------------------------------------------");
                await CloseRequest();
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        async Task CloseRequest()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter request id to mark as close");
                int requestId = Convert.ToInt32(Console.ReadLine());
                EmployeeRequestBL employeeRequestBL = new EmployeeRequestBL();
                var result = await employeeRequestBL.CloseRequest(requestId);
                await Console.Out.WriteLineAsync($"The request of id {result} is closed successfully");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        async Task ViewRequests()
        {
            try
            {
                EmployeeRequestBL employeeRequestBL = new EmployeeRequestBL();
                var requestList = await employeeRequestBL.ViewAllRequest();
                await Console.Out.WriteLineAsync("----------------------------------------------------------");
                await Console.Out.WriteLineAsync("Request Id  |  Raised By (id) | Request message  | Request Date  | Request Status");
                foreach (var request in requestList)
                {
                    if(request.RequestStatus == "open")
                    {
                        await Console.Out.WriteLineAsync($"{request.RequestNumber} | {request.RequestRaisedBy} | {request.RequestMessage} | {request.RequestDate} | {request.RequestStatus}");
                    }
                  
                }
                await Console.Out.WriteLineAsync("----------------------------------------------------------");
            }
            catch(Exception ex )
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }    
        }

        async Task GetRequestDetails()
        {
            await Console.Out.WriteLineAsync("Enter the request message :");
            string message = Console.ReadLine();
            await RaiseRequest(message);
        }
        async Task RaiseRequest(string message)
        {
            try
            {
                Request request = new Request()
                {
                    RequestMessage = message,
                    RequestDate = DateTime.Now,
                    RequestRaisedBy = admin.Id,
                    RequestStatus = "open",
                };
                EmployeeRequestBL employeeRequestBL = new EmployeeRequestBL();
                var result = await employeeRequestBL.AddRequest(request);
                await Console.Out.WriteLineAsync($"Request raised successfully and request id {result}");
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }


        async Task AddFeedBack()
        {
            try
            {
                
                await Console.Out.WriteLineAsync("Enter the solution id to give feedback:");
                int solutionId = Convert.ToInt32(Console.ReadLine());
                await Console.Out.WriteLineAsync("give rating to the solution:");
                string strRating = Console.ReadLine();
                float rating = float.Parse(strRating);
                await Console.Out.WriteLineAsync("give remarks:");
                string remarks = Console.ReadLine();
                SolutionFeedback solutionFeedback = new SolutionFeedback()
                {
                    Rating = rating,
                    Remarks = remarks,
                    SolutionId = solutionId,
                    FeedbackBy = admin.Id,
                    FeedbackDate = DateTime.Now
                };
                EmployeeFeedBackBL employeeFeedBackBL = new EmployeeFeedBackBL();
                var result = employeeFeedBackBL.AddFeedBack(solutionFeedback);
                await Console.Out.WriteLineAsync($"Feedback added successfully for the solution id {solutionId}");
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);   
            }
        }
       

        async Task ViewSolutionListByRequestId(int id)
        {
            try
            {
                var requestList = await GetRequestListByEmployeeId(id);
                EmployeeSolutionBL employeeSolutionBL = new EmployeeSolutionBL();
                bool isSolutionAvailable = false;
                await Console.Out.WriteLineAsync("----------------------------------------------------------");
                await Console.Out.WriteLineAsync("Solution Id  | Request Id  | solvedby (Id) | solution  | solved Date  | Raiser comment");
                foreach (var request in requestList)
                {
                    var solutionList = await employeeSolutionBL.GetSolutionsByRequestId(request.RequestNumber);
                    if (solutionList.Count > 0)
                    {
                        isSolutionAvailable = true;
                        foreach (var solution in solutionList)
                        {
                            await Console.Out.WriteLineAsync($"{solution.SolutionId}  | {solution.RequestId} | {solution.SolvedBy} | " +
                              $"{solution.SolutionDescription} | {solution.SolvedDate}  | {solution.RequestRaiserComment} ");
                        }
                    }
                }
                await Console.Out.WriteLineAsync("----------------------------------------------------------");
                if (isSolutionAvailable)
                {
                    await AddFeedBack();
                }
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync (ex.Message);
            }
            
        }

        async Task<List<Request>> GetRequestListByEmployeeId(int id)
        {
            try
            {
                EmployeeRequestBL employeeRequestBL = new EmployeeRequestBL();
                var requestList = await employeeRequestBL.ViewRequest(id);
                return requestList;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        }
        
        async Task ViewFeedbacks()
        {
            try
            {
                EmployeeFeedBackBL employeeFeedBackBL = new EmployeeFeedBackBL();
                var feedBackList = await employeeFeedBackBL.GetFeedBack(admin.Id);
                await Console.Out.WriteLineAsync("----------------------------------------------------------");
                await Console.Out.WriteLineAsync("feedBack Id | solution id | ratings | remarks | feedback By (id) | feedback given date");
                foreach (var feedBack in feedBackList)
                {
                    await Console.Out.WriteLineAsync($"{feedBack.FeedbackId}  | {feedBack.SolutionId}  | {feedBack.Rating}  | {feedBack.Remarks}  | {feedBack.FeedbackBy}  |  {feedBack.FeedbackDate}");
                }
                await Console.Out.WriteLineAsync("----------------------------------------------------------");
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        async Task ShowSolutionList(List<SolutionRequest> solutionList)
        {
            foreach (var solution in solutionList)
            {
                await Console.Out.WriteLineAsync($"{solution.SolutionId}  | {solution.RequestId} | {solution.SolvedBy} | " +
                  $"{solution.SolutionDescription} | {solution.SolvedDate}  | {solution.RequestRaiserComment} ");
            }
        }

        async Task AddCommentToSolution()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter the  solution Id to add comment :");
                int solutionId = Convert.ToInt32(Console.ReadLine());
                EmployeeSolutionBL employeeSolutionBL = new EmployeeSolutionBL();
                var solution = await employeeSolutionBL.GetSolutionById(solutionId);
                await Console.Out.WriteLineAsync("Enter the comment to the solution:");
                string comment = Console.ReadLine();
                solution.RequestRaiserComment = comment;
                var result = await employeeSolutionBL.AddRespondToSolution(solution);
                await Console.Out.WriteLineAsync($"Comment add to solution id : {result} successfully");

            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        async Task GetSolutionByEmployeeId(int id)
        {
            try
            {
                EmployeeSolutionBL employeeSolutionBL = new EmployeeSolutionBL();
                var solutionList = await employeeSolutionBL.ViewSolutionsById(id);
                await Console.Out.WriteLineAsync("----------------------------------------------------------");
                await Console.Out.WriteLineAsync("Solution Id  | Request Id  | solvedby (Id) | solution  | solved Date  | Raiser comment");  
                if(solutionList.Count > 0)
                {
                    await ShowSolutionList(solutionList);
                }   
                await AddCommentToSolution();
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
        public async Task StartAdmin(Employee employee)
        {
            admin = employee;
            await Console.Out.WriteLineAsync($"Hi {employee.Name} ");
            int choice;
            do
            {
                await ShowAdminMenu();
                await Console.Out.WriteLineAsync("Enter the choice :");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        await GetRequestDetails();
                        break;
                    case 2:
                        await ViewRequestStatus();
                        break;
                    case 3:
                        await ViewSolutions();
                        break;
                    case 4:
                        await ViewSolutionListByRequestId(admin.Id);
                        break;
                    case 5:
                        await GetSolutionByEmployeeId(admin.Id);
                        break;
                    case 6:
                        await GetSolutionDetails();
                        break;
                    case 7:
                        await ShowAllOpenRequest();
                        break;
                    case 8:
                        await ViewFeedbacks();
                        break;
                    case 9:
                        return;
                        
                }
            } while (choice != 9);
        }
    }
}
