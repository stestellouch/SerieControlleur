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
using System.Windows.Markup;

namespace SerieControlleur.ViewModels
{
    public class ModificationSerieViewModel : ObservableObject
    {

        private int _serieId;
        public int SerieId
        {
            get { return _serieId; }
            set
            {
                if (_serieId != value)
                {
                    _serieId = value;
                    OnPropertyChanged(nameof(SerieId));
                }
            }
        }

        private Serie _serie;
        public Serie Serie
        {
            get { return _serie; }
            set
            {
                if (_serie != value)
                {
                    _serie = value;
                    OnPropertyChanged(nameof(Serie));
                }
            }
        }
        public IRelayCommand BtnRechercher { get; }
        public IRelayCommand BtnModifier { get; }
        public IRelayCommand BtnSupprimer { get; }

        public ModificationSerieViewModel()
        {
            BtnRechercher = new RelayCommand(async () => await RechercherSerieAsync());
            BtnModifier = new RelayCommand(async () => await ModifierSerieAsync());
            BtnSupprimer = new RelayCommand(async () => await SupprimerSerieAsync());
            Serie = new Serie();
        }

        

        private async Task RechercherSerieAsync()
        {
            WSService service = new WSService("https://apiseriesmaestres.azurewebsites.net/api/");
            Serie result = await service.GetSerieByIdAsync("series", SerieId);

            if (result == null)
            {
                await AfficherMessageAsync("Erreur", "La série avec cet ID n'existe pas.");
                //SerieInfo = string.Empty;
            }
            else
            {
                Serie = result;
              
            }
        }
        private async Task SupprimerSerieAsync()
        {
            WSService service = new WSService("https://apiseriesmaestres.azurewebsites.net/api/");

            bool result = await service.DeleteSerieAsync("series", SerieId);
            if (result)
            {
                await AfficherMessageAsync("Succès", "La série a été supprimée avec succès.");
                Serie = new Serie(); // Réinitialiser la série
            }
            else
            {
                await AfficherMessageAsync("Erreur", "Une erreur s'est produite lors de la suppression de la série.");
            }
        }
        private async Task ModifierSerieAsync()
        {
            WSService service = new WSService("https://apiseriesmaestres.azurewebsites.net/api/");

            bool result = await service.UpdateSerieAsync("series", Serie.Serieid, Serie);
            if (result)
            {
                await AfficherMessageAsync("Succès", "La série a été modifiée avec succès.");
            }
            else
            {
                await AfficherMessageAsync("Erreur", "Une erreur s'est produite lors de la modification de la série.");
            }
        }
        private async Task AfficherMessageAsync(string titre, string contenu)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = titre,
                Content = contenu,
                CloseButtonText = "OK"
            };
            dialog.XamlRoot = App.MainRoot.XamlRoot;
            await dialog.ShowAsync();
        }
    }
}
