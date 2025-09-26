using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using libCptBq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testUnCptBq
{
    /// <summary>
    /// Description résumée pour TestMouvement
    /// </summary>
    [TestClass]
    public class TestMouvement
    {
        public TestMouvement()
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
        public void TestTypeMouvementExists()
        {
            Type Mouvement = typeof(libCptBq.Mouvement);
            Assert.IsNotNull(Mouvement);
        }

        [TestMethod]
        public void TestTypeMouvementProperties()
        {
            Type Mouvement = typeof(Mouvement);
            PropertyInfo[] properties = Mouvement.GetProperties();
            Assert.AreEqual(3, properties.Length, "Le nombre de propriétés dans la classe Mouvement est incorrect.");
            Assert.IsNotNull(Mouvement.GetProperty("DateMvt"), "La propriété DateMvt n'existe pas.");
            Assert.IsNotNull(Mouvement.GetProperty("Montant"), "La propriété Montant n'existe pas.");
            Assert.IsNotNull(Mouvement.GetProperty("LeType"),  "La propriété LeType n'existe pas.");
        }

        [TestMethod]
        public void TestMouvementDefaultConstructor()
        {
            // Arrange 
            Mouvement m = new Mouvement();
            Type_ t = new Type_();

            // Assert
            Assert.IsNotNull(m, "Le mouvement n'a pas été initialisé");
            Assert.AreEqual(DateTime.Now.Date, m.DateMvt.Date, "La propriété DateMvt n'est pas bien initialisé");
            Assert.AreEqual(0m, m.Montant, "La propriété Montant n'est pas bien initilisé à zéro");
            Assert.IsNotNull(m.LeType, "L'attribut LeType est null");
            Assert.AreEqual(t.ToString(), m.LeType.ToString(), "L'attribut LeType n'a pas bien été intialisé");

        }
        [TestMethod]
        public void TestTypeMouvementConstrcutorWithTypesCode()
        {
            // Arrange
            Mouvement mouvement = new Mouvement(100.0m, new DateTime(2023, 1, 1), "dab");

            // Assert
            Assert.IsNotNull(mouvement, "Le constructeur de la classe Mouvement ne fonctionne pas.");
            Assert.AreEqual(new DateTime(2023, 1, 1), mouvement.DateMvt, "La propriété DateMvt n'est pas correctement initialisée.");
            Assert.AreEqual(100.0m, mouvement.Montant, "La propriété Montant n'est pas correctement initialisée.");
            Assert.IsNotNull(mouvement.LeType, "La propriété LeType n'est pas correctement initialisée.");
        }
        [TestMethod]
        public void TestTypeMouvementConstructor()
        {
            //Arranger
            Type_ type = new Type_("des");
            Mouvement mouvement = new Mouvement(100.0m, new DateTime(2023, 1, 1), type);
            
            //Assert
            Assert.IsNotNull(mouvement, "Le constructeur de la classe Mouvement ne fonctionne pas.");
            Assert.AreEqual(new DateTime(2023, 1, 1), mouvement.DateMvt, "La propriété DateMvt n'est pas correctement initialisée.");
            Assert.AreEqual(100.0m, mouvement.Montant, "La propriété Montant n'est pas correctement initialisée.");
            Assert.IsNotNull(mouvement.LeType, "La propriété LeType n'est pas correctement initialisée.");
        }

        [TestMethod]
        public void TypeMouvementConstructorAvecTypeDefault()
        {
            //Arranger
            Type_ type = new Type_();
            try
            {
                //Auditer
                Mouvement m = new Mouvement(100.0m, new DateTime(2023, 1, 1), type);

                //Assert
                Assert.Fail("Une exception devrait être levée");
            }
            catch(Exception ex)
            {
                //Auditer
                string msg = ex.Message;

                //Assert
                Assert.AreEqual(msg, "Le type n'est pas valable", "Message d'erreur non compatible");
            }

        }

        [TestMethod]
        public void TestTypeMouvementToString()
        {
            //Arrange
            Type_ type = new Type_("pre");
            Mouvement mouvement = new Mouvement(150.00m, new DateTime(2023, 1, 1), type);
            
            //Agir
            string expectedString = "01/01/2023 - Prélèvement de 150,00 euros";
            string actualString = mouvement.ToString();

            //Assert
            Assert.AreEqual(expectedString, actualString, "La méthode ToString de la classe Mouvement ne fonctionne pas correctement.");
        }

    }
}
