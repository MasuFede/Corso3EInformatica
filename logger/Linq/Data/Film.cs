using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Data
{
    public class Film
    {
        public string Title { get; set; }
        public string Director {  get; set; }
        public int Year {  get; set; }
        public string Genre {  get; set; }
        public double Rating {  get; set; }
        public Film(string titolo, string direttore, int anno, string genere, double voto) 
        {
            Title = titolo;
            Director = direttore;
            Year = anno;
            Genre = genere;
            Rating = voto;

        }


    }
}
