using SerieControlleur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerieControlleur.Models.EntityFramework;

namespace SerieControlleur.Services
{
    public interface IService
    {
        Task<List<Serie>> GetDevisesAsync(string nomControleur);
    }
}
