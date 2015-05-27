using System;
using System.Collections.Generic;
using System.Linq;
using  System.Web.Script.Serialization;
using System.IO;

namespace WordSearcher
{
    /// <summary>
    /// Main class for View Model
    /// TODO: follow guidelines
    /// </summary>
    public class TextViewModel : ITextViewModel
    {
        private readonly IDispatcher _dispatcher;
        private string _query;
        private string _content;
        private string _searchResult;
        private System.Windows.Input.ICommand _iCommand;

        private List<string> savedWords = new List<string>();
        
        public TextViewModel(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;            
        }

        public string Query
        {
            get
            {
                return _query;
            }
            set
            {
                _query = value;
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Query"));
                
            }
        }

        public string Content
        {
            get
            {
                return _content;
            }

            set
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Content"));
                _content = value;
            }

        }

        public System.Windows.Input.ICommand SearchCommand
        {
            get {
                responseSearchCommand();
                return null;
            }
            
        }

        private void responseSearchCommand()
        {
            string query = Query;
            string content = Content;
            
            if (query != null && !query.Equals("") && content != null && !content.Equals(""))
            {
                savedWords.Add(query);
                string[] words = query.Split(new Char[] { ' ' });
                int length = words.Length;
                int counter = 0;
                for (int i = 0; i < length; i++)
                {
                    if (SelectedMethod.VerifyText(content)) counter++;
                }
                if (counter == 0) SearchResult = Globals.NoSearchResults;
                else
                {
                    SearchResult = string.Format(Globals.ResultsFound, counter);
                }
            }
            else
            {
                SearchResult = Globals.NoSearchResults;
            }
        }

        public string SearchResult
        {
            get { return _searchResult; }

            set
            {
                _searchResult = value;
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("SearchResult"));
            }

        }

        public System.Windows.Input.ICommand SaveSearchesCommand
        {
            get{
                saveWords();
                return _iCommand;
            }
            
        }

        private void saveWords(){
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string s = serializer.Serialize(savedWords);
            using(StreamWriter writer = new StreamWriter("mojPlik.txt")){
                writer.WriteLine(s);
            }
        }

        public ASearcher SelectedMethod
        {
            get
            {
                return SearchMethods.ToList<ASearcher>()[0];
            }
            set
            {
                SearchMethods.ToList<ASearcher>()[0] = value;
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("SelectedMethod"));
                
            }
        }

        public IEnumerable<ASearcher> SearchMethods
        {
            get { 
                List<ASearcher> searcher = new List<ASearcher>(2);
                searcher.Add(new ContainsSearcher());
                searcher.Add(new StartsWithSearcher());
                return searcher;
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
