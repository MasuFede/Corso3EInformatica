using Linq.Data;
using Linq.MetodiHelper;



        List<Film> Films = new List<Film>()
        {
            new Film("The Shawshank Redemption", "Frank Darabont", 1994, "Drama", 9.3),
            new Film("The Godfather", "Francis Ford Coppola", 1972, "Crime", 9.2),
            new Film("The Dark Knight", "Christopher Nolan", 2008, "Action", 9.0),
            new Film("Pulp Fiction", "Quentin Tarantino", 1994, "Crime", 8.9),
            new Film("Inception", "Christopher Nolan", 2010, "Sci-Fi", 8.8),
            new Film("Fight Club", "David Fincher", 1999, "Drama", 8.8),
            new Film("Forrest Gump", "Robert Zemeckis", 1994, "Drama", 8.8),
            new Film("Interstellar", "Christopher Nolan", 2014, "Sci-Fi", 8.7),
            new Film("The Matrix", "Lana & Lilly Wachowski", 1999, "Sci-Fi", 8.7),
            new Film("Se7en", "David Fincher", 1995, "Thriller", 8.6),
            new Film("Gladiator", "Ridley Scott", 2000, "Action", 8.5),
            new Film("Whiplash", "Damien Chazelle", 2014, "Drama", 8.5),
            new Film("Parasite", "Bong Joon-ho", 2019, "Thriller", 8.5),
            new Film("The Grand Budapest Hotel", "Wes Anderson", 2014, "Comedy", 8.1),
            new Film("Mad Max: Fury Road", "George Miller", 2015, "Action", 8.1),
        };
List<Film>filmFiltrati = new List<Film>();
filmFiltrati = MetodiLinq.GetMoviesBefore2000(Films);



foreach(var film  in filmFiltrati)
{
    Console.WriteLine(film.Title + film.Year);
}

Console.WriteLine("la media medi voti dei film di genere Sci-Fi è: " + MetodiLinq.AverageSciFiRating(Films));

List<Film>filmMigliori = MetodiLinq.BestMoviePerGenre(Films);
Console.WriteLine("i film migliori sono: ");
foreach(var element in filmMigliori)
{
    Console.WriteLine(element.Title + " " + element.Genre + " " +  element.Rating);
}

List<string> risultato = MetodiLinq.DirectorsWithMultipleMovies(Films);
Console.WriteLine("i direttori con più film sono: ");
foreach(var item in risultato)
{
    Console.WriteLine(item);
}

List<string> filmConTitoliLunghi = MetodiLinq.LongTitlesUpper(Films);
Console.WriteLine("i film con i titoli più lunghi di 15 caretteri sono: ");
foreach(var item in filmConTitoliLunghi)
{
    Console.WriteLine(item);
}
