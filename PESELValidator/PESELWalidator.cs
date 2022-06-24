using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESELValidator
{
    public class PESELWalidator
    {
        protected int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        protected int[] pesel;

        public PESELWalidator()
        {
            pesel = new int[11];
        }

        public void WczytajPesel(String pesel)
        {
            int parsed = 0;
            if (int.TryParse(pesel, out parsed))
            {
                throw new ArgumentException("Pesel nie składa się z cyfr");
            }

            if (pesel.Length != 11)
            {
                throw new ArgumentException("Pesel ma nieprawdiłową długość");
            }

            for (int i = 0; i < 11; i++)
            {
                this.pesel[i] = Convert.ToInt32(Convert.ToString(pesel[i]));
            }
        }

        public int SumaKontrolna()
        {
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += pesel[i] * wagi[i];
            }
            return sum;
        }

        public String DataUrodzenia()
        {
            int year = pesel[0] * 10 + pesel[1];
            int month = pesel[2] * 10 + pesel[3];

            if (month < 20)
            {
                year += 1900;
            } else if (month < 40)
            {
                year += 2000;
                month -= 20;
            }
            else if (month < 60)
            {
                year += 2100;
                month -= 40;
            }
            else if (month < 80)
            {
                year += 2200;
                month -= 60;
            }
            else
            {
                year += 1800;
                month -= 80;
            }

            int day = pesel[4] * 10 + pesel[5]; ;

            return String.Format("{0}-{1:D2}-{2:D2}", year, month, day);
        }

        public String Plec()
        {
            return pesel[9] % 2 == 0 ? "k" : "m";
        }

        public Boolean SprawdzPesel()
        {
            int controlDigit = (10 - (SumaKontrolna() % 10)) % 10;
            return controlDigit == pesel[10];
        }

    }
}
