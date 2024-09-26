namespace Delegate;

public class PaymentMethod
{
    public static void CreditCardPayment(decimal amount)
    {
        Console.WriteLine($"Processing Credit Card payment of {amount:C}");
    }

    public static void PayPalPayment(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount:C}");
    }

    public static void BankTransferPayment(decimal amount)
    {
        Console.WriteLine($"Processing Bank Transfer payment of {amount:C}");
    }
}