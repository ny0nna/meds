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
        public MainPage()
        {
            InitializeComponent();

            Detail = new NavigationPage(new Feed());
            List<Menu> menu = new List<Menu>
            {
                new Menu { Page = new Feed(), MenuTitle="Расчет приема 1 упаковки лекарства", MenuDetail="На какое количество дней хватит упаковки лекарства с учетом дозировки" },
                new Menu { Page = new Feed(), MenuTitle="Расчет сроков измения дозировки", MenuDetail="Расчет количества упаковок на период изменеия дозировки" },

            };
            ListMenu.ItemsSource = menu;
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.Page);
            }
        }
        public class Menu
        {
            public string MenuTitle { get; set; }
            public string MenuDetail { get; set; }
            public Page Page { get; set; }
        }
        void OnTappedContent(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Page1());
        }
    }
}
