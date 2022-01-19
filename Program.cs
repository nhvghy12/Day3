namespace D3{
    static class Program
    {
        static async Task Main(string[] args){
            int min = 0, max = 100;
            var numbers = await GetPrimeNumberAsync(min,max);
            PrintNumber(numbers);
        }
        static List<int> GetPrimeNumber(int min, int max)
        {
            var results = new List<int>();
            for (int i = min; i <= max ; i++)
            {  
                if (IsPrimeNumberBassic(i))
                {
                    results.Add(i);
                }
            }
            return results;
        }
        static async Task<List<int>> GetPrimeNumberAsync(int min, int max)
        {
            var list = new List<int>();
            var results = await Task.Factory.StartNew(() =>
            {
                for (int i = min; i <= max ; i++)
                {  
                    if (IsPrimeNumberBassic(i))
                    {
                        list.Add(i);
                    }
                }
                return list;
            });
            return results;
        }

        static void PrintNumber(List<int> numbers)
        {
            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }
        }
        static bool IsPrimeNumberBassic(int number)
        {
            int i;
            for ( i = 2; i <= number - 1; i++)
            {
                if (number % i == 0) return false;
            }
            if (i == number) return true;
            return false;
        }
    }
}