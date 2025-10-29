﻿namespace PaymentService.API.Models;

public class Payment
{
    public int PaymentID { get; set; }
    public int? OrderID { get; set; } 
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public string PaymentStatus { get; set; }
}
