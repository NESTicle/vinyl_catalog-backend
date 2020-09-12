using System.Collections.Generic;
using System.Net;

namespace VinylCollection.Web.Helper
{
    public class JSONObjectResult
    {
        public JSONObjectResult()
        {
            Status = HttpStatusCode.OK;
            Errors = new List<string>();
        }

        public JSONObjectResult(HttpStatusCode status)
        {
            Status = status;
            Errors = new List<string>();
        }

        public ICollection<string> Errors { get; set; }

        public HttpStatusCode Status { get; set; }

        public object Data { get; set; }
    }
}
