namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 2, 1 };

            int result2 = GetNumberAttempts(arr, 0);

            Console.WriteLine(result2);
        }

        public static int GetNumberAttempts(int[] arr, int color)
        {
            if (arr.Sum() > int.MaxValue || arr[color] == arr.Sum())
                return -1;

            switch (color)
            {
                case 0:
                    if (arr[1] == arr[2])
                        return 1;
                    break;
                case 1:
                    if (arr[0] == arr[2])
                        return 1;
                    break;
                case 2:
                    if (arr[0] == arr[1])
                        return 1;
                    break;
                default:
                    return -1;
            }

            int attempt = 0;
            while (arr[color] != arr.Sum())
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
                int valueMID = arr[indexMID];
                arr[indexMIN] = arr[indexMIN] + valueMID * 2;
                arr[indexMAX] = arr[indexMAX] - valueMID;
                arr[indexMID] = 0;

                attempt++;
                if (attempt == int.MinValue)
                {
                    attempt = -1;
                    break;
                }
            }
            return attempt;

        }
    }
}