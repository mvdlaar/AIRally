using AIInterface;

namespace PlayerAI
{
    public class MyAI : IAI
    {
        public int[] PlayCards(string board, string[] programCards)
        {
            return new[] { 0, 1, 2, 3, 4};
        }
    }
}
