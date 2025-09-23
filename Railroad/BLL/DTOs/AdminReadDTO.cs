﻿namespace Railroad.BLL.DTOs
{
    public class AdminReadDTO
    {
        public int AdminId { get; set; }
        public string Position { get; set; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public string PhoneNumber { get; init; }
        public string Country { get; init; }
        public string City { get; init; }

        public DateTime BirthDate { get; init; }
        public int DiscountValue { get; init; }
        public string Email { get; init; }
        public DateTime RegistrationDate { get; init; }
        public ICollection<int> TicketsIds { get; init; }
    }
}
