using System;
using System.Text.RegularExpressions;

namespace ConsoleRegexApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Przykłady użycia wyrażeń regularnych.");
            Console.WriteLine("1. Szukanie liczb w tekście i wypisanie ich.");
            Console.WriteLine("2. Sprawdznie czy adres email jest poprawny.");
            Console.WriteLine("3. Szukanie podwójnych wyrazów obok siebie w tekście.");

            while (true) 
            { 
                Console.WriteLine("Wybierz, które zadanie chcesz wykonać: [1, 2 lub 3] i wciśnij ENTER");
                string zadanie = Console.ReadLine();

                switch (zadanie)
                {
                    case "1":
                        FindNumbers();
                        break;

                    case "2":
                        CheckEmail();
                        break;

                    case "3":
                        FindDuplicates();
                        break;

                    default:
                        Console.WriteLine("Podałeś niepoprawną wartość.");
                        break;
                }

                Console.WriteLine("Czy chcesz grac dalej? [T czy N]");

                string answer = Console.ReadLine().ToUpper();

                if (answer == "T")
                {
                        continue;
                }
                else {
                        return;
                }
            }
        }

        static void FindNumbers()
        {
            string userInput = AskQuestion("Podaj tekst, w którym wyszukać liczby i nacisnij enter.");

            string[] numbers = Regex.Split(userInput, @"\D+");
            foreach (string num in numbers)
                Console.WriteLine(num);
        }

        static void CheckEmail()
        {
            string email = AskQuestion("Podaj adres email do sprawdzenia i nacisnij enter.");

            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            if (Regex.IsMatch(email, pattern))
            {
                Console.WriteLine(email + " to poprawny adres email.");
            }
            else
            {
                Console.WriteLine(email + " to nie jest poprawny adres email.");
            }
        }

        static void FindDuplicates()
        {
            string text = AskQuestion("Podaj tekst do znalezienia powtórzeń wyrazów obok siebie i nacisnij enter.");

            Regex rx = new Regex(@"\b(?<wyraz>\w+)\s+(\k<wyraz>)\b");

            MatchCollection matches = rx.Matches(text);

            Console.WriteLine("{0} razy znaleziono powtórzone słowo w tekście: {1}", matches.Count,text);

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                Console.WriteLine("Powtórzone słowo to: '{0}' ",
                                  groups["wyraz"].Value);
            }
        }

        static string AskQuestion(string question)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(question);
            Console.ResetColor();
            string text = Console.ReadLine();
            return text;
        }
    }
}
