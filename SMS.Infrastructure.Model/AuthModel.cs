using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Model
{
    public class AuthModel
    {
        [Required]
        public string Username {  get; set; }
        [Required]
        public string Token { get; set; }
        public string Message { get; set; }
        [Required]
        public DateTime TokenExpirationDate { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
