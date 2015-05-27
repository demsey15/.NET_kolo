using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace WordSearcher
{
    /// <summary>
    /// Main viewmodel of application
    /// DO NOT MODIFY THIS FILE
    /// </summary>
    public interface ITextViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Query search text
        /// </summary>
        string Query { get; set; }

        /// <summary>
        /// All text
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// Command to perform search
        /// </summary>
        ICommand SearchCommand { get; }

        /// <summary>
        /// Text to be shown as search result
        /// </summary>
        string SearchResult { get; set; }

        /// <summary>
        /// Save history of searches to a file
        /// </summary>
        ICommand SaveSearchesCommand { get; }

        /// <summary>
        /// Selected method of searching
        /// </summary>
        ASearcher SelectedMethod { get; set; }

        /// <summary>
        /// Collection of search methods
        /// </summary>
        IEnumerable<ASearcher> SearchMethods { get; }
    }
}
