using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using libCptBq;

namespace testUnCptBq
{
    /// <summary>
    /// Description résumée pour TestTypeMouvement
    /// </summary>
    [TestClass]
    public class TestType
    {
        public TestType()
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
        public void ClassTypeMouvementExiste()
        {
            //Arranger
            Type typeMouvement = typeof(Type_);

            //Auditer
            Assert.IsNotNull(typeMouvement, "La classe TypeMouvement n'existe pas.");
        }


        [TestMethod]
        public void ConstructeurTypeMouvementExiste()
        {
            // Arranger
            Type typeMouvement = typeof(Type_);
            Type[] parametersTypes = new Type[] { typeof(string), typeof(string), typeof(char) };
            // Agir
            var constructeur = typeMouvement.GetConstructor(parametersTypes);
            // Assert
            Assert.IsNotNull(constructeur, "Le constructeur TypeMouvement(string code, string libelle, char sens) n'existe pas.");
        }


        [TestMethod]
        public void ProprieteExisteDanstypeMouvement()
        { 
            // Arranger
            Type typeMouvement = typeof(Type_);
            // Auditer
            Assert.IsNotNull(typeMouvement.GetProperty("Code"), "La propriété Code n'existe pas dans la classe TypeMouvement.");
            Assert.IsNotNull(typeMouvement.GetProperty("Libelle"), "La propriété Libelle n'existe pas dans la classe TypeMouvement.");
            Assert.IsNotNull(typeMouvement.GetProperty("Sens"), "La propriété Sens n'existe pas dans la classe TypeMouvement.");
        }

        [TestMethod]

        public void ContructeurDeTypeMouvementSansParametre()
        {
            //Arranger
            Type_ typeMouvement = new Type_();

            //Auditer
            Assert.IsNotNull(typeMouvement, "L'objet TypeMouvement n'a pas été créé.");
            Assert.AreEqual("", typeMouvement.Code, "Le code n'a pas été initialisé correctement.");
            Assert.AreEqual("", typeMouvement.Libelle, "Le libellé n'a pas été initialisé correctement.");
            Assert.AreEqual(' ', typeMouvement.Sens, "Le sens n'a pas été initialisé correctement.");
        }
        [TestMethod]
        public void ClassTypeMouvementBienInitialisé()
        {
            //Arranger
            Type_ typeMouvement = new Type_("pre", "Prélèvement", '-');

            //Auditer
            Assert.IsNotNull(typeMouvement, "L'objet TypeMouvement n'a pas été créé.");

            Assert.AreEqual("pre", typeMouvement.Code, "Le code n'a pas été initialisé correctement.");
            Assert.AreEqual("Prélèvement", typeMouvement.Libelle, "Le libellé n'a pas été initialisé correctement.");
            Assert.AreEqual('-', typeMouvement.Sens, "Le sens n'a pas été initialisé correctement.");
        }

        [TestMethod]
        public void ContructeurTypeMouvementAvecLibelleEtSensIncorrects()
        {
            //Arranger
            string code = "pre";
            string libelle = "Retrait";
            char sens = '+';
            string messageAttendu = $"Le libellé, '{libelle}' le sens '{sens}', et/ou le code '{code}' ne correspondent pas !";

            //Agir
            try {
                new Type_(code, libelle, sens);
            }catch(ArgumentException ex)
            {
                //Auditer
                Assert.AreEqual(messageAttendu, ex.Message);
            }
        }

        [TestMethod]
        public void ContructeurTypeMouvementAvecCodeCommeParametre()
        {
            //Arranger
            Type_ typeMouvement = new Type_("dab");
            //Auditer
            Assert.IsNotNull(typeMouvement, "L'objet TypeMouvement n'a pas été créé.");
            Assert.AreEqual("dab", typeMouvement.Code, "Le code n'a pas été initialisé correctement.");
            Assert.AreEqual("Retrait distributeur", typeMouvement.Libelle, "Le libellé n'a pas été initialisé correctement.");
            Assert.AreEqual('-', typeMouvement.Sens, "Le sens n'a pas été initialisé correctement.");
        }

        [TestMethod]
        public void ContructeurTypeMouvementAvecMauvaisCodeCommeParametre()
        {
            //Arranger
            string mauvaisCode = "xyz";
            string messageAttendu = $"Le code '{mauvaisCode}' n'est pas valide.";
            try
            {
                //Agir
                new Type_(mauvaisCode);
            }catch(ArgumentException ex)
            {
                //Auditer
                Assert.AreEqual(messageAttendu, ex.Message);
            }

        }

        [TestMethod]
        public void ToStringTypeMouvementRetourneCorrectement()
        {
            //Arranger
            Type_ typeMouvement = new Type_("ret", "Retrait en guichet", '-');
            string attendu = "ret - Retrait en guichet (-)";

            //Agir
            string resultat = typeMouvement.ToString();

            //Auditer
            Assert.AreEqual(attendu, resultat, "La méthode ToString() ne retourne pas le résultat attendu.");
        }


        [TestMethod]
        public void GetCodeRetourneCorrectement()
        {
            //Arranger
            Type_ t = new Type_("dab", "Retrait distributeur", '-');
            string codeAttendu = "dab";

            //Agir
            string codeResultat = t.GetCode();

            //Auditer
            Assert.AreEqual(codeAttendu, codeResultat, "La méthode GetCode() ne retourne pas le résultat attendu.");
        }

        [TestMethod]
        public void TestToStringAvecAttributsVides()
        {
            //Arranger
            Type_ t = new Type_();

            //Assert
            Assert.IsNull(t.ToString(), "Le ToString devrait renvoyer null");

        }

    }
}
