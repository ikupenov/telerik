using System;

namespace ExchangeRates
{
    class StartUp
    {
        static void Main()
        {
            decimal firstCurrency = decimal.Parse(Console.ReadLine());

            decimal firstCurrencyMax = firstCurrency;
            decimal secondCurrencyMax = 0;

            int days = int.Parse(Console.ReadLine());

            for (int i = 0; i < days; i++)
            {
                string[] exchangeRates = Console.ReadLine().Split(' ');
                decimal firstCurrencyExchangeRate = decimal.Parse(exchangeRates[0]);
                decimal secondCurrencyExchangeRate = decimal.Parse(exchangeRates[1]);

                decimal firstCurrencyCurrent = secondCurrencyMax * secondCurrencyExchangeRate;
                decimal secondCurrencyCurrent = firstCurrencyMax * firstCurrencyExchangeRate;

                if (firstCurrencyCurrent > firstCurrencyMax)
                {
                    firstCurrencyMax = firstCurrencyCurrent;
                }

                if (secondCurrencyCurrent > secondCurrencyMax)
                {
                    secondCurrencyMax = secondCurrencyCurrent;
                }
            }

            Console.WriteLine("{0:F2}", firstCurrencyMax);
        }
    }
}