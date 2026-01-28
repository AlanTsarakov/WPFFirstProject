using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFirstProject.Models
{
    internal class User
    {
        public User(int id, string name, string email, string status)
        {
            Id = id;
            Name = name;
            Email = email;
            Status = status;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Status { get; set; }

    }
}
