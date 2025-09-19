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
            //
            // TODO: ajoutez ici la logique du constructeur
            //
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

    }
}
