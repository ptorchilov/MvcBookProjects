namespace PartyInvites.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address.")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        public String Phone { get; set; }

        [Required(ErrorMessage = "Please specify whether you'll attend.")]
        public bool? WillAttend { get; set; }
    }
}