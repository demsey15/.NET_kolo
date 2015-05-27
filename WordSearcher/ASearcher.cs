
namespace WordSearcher
{
    /// <summary>
    /// Base class for all types of searches
    /// </summary>
    public class ASearcher
    {
        public string Query { get; set; }

        public bool VerifyText(string word)
        {
            if (string.IsNullOrEmpty(Query))
            {
                return false;
            }

            return Verify(word);
        }

        protected virtual bool Verify(string word)
        {
            return true;
        }
    }
}
