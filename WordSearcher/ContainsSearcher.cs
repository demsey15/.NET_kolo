
namespace WordSearcher
{
    /// <summary>
    /// DO NOT MODIFY THIS FILE
    /// </summary>
    public class ContainsSearcher : ASearcher
    {
        protected override bool Verify(string word)
        {
            return word.Contains(Query);
        }

        public override string ToString()
        {
            return "Contains";
        }
    }
}
