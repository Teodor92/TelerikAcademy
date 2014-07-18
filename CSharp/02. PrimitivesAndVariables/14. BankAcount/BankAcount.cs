namespace _14.BankAcount
{
    /// <summary>
    ///  A bank account has a holder name (first name, middle name and last name), 
    /// available amount of money (balance), bank name, IBAN, BIC code and 3 credit card numbers 
    /// associated with the account. Declare the variables needed to keep the information for a single bank
    /// account using the appropriate data types and descriptive names.
    /// </summary>
    public class DoublesAndFloats
    {
        internal static void Main()
        {
            string firstName = "Teodor";
            string middleName = "Ivanov";
            string lastName = "Kurtev";
            decimal balance = 1000;
            string bankName = "BNB";
            string iban = string.Empty;
            string bic = string.Empty;
            ulong creditCard1 = 1111;
            ulong creditCard2 = 123123;
            ulong creditCard3 = 334324;
        }
    }
}
