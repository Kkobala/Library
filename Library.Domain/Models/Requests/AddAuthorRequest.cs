using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models.Requests
{
    public class AddAuthorRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
