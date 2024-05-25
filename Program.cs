
class Lab1
{
    static void Main(string[] args)
    {
        Lab1 lab1 = new Lab1();

        //lab1.zad1();
        //lab1.zad2();
        //lab1.zad3();
        //lab1.zad4();
        lab1.zad5();
    }

    void zad1()
    {
        Random rnd = new Random();
        int randomInt = rnd.Next(0, 100 + 1); //ustawienie zakresu od o do 100
        int userGuess;

        bool isGuessed = false;
        while (!isGuessed)
        {
            Console.WriteLine("Zgadnij liczbę, zakres od 0 do 100");
            userGuess = Convert.ToInt32(Console.ReadLine());
            if (userGuess == randomInt)
            {
                Console.WriteLine("Udało się znalezc szukana liczbe");
                isGuessed = true;
            }
            else if (userGuess > randomInt)
            {
                Console.WriteLine("Szukana liczba jest mniejsza");
            }
            else if (userGuess < randomInt)
            {
                Console.WriteLine("Szukana liczba jest wieksza");
            }
        }
    }
    void zad2()
    {
        bool addAnother = true;
        string userInput;
        int userNum;
        bool canParse;
        List<int> numbers = new List<int>();//lista przechowująca wprowadzane liczby

        Console.WriteLine("Wprowadzaj liczby calkowite");
        Console.WriteLine("Aby zakonczyc dodawanie liczb wprowadz znak inny niz liczba calkowita");

        while (addAnother)
        {
            userInput = Console.ReadLine();
            canParse = int.TryParse(userInput, out userNum);//sprawdzanie czy można przekonwertować na int
            if (canParse)
            {
                numbers.Add(userNum);
            }
            else
            {
                addAnother = false;
            }
        }

        int distinctCount = numbers.Distinct().Count();//zliczanie unikalnych wartości
        Console.WriteLine("Ilosc unikalnych wartosci: " + distinctCount);
    }
    void zad3()
    {
        string userInput;
        bool isBinaryNum = true;
        int holes = 0;

        Console.WriteLine("Wprowadz liczbe binarna");
        userInput = Console.ReadLine();

        foreach (var item in userInput)
        {
            if (item != '0' && item != '1')
            {
                isBinaryNum = false;
                break;
            }
        }

        if (isBinaryNum)
        {
            bool isHoleStart = false;
            for (int i = 0; i < userInput.Length; i++)
            {
                if (userInput[i] == '1' && isHoleStart == false)
                {
                    isHoleStart = true;
                }
                else if (isHoleStart && userInput[i] == '1' && userInput[i - 1] == '0')
                {
                    holes++;
                }
            }
            Console.WriteLine("Liczba dziur binarnych: " + holes);
        }
        else
        {
            Console.WriteLine("Wprowadzona wartosc nie jest liczba binarna");
        }
    }
    void zad4()
    {
        List<int> collA = new List<int>();
        List<int> collB = new List<int>();

        bool addToA = true;
        bool addToB = true;

        string userInput;
        int inputNum;
        bool canParse;

        Console.WriteLine("Wprowadzaj liczby calkowite dla zbioru A. " +
            "Aby przestac wprowadzac wpisz znak, ktory nie jest liczba calkowita");
        while (addToA)
        {
            userInput = Console.ReadLine();
            canParse = int.TryParse(userInput, out inputNum);
            if (canParse)
            {
                collA.Add(inputNum);
            }
            else
            {
                addToA = false;
            }
        }

        Console.WriteLine("Wprowadzaj liczby calkowite dla zbioru B. " +
            "Aby przestac wprowadzac wpisz znak, ktory nie jest liczba calkowita");
        while (addToB)
        {
            userInput = Console.ReadLine();
            canParse = int.TryParse(userInput, out inputNum);
            if (canParse)
            {
                collB.Add(inputNum);
            }
            else
            {
                addToB = false;
            }
        }

        List<int> sum = collA.Concat(collB).Distinct().ToList();
        sum.Sort();
        List<int> diffAB = collA.Except(collB).ToList();
        diffAB.Sort();
        List<int> intersectoin = collA.Intersect(collB).ToList();
        intersectoin.Sort();
        List<int> symmDiff = collA.Except(collB).Union(collB.Except(collA)).ToList();
        symmDiff.Sort();

        Console.WriteLine("Suma: ");
        foreach (var item in sum)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("\nRoznica A-B: ");
        foreach (var item in diffAB)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("\nCzesc wspolna zbiorow: ");
        foreach (var item in intersectoin)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("\nRoznica symetryczna zbiorow: ");
        foreach (var item in symmDiff)
        {
            Console.Write(item + " ");
        }
    }
    void zad5()
    {
        string userInput;
        bool canParse;
        int userNumber;
        int dividers = 0;

        Console.WriteLine("Wprowadz dodatnia liczbe calkowita");
        userInput = Console.ReadLine();
        canParse = int.TryParse(userInput, out userNumber);

        if (!canParse)
        {
            Console.WriteLine("Wprowadzona wartosc nie jest liczba calkowita");
        }
        else
        {
            if (userNumber <= 0)
            {
                Console.WriteLine("Wpisana liczba nie jest wieksza od 0");
            }
            else if (userNumber == 1)
            {
                Console.WriteLine("1 nie jest ani liczba pierwsza, ani zlozona");
            }
            else
            {
                for (int i = 1; i <= userNumber; i++)
                {
                    if (userNumber % i == 0)
                    {
                        dividers++;
                    }
                }
                if (dividers > 2)
                {
                    Console.WriteLine("Wprowadzona liczba nie jest liczba pierwsza");
                }
                else
                {
                    Console.WriteLine("Wprowadzona liczba jest liczba pierwsza");
                }
            }
        }
    }
}

