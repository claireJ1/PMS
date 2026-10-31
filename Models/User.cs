using System;

namespace PMS.Models;

public class User
{
    public List<Order> OrderHistory { get; set; }
    public List<Payment> PaymentHistory { get; set; }

    public Order? GetMostExpensiveOrder()
    {
        if (OrderHistory == null || OrderHistory.Count == 0)
        {
            return null;
        }

        return OrderHistory.OrderByDescending(o => o.TotalPrice).First();
    }

    public Order? GetLatestOrder()
    {
        if (OrderHistory == null || OrderHistory.Count == 0)
        {
            return null;
        }

        return OrderHistory.OrderByDescending(o => o.CreatedAt).First();;
    }

    // get the lowest priced order from the payment history
    public Payment? GetPaymentWithLowestAmount()
    {
        if (PaymentHistory == null || PaymentHistory.Count == 0)
        {
            return null;
        }

        return PaymentHistory.OrderBy(p => p.PaymentAmount).First();
    }

    // get the latest payment record
    public Payment? GetLatestPayment()
    {
        if (PaymentHistory == null || PaymentHistory.Count == 0)
        {
            return null;
        }

        return PaymentHistory.OrderByDescending(p => p.PaymentId).First();
    }

    // return a list of payment records that are over a certain amount
    public List<Payment> GetPaymentOverAmount(decimal amount)
    {
        if (PaymentHistory == null || PaymentHistory.Count == 0)
        {
            return new List<Payment>();
        }

        return PaymentHistory.Where(p => p.PaymentAmount > amount).ToList();
    }

}
