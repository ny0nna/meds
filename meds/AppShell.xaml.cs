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
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void MenuItem_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Помощь", "Информация об эксплуатации приложения находится на вкладке 'Главная'. Если у вас остались вопросы, напишите нам! Адрес электронной почты: shtvanna@gmail.com", "OK");
        }
    }
}