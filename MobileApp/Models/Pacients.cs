using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileApp.Models
{
    public class Pacients
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
    }
}
