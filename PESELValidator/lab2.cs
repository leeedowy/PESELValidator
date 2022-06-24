public class PESELWalidator
    {
        protected int[] wagi =  { 1,3,7,9,1,3,7,9,1,3};
        protected int[] pesel;

        public PESELWalidator(String pesel)
        {
            WczytajPesel(pesel);
        }

        public void WczytajPesel(String pesel)
        {

        }

        public int SumaKontrolna()
        {
            return 0;
        }

        public String DataUrodzenia()
        {
            return null;
        }

        public String Plec()
        {
            return null;
        }

        public Boolean SprawdzPesel()
        {
            return false;
        }

    }