using QuotesApp.Model;
using QuotesApp.Service.Abstraction;
using QuotesApp.ViewModel.Base;
using System.Collections.ObjectModel;

namespace QuotesApp.ViewModel
{
    public class AuthorsViewModel : BaseViewModel
    {
        private IAuthorService authorService;
        private ObservableCollection<Author> authors;
        public ObservableCollection<Author> Authors
        {
            get { return authors; }
            private set
            {
                if (authors != value)
                {
                    authors = value;
                    RaisePropertyChanged(() => Authors);
                }
            }
        }

        public AuthorsViewModel(IAuthorService authorService)
        {
            this.authorService = authorService;
            var authors = new ObservableCollection<Author>();
            authorService.GetAuthors().ForEach(authors.Add);
            Authors = authors;
        }
    }
}
