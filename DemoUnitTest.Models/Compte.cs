namespace DemoUnitTest.Models
{
    public class Compte
    {
        public string Numero { get; init; }
        public string Titulaire { get; init; }

        public double Solde
        {
            get
            {
                return _solde;
            }

            private set
            {
                _solde = value;
            }
        }

        private double _solde;


        public void Retrait(double montant)
        {
            if(montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant));
            }

            if (Solde - montant < 0)
            {
                throw new InvalidOperationException("Solde insuffisant");
            }

            Solde -= montant;
        }

        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant));
            }

            Solde += montant;
        }

        public Compte(string numero, string titulaire)
        {
            Numero = numero;
            Titulaire = titulaire;
        }
    }
}