using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerieControlleur.Models;
using SerieControlleur.Services;
using CommunityToolkit.Mvvm.Input;
using SerieControlleur.Models.EntityFramework;

namespace SerieControlleur.ViewModels
{
    public class AjoutSerieViewModel : ObservableObject
    {
        public IRelayCommand BtnAjout { get; }
        public AjoutSerieViewModel()
        {
            GetDataOnLoadAsync();
            BtnAjout = new RelayCommand(ActionAjout);
            Serie = new Serie();
        }
        private Serie serie;

        public Serie Serie
        {
            get { 
                return serie; 
            }
            set { 
                serie = value; 
            }
        }


        private ObservableCollection<Serie> series;

        public ObservableCollection<Serie> Series
        {
            get { return series; }
            set
            {
                series = value;
                OnPropertyChanged(nameof(Series));
            }
        }



        public async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://apiseriesmaestres.azurewebsites.net/api/");
            List<Serie> result = await service.GetSeriesAsync("series");
            if (result.Count == 0)
                MesssageAsync();
            else
                Series = new ObservableCollection<Serie>(result);
        }
        private async Task MesssageAsync()
        {
            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "Erreur",
                Content = "API non disponible ! ",
                CloseButtonText = "Ok"
            };
            deleteFileDialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await deleteFileDialog.ShowAsync();
        }
        public async void ActionAjout()
        {
            WSService service = new WSService("https://apiseriesmaestres.azurewebsites.net/api/");

            bool result = await service.PostSerieAsync("series", new Serie(Serie.Serieid, Serie.Titre, Serie.Resume, Serie.Nbsaisons, Serie.Nbepisodes, Serie.Anneecreation, Serie.Network));

            if (!result)
            {
                MessagePasDeSerie();
            }
            else
            {
                MessageAjoutSerieSucces();
                Serie = new Serie();
            }
        }
        private async Task MessagePasDeSerie()
        {
            ContentDialog noDeviseDialog = new ContentDialog
            {
                Title = "Erreur",
                Content = "Impossible d'insérer ! ",
                CloseButtonText = "Ok"
            };
            noDeviseDialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await noDeviseDialog.ShowAsync();
        }
        private async Task MessageAjoutSerieSucces()
        {
            ContentDialog noDeviseDialog = new ContentDialog
            {
                Title = "Succès ! ",
                Content = "La série s'est bien insérer  ! \n" + "Titre : " + Serie.Titre + "\nRésumé : "   + Serie.Resume + "\nNombre de saison : " + Serie.Nbsaisons + "\nNombre d'épisode  : " + Serie.Nbepisodes + "\nAnnée création : " + Serie.Anneecreation + "\nChaine : " + Serie.Network,
                CloseButtonText = "Ok"
            };
            noDeviseDialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await noDeviseDialog.ShowAsync();
        }




    }
}
