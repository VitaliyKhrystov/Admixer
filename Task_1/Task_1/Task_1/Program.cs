namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    Console.Write("Enter numbers of red hedgehogs (index 0): ");
                    int red = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Enter numbers of green hedgehogs (index 1): ");
                    int green = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Enter numbers of blue hedgehogs (index 2): ");
                    int blue = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Enter color number (0 - red, 1 - green, 2 - blue): ");
                    int color = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    int[] arr = { red, green, blue };

                    int result = GetNumberAttempts(arr, color);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Number of attempts: {result}");
                    

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPress ESC to stop\n");
                    Console.ResetColor();

                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static int GetNumberAttempts(int[] arr, int color)
        {
            int attempt = 0;

            if (arr.Sum() > int.MaxValue || arr[color] == arr.Sum())
                return attempt = - 1;

            foreach (var item in arr)
            {
                if (item < 0)
                    return attempt = -1;
            }
            
            switch (color)
            {
                case 0:
                    if (arr[1] == arr[2])
                        return attempt = arr[1];
                    else if(Math.Abs(arr[1] - arr[2]) % 3 != 0)
                        return attempt = - 1;
                    else
                        attempt = CalculateAttempts(arr, color);
                    break;
                case 1:
                    if (arr[0] == arr[2])
                        return attempt = arr[0];
                    else if (Math.Abs(arr[0] - arr[2]) % 3 != 0)
                        return attempt = -1;
                    else
                        attempt = CalculateAttempts(arr, color);
                    break;
                case 2:
                    if (arr[0] == arr[1])
                        return attempt = arr[0];
                    else if (Math.Abs(arr[0] - arr[1]) % 3 != 0)
                        return attempt = -1;
                    else
                        attempt = CalculateAttempts(arr, color);
                    break;
                    default: 
                        return attempt = -1;
            }

            return attempt;
        }

        private static int CalculateAttempts(int[] arr, int colour)
        {
            int index1, 
                index2, 
                attempt = 0;

            if (colour == 0)
            {
                index1 = 1;
                index2 = 2;
            } 
            else if(colour == 1)
            {
                index1 = 0;
                index2 = 2;
            }
            else
            {
                index1 = 0;
                index2 = 1;
            }
            while (true)
            {
                int indexMIN = Array.IndexOf(arr, arr.Min());
                int indexMID = 0;
                int indexMAX = Array.IndexOf(arr, arr.Max());

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i != indexMIN && i != indexMAX)
                    {
                        indexMID = i;
                    }
                }
                arr[indexMIN] += 2;
                arr[indexMID] -= 1;
                arr[indexMAX] -= 1;

                attempt++;

                if (arr[index1] == arr[index2])
                {
                    attempt += arr[index1];
                    break;
                }
            }
            return attempt;
        }
    }
}