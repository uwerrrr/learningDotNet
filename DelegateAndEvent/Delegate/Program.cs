namespace Delegate
{
   
    internal class Program
    {
        // Assume that the payment methods are implemented in different project
        private static void Main(string[] args)
        {
            const decimal amount = 150.00M;
            
            // Step 3: Create the payment processor instance
            PaymentProcessor processor = new PaymentProcessor();

            // Step 4: Process payments using different methods
            processor.ProcessPayment(amount, PaymentMethod.CreditCardPayment);

            // Step 5: Simulate adding a new payment method (e.g., Cryptocurrency)
            processor.ProcessPayment(amount, CryptoPayment);
            
            // try multicasting
            PaymentProcessor.ProcessPaymentHandler paymentStack = CryptoPayment;
            paymentStack += PaymentMethod.BankTransferPayment;
            paymentStack.Invoke(amount);
        }

        // New payment method added without changing the framework
        public static void CryptoPayment(decimal amount)
        {
            Console.WriteLine($"Processing Cryptocurrency payment of {amount:C}");
        }
    }
}

