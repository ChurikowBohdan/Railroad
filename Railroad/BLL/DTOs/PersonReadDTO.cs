﻿using System.ComponentModel.DataAnnotations;

namespace Railroad.BLL.DTOs
{
    public class PersonReadDTO
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
