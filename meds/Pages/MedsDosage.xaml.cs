using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            !String.IsNullOrWhiteSpace(dn1.Text) &&
            !String.IsNullOrWhiteSpace(mg1.Text) &&
            !String.IsNullOrWhiteSpace(amount1.Text) &&
            !String.IsNullOrWhiteSpace(count1.Text)
            ) 
            {
                var startD = start1.Text;
                var endD = end1.Text;
                var day = dn1.Text;
                var dosa = doz1.Text;
                var pills = amount1.Text;
                var pillsMg = mg1.Text;
                var countP = count1.Text; 

                double startDosage = Double.Parse(startD);
                double endDosage = Double.Parse(endD);
                double days = Double.Parse(day);
                double dosage = Double.Parse(dosa);
                double pillsAmount = Double.Parse(pills);
                double pillsDosage = Double.Parse(pillsMg);
                double pillsCount = Double.Parse(countP);

                double daysCount = Math.Ceiling(days * ((endDosage - startDosage) / dosage));

                double l = 0;
                double mg = 0;
                do
                {
                    l = endDosage - startDosage;
                    
                    mg += l;
                    endDosage = l;
                }
                while (endDosage >= startDosage);
                mg = mg * pillsCount;
                    
                var packDosage = pillsDosage * pillsAmount;
                var Totalresult = Math.Ceiling(mg/ packDosage);
                    result1.Text = String.Format("Дозировка займет {0} дн. \nВам понадобится {1} уп. лекарств.", daysCount,Totalresult);
                
                
            }
            else DisplayAlert("Предупреждение", "Некоторые поля остались пустыми!", "OK");

        }

        public void BtnGoResult2_Clicked(object sender, EventArgs e)
        {
            if (
            !String.IsNullOrWhiteSpace(start2.Text) &&
            !String.IsNullOrWhiteSpace(end2.Text) &&
            !String.IsNullOrWhiteSpace(doz2.Text) &&
            !String.IsNullOrWhiteSpace(dn2.Text) &&
            !String.IsNullOrWhiteSpace(mg2.Text) &&
            !String.IsNullOrWhiteSpace(amount2.Text) &&
            !String.IsNullOrWhiteSpace(count1.Text)
            )
            {
                var startD = start2.Text;
                var endD = end2.Text;
                var day = dn2.Text;
                var dosa = doz2.Text;
                var pills = amount2.Text;
                var pillsMg = mg2.Text;
                var countP = count2.Text;

                double startDosage = Double.Parse(startD);
                double endDosage = Double.Parse(endD);
                double days = Double.Parse(day);
                double dosage = Double.Parse(dosa);
                double pillsAmount = Double.Parse(pills);
                double pillsDosage = Double.Parse(pillsMg);
                double pillsCount = Double.Parse(countP);
               
                double daysCount = Math.Ceiling(days * ((startDosage - endDosage) / dosage));
               
                double l = 0;
                double mg = 0;
                do
                {
                    l = startDosage - endDosage;

                    mg += l;
                    startDosage = l;
                }
                while (endDosage <= startDosage);
                mg = mg * pillsCount;

                var packDosage = pillsDosage * pillsAmount;
                var Totalresult = Math.Ceiling(mg / packDosage);
                result2.Text = String.Format("Дозировка займет {0} дн. \nВам понадобится {1} уп. лекарств.", daysCount, Totalresult);

            }
            else DisplayAlert("Предупреждение", "Некоторые поля остались пустыми!", "OK");
        }
        
    }
}