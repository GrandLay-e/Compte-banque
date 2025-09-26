using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using libCptBq;

namespace testUnCptBq
{
    /// <summary>
    /// Description résumée pour TestBanque
    /// </summary>
    [TestClass]
    public class TestBanque
    {
        public TestBanque()
        {
            ///
            /// TODO: ajoutez ici la logique du constructeur
            ///
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ClassBanqueExist()
        {
            //Arranger
            Type banqueType = typeof(Banque);
            
            //Assert
            Assert.IsNotNull(banqueType, "La classe banque n'existe pas");

        }

        [TestMethod]
        public void ConstructeurCompteExiste() 
        {
            //Arranger
            Banque banque = new Banque();
            
            //Assert
            Assert.IsNotNull(banque, "Le constructeur de Banque ne fonctionne pas correctement");
            Assert.IsNotNull(banque.MesComptes, "La propriété MesComptes n'est pas initialisée");
        }
        [TestMethod]
        public void ConstructeurBanqueInitialiseListeVide()
        {
            //Arranger
            Banque banque = new Banque();

            //Assert
            Assert.IsNotNull(banque.MesComptes, "La propriété MesComptes n'est pas initialisée");
            Assert.AreEqual(0, banque.MesComptes.Count, "La liste MesComptes devrait être vide à l'initialisation");
        }


        [TestMethod]
        public void TestAjouterCompte()
        {
            //Arrange
            Compte compte = new Compte(1234, "Patrick", 123456789m, -123456m);
            Banque b = new Banque();
            
            //Agir
            b.AjouteCompte(compte);

            //Assert
            Assert.IsTrue(b.MesComptes.Contains(compte), "Le compte n'a pas été correctement ajouté");
        }

        [TestMethod]
        public void TestRenduCompte()
        {
            //Arrange
            Compte c = new Compte(1234, "toto", 1000m, 100m);
            Banque b = new Banque();
            b.AjouteCompte(c);

            //Agir
            Compte compte = b.RendCompte(1234);

            Assert.AreEqual(compte, c, "Le rendu compte n'a pas bien fonctionné ! ");
        }

        [TestMethod]
        public void TestRenduCompteEchec()
        {
            //Arrange
            Compte c = new Compte(1234, "toto", 1000m, 100m);
            Banque b = new Banque();
            b.AjouteCompte(c);

            //Agir
            Compte compte = b.RendCompte(123);
            //Assert
            Assert.IsNull(compte);
        }

        [TestMethod]
        public void TestToStringBanque()
        {
            //Arrange
            Compte c1 = new Compte(12345, "toto", 1000.00m, -500.00m);
            Compte c2 = new Compte(45657, "titi", 2000.00m, -1000.00m);
            Banque b = new Banque();
            b.AjouteCompte(c1);
            b.AjouteCompte(c2);
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("numero: 12345 nom: toto solde: 1000,00 euros decouvert autorisé: -500,00 euros");
            expected.AppendLine("numero: 45657 nom: titi solde: 2000,00 euros decouvert autorisé: -1000,00 euros");
            
            //Agir
            string result = b.ToString();
            
            //Assert
            Assert.AreEqual(expected.ToString(), result, "La méthode ToString() de la classe Banque ne retourne pas le format attendu.");
        }

        [TestMethod]
        public void TestToStringBanqueVide()
        {
            //Arrange
            Banque b = new Banque();
            string expected = string.Empty;
            //Agir
            string result = b.ToString();
            //Assert
            Assert.AreEqual(expected, result, "La méthode ToString() de la classe Banque ne retourne pas une chaîne vide pour une banque sans comptes.");
        }

        [TestMethod]
        public void ToStringBanqueAvecCompteEtDesMouvements()
        {
            //Arrange
            Compte c1 = new Compte(12345, "toto", 1000.00m, -500.00m);
            Compte c2 = new Compte(45657, "titi", 2000.00m, -1000.00m);

            Mouvement m = new Mouvement
            {
                Montant = 100m,
                DateMvt = new DateTime(2025, 9, 1),
                LeType = new Type_("pre")
            };

            c1.AjouterMouvement(m);
            Banque b = new Banque();
            b.AjouteCompte(c1);
            b.AjouteCompte(c2);
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("numero: 12345 nom: toto solde: 900,00 euros decouvert autorisé: -500,00 euros");
            expected.AppendLine("01/09/2025 - Prélèvement de 100 euros");
            expected.AppendLine("numero: 45657 nom: titi solde: 2000,00 euros decouvert autorisé: -1000,00 euros");

            //Agir
            string result = b.ToString();

            //Assert
            Console.WriteLine(expected.ToString());
            Console.WriteLine(result);
            Assert.AreEqual(expected.ToString(), result, "La méthode ToString() de la classe Banque ne retourne pas le format attendu.");

        }

        [TestMethod]

        public void TestMaxCompte()
        {
            Compte c1 = new Compte(12345, "toto", 1000.00m, -500.00m);
            Compte c2 = new Compte(45657, "titi", 2000.00m, -1000.00m);
            Compte c3 = new Compte(78901, "tata", 3000.00m, -1500.00m);
            Banque b = new Banque();
            b.AjouteCompte(c1);
            b.AjouteCompte(c2);
            b.AjouteCompte(c3);
            //Agir
            Compte result = b.CompteMax();
            //Assert
            Assert.AreEqual(c3, result, "La méthode CompteMax() ne retourne pas le compte avec le solde maximum.");
        }

    }
}
