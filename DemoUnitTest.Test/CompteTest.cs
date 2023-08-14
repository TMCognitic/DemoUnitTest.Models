using DemoUnitTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoUnitTest.Test
{
    [TestClass]
    public class CompteTest
    {
        private Compte _compte;

        [TestInitialize]
        public void Init()
        {
            _compte = new Compte("0001", "Doe John");
        }

        [TestMethod("Test d'instanciation")]
        public void Instanciation()
        {
            //Arrange
            Compte compte;
            //Act
            compte = new Compte("0001", "Doe John");
            //Assert

            Assert.IsNotNull(compte);
            Assert.AreEqual("0001", compte.Numero);
            Assert.AreEqual("Doe John", compte.Titulaire);
        }

        [TestMethod("Test du dépot fonctionnel")]
        public void TestDepotMontantValide()
        {
            //Act
            _compte.Depot(500);

            //Assert
            Assert.AreEqual(500, _compte.Solde);
        }

        [TestMethod("Test du dépot avec un montant invalide")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDepotMontantinvalide()
        {
            //Act
            _compte.Depot(-500);

            //Assert
            Assert.AreEqual(0, _compte.Solde);
        }


        [TestMethod("Test du retrait fonctionnel")]
        public void TestRetraitValide()
        {
            //Act            
            _compte.Depot(500);
            _compte.Retrait(200);
            //Assert            
            Assert.AreEqual(300, _compte.Solde);
        }

        [TestMethod("Test du retrait avec un montant invalide")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRetraitMontantInvalide()
        {
            //Act            
            _compte.Retrait(-200);

            //Assert
            Assert.AreEqual(0, _compte.Solde);
        }

        [TestMethod("Test du retrait lors d'un solde insuffisant")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRetraitSoldeInsuffisant()
        {
            //Act            
            _compte.Retrait(200);
            //Assert
            Assert.AreEqual(0, _compte.Solde);
        }

        [TestMethod("Test Message d'erreur du solde induffisant")]
        public void TestRetraitSoldeInsuffisant2()
        {
            //Act            
            InvalidOperationException exception = Assert.ThrowsException<InvalidOperationException>(() => _compte.Retrait(200));
            //Assert
            Assert.AreEqual("Solde insuffisant", exception.Message);
        }
    }
}