
namespace WordSearcher
{
    /// <summary>
    /// DO NOT MODIFY THIS FILE
    /// </summary>
    public class StartsWithSearcher : ASearcher
    {
        protected override bool Verify(string word)
        {
            return word.StartsWith(Query);
        }

        public override string ToString()
        {
            return "Starts With";
        }
    }
}
