namespace Delegate;

public class PaymentProcessor
{
    // Step 1: Define the delegate for the payment method
    public delegate void ProcessPaymentHandler(decimal amount);
    
    // Step 2: Create the Payment Processing Framework with parameters amount (decimal) and paymentHandler (method name the same with payment method)
    public void ProcessPayment(decimal amount, ProcessPaymentHandler handler)
    {
        // Invoke the delegate (process payment)
        handler.Invoke(amount);
    }
    
}