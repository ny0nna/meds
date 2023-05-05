using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace meds.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedsAmount : TabbedPage
    {
        public MedsAmount()
        {
            InitializeComponent();
        }

        public void BtnGoResult1_Clicked(object sender, EventArgs e)
        {
            if (
            !String.IsNullOrWhiteSpace(amount.Text) &&
            !String.IsNullOrWhiteSpace(pills.Text)
            )
            {
            TimeSpan timeSpan = endMed.Date - startMed.Date;
            double days = Convert.ToDouble(timeSpan.Days);

            var pillsX = pills.Text;
            var amountPack = amount.Text;

            double pillsPerDay = Double.Parse(pillsX);
            double pillsAmount = Double.Parse(amountPack);

            double totalResuls = Math.Ceiling(days * pillsPerDay/pillsAmount);

            result.Text = String.Format("Количество упаковок, необходимое на указанный период: {0}",totalResuls);
        }
            else DisplayAlert("Предупреждение", "Некоторые поля остались пустыми!", "OK");
    }

        private void BtnGoRes_Clicked(object sender, EventArgs e)
        {
            if (
            !String.IsNullOrWhiteSpace(pillsDay.Text) &&
            !String.IsNullOrWhiteSpace(amountPill.Text)
            )
            {    var pillsX = pillsDay.Text;
            var amountPack = amountPill.Text;
            int days=0;

            double pillsPerDay = Double.Parse(pillsX);
            double pillsAmount = Double.Parse(amountPack);
           
            if (pillsAmount<pillsPerDay)
                resultCount.Text = String.Format("Препарата недостаточно, приобретите еще.");
            else { 
            do
            {
                days++;
                pillsAmount = pillsAmount - pillsPerDay;
            }
            while (pillsAmount>=pillsPerDay);

            
            resultCount.Text = String.Format("Упаковки лекарства хватит на {0} дней.", days);
            }
            }
            else DisplayAlert("Предупреждение", "Некоторые поля остались пустыми!", "OK");
 
        }
    }
}