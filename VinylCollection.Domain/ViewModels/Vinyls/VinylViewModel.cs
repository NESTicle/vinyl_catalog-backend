using System;
using System.Collections.Generic;
using System.Text;
using VinylCollection.Domain.ViewModels.Base;
using VinylCollection.Domain.ViewModels.Parameters;

namespace VinylCollection.Domain.ViewModels.Vinyls
{
    public class VinylViewModel : BaseViewModel
    {
        public string Band { get; set; }
        public string Album { get; set; }

        public string CoverURL { get; set; }
        public DateTime DateReleased { get; set; }
        public string Info { get; set; }
        public string Color { get; set; }
        public int Disc { get; set; }

        public decimal Price { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
        public string Currency { get; set; }

        public CountryViewModel Country { get; set; }
        public SubGenreViewModel SubGenre { get; set; }
    }
}
