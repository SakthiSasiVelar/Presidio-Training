using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeRequestBL
    {
         Task<int> AddRequest(Request request);

         Task<List<Request>> ViewRequest(int id);

         Task<int> CloseRequest(int id);

         Task<IList<Request>> ViewAllRequest();

         Task<List<Request>> ViewAllOpenRequest();
    }
}
