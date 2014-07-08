namespace PartyInvites.Models
{
    using System;

    public class GuestResponse
    {
        public String Name { get; set; }

        public String Email { get; set; }

        public String Phone { get; set; }

        public bool? WillAttend { get; set; }
    }
}