using System;
using PMS.Enums;

namespace PMS.Models;

public class Payment
{
    public Order Order { get; set; }
    public int PaymentId { get; set; }
    public decimal PaymentAmount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public User User { get; set; }
}
