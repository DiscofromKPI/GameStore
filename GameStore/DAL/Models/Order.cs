using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
    public enum PaymentType
    {
        Card,
        Cash,
        Crypto
    }
    public class Order
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
        public PaymentType PaymentType { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}