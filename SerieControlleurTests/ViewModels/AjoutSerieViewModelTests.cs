using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerieControlleur.Models.EntityFramework;
using SerieControlleur.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SerieControlleur.Models;
using SerieControlleur.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerieControlleur.ViewModels.Tests
{
    [TestClass()]
    public class AjoutSerieViewModelTests
    {
        [TestMethod()]
        public void AjoutSerieViewModelTest()
        {
            // Création du ViewModel AjoutSerieViewModel
            var viewModel = new AjoutSerieViewModel();

            // Verifs
            Assert.IsNotNull(viewModel.BtnAjout);
            Assert.IsNotNull(viewModel.Serie);
            Assert.IsNotNull(viewModel.Series);
            Assert.AreEqual(0, viewModel.Series.Count);
        }

        [TestMethod()]
        public async Task GetDataOnLoadAsyncTest()
        {
            //var mockService = new MockWSService();
            //var viewModel = new AjoutSerieViewModel(mockService);

            //// Act
            //viewModel.GetDataOnLoadAsync();

            //// Assert
            //Assert.IsNotNull(viewModel.Series);
            //Assert.AreEqual(1, viewModel.Series.Count);
            //Assert.AreEqual("TestSerie", viewModel.Series[0].Titre);
        }

        [TestMethod()]
        public async Task ActionAjoutTest()
        {
            
            //var viewModel = new AjoutSerieViewModel(mockService);
            //var newSerie = new Serie
            //{
            //    Titre = "TestSerie",
            //    Resume = "Test Resume",
            //    Nbsaisons = 1,
            //    Nbepisodes = 10,
            //    Anneecreation = 2020,
            //    Network = "Test Network"
            //};
            //viewModel.Serie = newSerie;

            //viewModel.ActionAjout();

            //Assert.AreEqual(0, viewModel.Series.Count); // Verif que la vue est vide après l'ajout
        }
    }
}