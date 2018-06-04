using BareBonesEnterprise.Model;
using BareBonesEnterprise.Service.Abstraction;
using BareBonesEnterprise.ViewModel.Base;
using System.Collections.ObjectModel;

namespace BareBonesEnterprise.ViewModel
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
