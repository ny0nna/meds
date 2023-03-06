using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace meds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : TabbedPage
    {
        public Page1()
        {
            InitializeComponent();

        }


        public void BtnGo_Clicked(object sender, EventArgs e)
        {
            

        }
    }
}