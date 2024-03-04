//variable assigment and creating randomly generated ethereum price
decimal roundedEthPrice; 
Random random = new Random();
decimal ethPrice = (decimal)random.NextDouble() * (2999.99M - 2600.00M) + 2600.00M;
roundedEthPrice = decimal.Round(ethPrice, 2);

//infinite loop that runs until the user ends it
while (true)
{
    try
    {   
        //Asks for user input and throws an ArgumentOutOfRangeException if the number is not positive
       
        Console.WriteLine($"Current ETH spot price is: ${roundedEthPrice}");
        Console.Write("Enter amount of ethereum to purchase: ");
        decimal coinAmount = Convert.ToDecimal(Console.ReadLine());
        if (coinAmount <= 0) throw new ArgumentOutOfRangeException("Amount must be positive.");
        decimal total = ethPrice * coinAmount;
       
        //if statements to determine what the commission rate is
        
        double commissionRate;
        if (coinAmount < 1) commissionRate = 0.019;
        else if (coinAmount < 5) commissionRate = 0.0175;
        else if (coinAmount < 10) commissionRate = 0.015;
        else commissionRate = 0.0125;
        
        //Variable assignments for total commission and price
        
        var totalCommission = Convert.ToDecimal(commissionRate) * ethPrice;
        var totalPurchase = totalCommission + ethPrice;

        //Asks the user if they want to stake eth or not

        Console.WriteLine();
        Console.WriteLine("Current stake amount is 3.100%\n");
        Console.Write("Would you like to stake your ethereum? (yes or no): ");
        string response = Console.ReadLine().Trim().ToLower();

        //determines monthly earnings if the user decides to stake

        decimal monthlyEarnings = 0;
        if (response == "yes")
        {
            monthlyEarnings = (total * 0.031M) / 12;
            var roundedMonthlyEarnings = Math.Round(monthlyEarnings, 2);
            Console.WriteLine($"\nYour monthly earnings are ${roundedMonthlyEarnings} per month");
        }

        else
        {

        }

        //order summary and asks the user if they want to proceed with the transaction
       
        Console.WriteLine("\nPlease review your order:\n");
        Console.WriteLine($"Total ETH purchased:    {coinAmount}");
        Console.WriteLine($"ETH spot price:     ${roundedEthPrice}");
        Console.WriteLine($"The commission rate is:     {commissionRate * 100}%");
        Console.WriteLine($"Total commission: ${Math.Round(totalCommission, 2)}");
        Console.WriteLine($"Staked:    {response}");
        Console.WriteLine("--------------------------------\n");
        Console.WriteLine($"Total purchase:    ${Math.Round(totalPurchase, 2)}\n");
        Console.Write("Would you like to continue with the transaction? (yes or no): \n");
        string continueTransaction = Console.ReadLine().ToLower().Trim();


        if (continueTransaction == "yes")
        {
            Console.WriteLine("Your order has been sent.\nThank you!");
        }
        else
        {
            Console.WriteLine("Your order has been cancelled");

        }
    }
    
    //catches any format and out of range errors

    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine(ex.Message);
    }

    //asks the user if they would like to continue

    Console.WriteLine("Would you like to make another transaction?");
    string endResponse = Console.ReadLine().ToLower().Trim();
    if (endResponse != "yes") break;
}




