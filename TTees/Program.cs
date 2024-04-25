namespace TTees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 1;

        }
        static int Factorial(int n)
        {
            // 베이스 케이스: n이 1 이하이면 1을 반환합니다.
            if (n <= 1)
            {
                return 1;
            }
            // 재귀 케이스: n * (n-1)의 팩토리얼을 반환합니다.
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}
