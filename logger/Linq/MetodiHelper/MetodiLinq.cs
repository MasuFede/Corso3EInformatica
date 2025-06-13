using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Linq.Data;

namespace Linq.MetodiHelper
{
    public class MetodiLinq
    {
        public static List<Film> GetMoviesBefore2000(List<Film> list)
        {
            var searcFilmByYears = list.Where(a => a.Year < 2000).OrderBy(a => a.Year).ToList();
            return searcFilmByYears;

        }

        //2)
        //Valutazione media dei film di genere “Sci-Fi”.
        //Metodo: double AverageSciFiRating(List<Film> films).
        //Hint: Where + Average.

        public static double AverageSciFiRating(List<Film> list)
        {
            var valutazione = list.Where(x => x.Genre.Equals("Sci-Fi")).Sum(z => z.Rating);
            var FilmScifi = list.Where(x => x.Genre.Equals("Sci-Fi"));
            int count = 0;
            foreach (var film in FilmScifi)
            {
                count++;
            }
            return valutazione/count;

         
        }
        //3)
        //Il film con voto più alto per ogni genere.
        //Metodo: List<Film> BestMoviePerGenre(List<Film> films).
        //Hint: GroupBy → OrderByDescending(Rating).First().
        public static List<Film> BestMoviePerGenre(List<Film> films)
        {
            var filmPerGenere= films.OrderByDescending(x => x.Rating).GroupBy(x=> x.Genre).ToList();
            
            var list = new List<Film>();

            foreach (var film in films) 
            {
                list.Add(film); 
            }
            return list;
            
        }
        //4)
        //Registi con più di un film nella lista, in ordine alfabetico.
        //Metodo: List<string> DirectorsWithMultipleMovies(List<Film> films).
        //Hint: GroupBy(Director) + Where(g.Count()>1).

        public static List<string> DirectorsWithMultipleMovies(List<Film> films)
        {
            return films.GroupBy(f => f.Director).Where(g => g.Count() > 1).Select(g => g.Key).OrderBy(d => d).ToList();                 
        }

        //5)
        //Titoli più lunghi di 15 caratteri, restituiti in maiuscolo.
        //Metodo: List<string> LongTitlesUpper(List<Film> films).
        //Hint: Select(f => f.Title.ToUpper()).

        public static List<string> LongTitlesUpper(List<Film> films)
        {
             var filmConTitoloConPiuDi15Caratteri = films.Select(x=> x.Title.ToUpper()).Where(t=> t.Length > 15).ToList();
            return filmConTitoloConPiuDi15Caratteri;
        }

        //6)
        //Raggruppa i film per decennio (anni ’70, ’80, ’90, …) e conta quanti film ci sono per decennio.
        //Metodo: Dictionary<int,int> CountByDecade(List<Film> films).
        //Hint: chiave = Year/10*10. 

        public static Dictionary<int, int> CountByDecade(List<Film> films)
        {
            return films.GroupBy(f => f.Year / 10 * 10).ToDictionary(g => g.Key, g => g.Count());
        }
        //7)
        //Top N film per voto (parametrico).
        //Metodo: List<Film> TopRated(List<Film> films, int n = 5).
        //Hint: OrderByDescending(Rating).Take(n).

        public static List<Film> TopRated(List<Film> films, int n = 5)
        {
            return films.OrderByDescending(f => f.Rating).Take(n).ToList();
        }

        //8)
        //Esiste almeno un film con voto < 8?
        //Metodo: bool HasLowRated(List<Film> films, double threshold = 8.0).
        //Hint: Any.
        public static bool HasLowRated(List<Film> films, double threshold = 8.0)
        {
            return films.Any(f => f.Rating < threshold);
        }
        //9)
        //Produci un dizionario Director → media voti dei suoi film, ordinato per media desc.
        //Metodo: IDictionary<string,double> AveragePerDirector(List<Film> films).
        public static Dictionary<string, double> AveragePerDirector(List<Film> films)
        {
            return films.GroupBy(f => f.Director).ToDictionary(g => g.Key, g => g.Average(f => f.Rating)).OrderByDescending(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

    }

}
