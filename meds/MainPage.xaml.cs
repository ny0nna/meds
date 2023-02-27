using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace meds
{
    public partial class MainPage : MasterDetailPage
    {

        bool _isPresent = false;
        public bool isPresent
        {
            get
            {
                return _isPresent;
            }

            set
            {
                if (_isPresent != value)
                {
                    _isPresent = value;
                    OnPropertyChanged("isPresent");

                }
            }

        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            Detail = new NavigationPage(new HomePage());
            IsPresented = false;


            MessagingCenter.Subscribe<App, string>(App.Current, "OneMessage", (snd, arg) =>
            {
                isPresent = true;
            });
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Page1());
            IsPresented = false;
        }
        /*private void Button_Clicked2(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ListEmployee());
            IsPresented = false;
        }

        private void Button_Clicked3(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AboutUs());
            IsPresented = false;
        }
        private void Button_Clickded4(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ContactUs());
            IsPresented = false;
        }*/

        private void MasterDetailPage_IsPresentedChanged(object sender, EventArgs e)
        {

        }

    }
}
