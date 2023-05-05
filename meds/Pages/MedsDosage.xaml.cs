using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace meds.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedsDosage : TabbedPage
    {
        public MedsDosage()
        {
            InitializeComponent();
        }

        public void BtnGoResult1_Clicked(object sender, EventArgs e)
        {
            if (
            !String.IsNullOrWhiteSpace(start1.Text) &&
            !String.IsNullOrWhiteSpace(end1.Text) &&
            !String.IsNullOrWhiteSpace(doz1.Text) &&
            !String.IsNullOrWhiteSpace(dn1.Text)
            ) 
            {
                var startD = start1.Text;

                var endD = end1.Text;
                var day = dn1.Text;
                var dosa = doz1.Text;

                double startDosage = Double.Parse(startD);
                double endDosage = Double.Parse(endD);
                double days = Double.Parse(day);
                double dosage = Double.Parse(dosa);

                double daysCount = Math.Ceiling(days * ((endDosage - startDosage) / dosage));
                if (endDosage > startDosage)
                    result1.Text = String.Format("Изменение дозировки займет: {0} дней.", daysCount);
                else DisplayAlert("Предупреждение","Проверьте корректности введенных данных! Конечная дозировка должна быть больше начальной!","OK"); 
            }
            else DisplayAlert("Предупреждение", "Некоторые поля остались пустыми!", "OK");

        }

        public void BtnGoResult2_Clicked(object sender, EventArgs e)
        {
            if (
            !String.IsNullOrWhiteSpace(start1.Text) &&
            !String.IsNullOrWhiteSpace(end1.Text) &&
            !String.IsNullOrWhiteSpace(doz1.Text) &&
            !String.IsNullOrWhiteSpace(dn1.Text)
            )
            {
                var startD = start2.Text;
                var endD = end2.Text;
                var day = dn2.Text;
                var dosa = doz2.Text;

                double startDosage = Double.Parse(startD);
                double endDosage = Double.Parse(endD);
                double days = Double.Parse(day);
                double dosage = Double.Parse(dosa);

                double daysCount = Math.Ceiling(days * ((startDosage - endDosage) / dosage));
                if (endDosage < startDosage)
                    result2.Text = String.Format("Изменение дозировки займет: {0} дней.", daysCount);
                else DisplayAlert("Предупреждение", "Проверьте корректности введенных данных! Конечная дозировка должна быть меньше начальной!", "OK");
            }
            else DisplayAlert("Предупреждение", "Некоторые поля остались пустыми!", "OK");
        }
    }
}