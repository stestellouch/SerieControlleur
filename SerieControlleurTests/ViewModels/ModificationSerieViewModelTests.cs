using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerieControlleur.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerieControlleur.ViewModels.Tests
{
    [TestClass()]
    public class ModificationSerieViewModelTests
    {
        [TestMethod()]
        public void ModificationSerieViewModelTest()
        {
            var viewModel = new ModificationSerieViewModel();

            // Verifs
            Assert.IsNotNull(viewModel.BtnModifier);
            Assert.IsNotNull(viewModel.BtnSupprimer);
            Assert.IsNotNull(viewModel.Serie);
        }
    }
}