using Xamarin.Forms;

namespace ListNavigationForms
{
    public partial class ListNavigationFormsPage : ContentPage
    {
        public ListNavigationFormsViewModel ViewModel { get; set; }

        public ListNavigationFormsPage ()
        {
            ViewModel = new ListNavigationFormsViewModel ();

            InitializeComponent ();

            BindingContext = ViewModel;

            ViewModel.LoadThing ();

        }
    }
}
