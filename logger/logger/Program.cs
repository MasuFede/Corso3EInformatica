using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using logger;
using Serilog;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    public static readonly ILogger logger = new LoggerConfiguration()
        .WriteTo.File("C:\\Users\\Coros05\\Desktop\\logger\\logger\\LogFiles", rollingInterval:RollingInterval.Day)
        .CreateLogger();
    public static void Main(string[] args)
    {
        logger.Information("Hello!");

        int[] numeri = { 1, 2, 3, 4, 5, 6 };

        var pari = numeri.Where(n => n % 2 == 0);
        foreach (var n in pari)
        {
            Console.WriteLine(n);
        }

        List<string> nomi = new List<string>();
        nomi.Add("Andrea");
        nomi.Add("Alberto");
        nomi.Add("Gaetano");
        nomi.Add("Francesco");
        nomi.Add("pippo");

        List<string> list = new List<string>();
        list = nomi.Where(n => n.StartsWith("A")).ToList();
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        
        var stringaNumeri = numeri.Select(n => n.ToString()).ToList();

        foreach(var item in stringaNumeri)
        {
            Console.WriteLine(item);
        }

        var listaParoleCaps=  nomi.Select(n => n.ToString().ToUpper()).ToList();

        foreach( var item in listaParoleCaps)
        {
            Console.WriteLine($"{item.ToString()}");
        }

        Automobile automobile = new Automobile("AB123CD");
        Automobile automobile2 = new Automobile("DR317VP");
        Automobile automobile3 = new Automobile("DP567PD");

        var numeri2 = new List<int> {5,8,12,1,15,7,30};
        var risultato= numeri2.Where(n=> n>10 ).Select(n=> n*2).ToList();
        foreach (int item in risultato)
        {
            Console.WriteLine(item);
        }

        int[] ints = new int[4];
        ints[0] = 10;
        ints[1] = 9;
        ints[2] = 8;
        ints[3] = 6;



        var risultati = ints.Select(n => new { Numero = n, SqrNo = n * n });

        foreach (var item in risultati)
        {
            Console.WriteLine($"{{ Numero = {item.Numero}, SqrNo = {item.SqrNo} }}");
        }

        List<int> x = new List<int>
        {
            2,2,1,4,7,8,6,5,5,5,5,1
        };

        var risult = x.GroupBy(n => n);  //------> key : 2 value:[2,2]
                                         // ------> key :1 value:[1,1]
        var result2 = x.GroupBy(n => n).Select(a => new
        {
            numero = a.Key,
            frequency = a.Count()
        }).ToList();


        foreach (var item in result2)
        {
            Console.WriteLine($"il numero {item.numero} appare {item.frequency} volte" );
        }

        List<string> listaNomi = new List<string> { "federico", "massimo", "francescoGay", "marco", "gabriele", "gianni", "giacomo", "anna", "cecilia", "agnese", "andrea" };
        //i nomi che  iniziano con la lettera a sono: anna, agnese, andrea
        // i nomi che iniziano con la lettera f sono: etc etc

        var lstNomi = listaNomi.GroupBy(n => n.Substring(0, 1)).Select(a => new
        {
            iniziale = a.Key,
            listaNomi = a.ToList()
        });

        foreach (var item in lstNomi)
        {
            Console.WriteLine($"I nomi che iniziano con {item.iniziale} sono: {string.Join(", ", item.listaNomi)}");
        }

        //        D.Scrivi un programma in C# Sharp per visualizzare: i numeri, la moltiplicazione dei numeri con la frequenza e la frequenza di un numero in un array.
        //Test Data:
        //        I numeri nell'array sono: 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2.
        //Output previsto: Numero Numero*Frequenza Frequenza
        //------------------------------------------------
        //5 15 3
        //1 1 1
        //9 9 1
        //2 4 2.

        List<int> frequenza = new List<int> { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 };
        var tabella = frequenza.GroupBy(n => n).Select(x => new
        {
            x = x.Key,
            y = x.Key * x.Count(),
            z = x.Count()



        });
        foreach(var item in tabella)
        {
            Console.WriteLine($"{item.x} {item.y} {item.z}");
        }

        //        E. Scrivi un programma in C# per creare un elenco di numeri e visualizzare i numeri superiori a 80. 
        //        Dati di test:
        //        I membri dell'elenco sono: 55 200 740 76 230 482 95. 
        //        Output previsto: --> I numeri superiori a 80 sono: 200 740 230 482 95.

        List<int> numeriSuperirori = new List<int> { 55, 200, 740, 76, 230, 482, 95 };

        var lstNumSup80= numeriSuperirori.Where(x=> x > 80).ToList();
        Console.Write($"i numeri suoerori a 80 sono: ");
        foreach (var item in lstNumSup80)
        {
            Console.Write(item.ToString() + " ");
        }

        //        F.Scrivi un programma in C# per trovare le parole in maiuscolo in una stringa. 
        //        Test Data:
        //          Input the string : this IS a STRING
        //          Expected Output:
        //          The UPPER CASE words are:
        //          IS
        //          STRING

        string frase = " Input the string : this IS a STRING\r\n//          Expected Output:\r\n//          The UPPER CASE words are:\r\n//          IS\r\n//          STRING";
        var fraseLavorata= frase.Split(" ").ToList().Where(x=> x.Equals(x.ToUpper())).Select(a => new {
            ParolaMaiuscola = a.ToString().Trim('/'),
        });
        Console.Write("\n le parole maiuscole sono: ");
        foreach (var item in fraseLavorata)
        {
            Console.Write(item.ParolaMaiuscola);
        }

        //        G.Scrivi un programma in C# per convertire un array di stringhe in una stringa.
        //        Test Data:
        //        Input number of strings to store in the array :3
        //        Input 3 strings for the array :
        //        Element[0] : cat
        //        Element[1] : dog
        //        Element[2] : rat
        //        Expected Output:
        //        Ecco la stringa qui sotto creata con gli elementi dell'array sopra:
        //        cat, dog, rat


        string[] parolaDacomporre = new string[3];
//        StringBuilder sb = new StringBuilder();
        parolaDacomporre[0] = "cat";
        parolaDacomporre[1] = "dog";
        parolaDacomporre[2] = "rat";

        var parolaComposta = parolaDacomporre.Aggregate((a, b) => a + " ," + b);
        Console.WriteLine("\n" + parolaComposta.ToString());
        //sb.Append(parolaDacomporre[0]).Append(" ").Append(parolaDacomporre[1]).Append(" ").Append(parolaDacomporre[2]).ToString();
        //Console.WriteLine("\n" + sb.ToString());


        //        H.Scrivere un programma in C# Sharp per contare le estensioni dei file e raggrupparlo utilizzsando LINQ.
        //          Dati del test :
        //          I file sono: aaa.frx, bbb.TXT, xyz.dbf,abc.pdf
        //          aaaa.PDF,xyz.frt, abc.xml, ccc.txt, zzz.txt

        //          Output atteso:
        //          Ecco il gruppo di estensioni dei file:
        //          1 File con estensione.frx
        //          3 File con estensione.txt
        //          1 File con estensione.dbf
        //          2 File con estensione.pdf
        //          1 File con estensione.frt
        //          1 File con estensione.xml

        


        //var fileManeggiati = fileConEstensioni.GroupBy();

        //        I.Scrivi un programma in C# Sharp per rimuovere elementi da una lista utilizzando la funzione Remove passando l'oggetto.
        //Dati di test:

        //Ecco la lista degli elementi:
        //    Carattere: m
        //    Carattere: n
        //    Carattere: o
        //    Carattere: p
        //    Carattere: q
        //    Output atteso:

        //           Ecco la lista dopo aver rimosso l'elemento 'o' dalla lista:
        //Carattere: m
        //Carattere: n
        //Carattere: p
        //Carattere: q


        List<char> lettereDaModificare = new List<char>
        {
            'm','n','o','p','q'
        };

        lettereDaModificare.Remove('o');

        Console.WriteLine("la lista con la lettera o eliminata è: ");
        foreach(var item in lettereDaModificare)
        {
            Console.WriteLine(item);

        }

//        J.Scrivi un programma in C# Sharp per visualizzare l'elenco degli elementi dell'array ordinati prima in base alla lunghezza della stringa, poi in ordine alfabetico crescente. 
            //Output atteso:
            //Ecco la lista ordinata:
                       //ROME
                      //PARIS
                     //LONDON
                    //ZURICH
                   //NAIROBI
                  //ABU DHABI
                 //AMSTERDAM
                //NEW DELHI
               //CALIFORNIA

        List<string>lstCitta = new List<string>
        {
            "ROME",
            "PARIS",
            "LONDON",
            "ZURICH",
            "NAIROBI",
            "ABU DHABI",
            "AMSTERDAM",
            "NEW DELHI",
            "CALIFORNIA"

        };
        var lstOrdinataDelleCitta = lstCitta.OrderBy(c => c.Length).ToList().OrderBy(c => c);

        Console.WriteLine("la lita delle città ordinata per lunghezza e in ordine alfabetico è: "  );
        foreach(var item in lstOrdinataDelleCitta)
        {
            Console.WriteLine(item);
        }





        List<Studenti> listaStudenti = new List<Studenti> {

             new Studenti {Nome="Jessica", Classe = "3E", Id =1},
             new Studenti {Nome= "Federico", Classe = "4E", Id =2 },
             new Studenti { Nome = "Francesco", Classe = "3E", Id =3},
             new Studenti { Nome = "Dario", Classe = "3E", Id =4},
             new Studenti { Nome = "Gabriele", Classe = "4E", Id =5},
             new Studenti { Nome = "Giacomo", Classe = "1E", Id =6},
             new Studenti { Nome = "Eduardo", Classe = "2A", Id =7},
             new Studenti { Nome = "Max", Classe = "3B", Id =8},
             new Studenti { Nome = "Thomas", Classe = "2A", Id = 9},
             new Studenti { Nome = "Alex", Classe = "3B", Id =10}
};


        //Seleziona dalla listaStudenti i Nomi  e stampali.


        var selezioneNome= listaStudenti.Select(i => i.Nome).ToList();
        Console.WriteLine("Seleziona dalla listaStudenti i Nomi  e stampali.");
        foreach(var n in selezioneNome)
        {
            Console.WriteLine(n);
        }


        //Seleziona dalla listaStudenti i Classe  e stampali.
        var selezioneClasse = listaStudenti.Select(s => s.Classe).ToList();
        Console.WriteLine("Seleziona dalla listaStudenti i Classe  e stampali");
        foreach (var n in selezioneClasse)
        {
            Console.WriteLine(n);
        }


        //Seleziona dalla listaStudenti i ID  e stampali.

        var selezioneId = listaStudenti.Select(d => d.Id).ToList();

        Console.WriteLine("Seleziona dalla listaStudenti i ID  e stampali: ");
        foreach (var n in selezioneId)
        {
            Console.WriteLine(n);
        }
        //Seleziona dalla listaStudenti i Nome e Classe  d e stampali.
        var selezioneMultipla = listaStudenti.Select(x => new
        {
            selezioneNome = x.Nome,
            selezioneClasse = x.Classe,
        }).ToList();

        Console.WriteLine("//Seleziona dalla listaStudenti i Nome e Classe  d e stampali");
        foreach (var sez in selezioneMultipla)
        {
            Console.WriteLine(sez.selezioneNome + " " + sez.selezioneClasse);
        }


        //Seleziona dalla listaStudenti lo studente con id = 6  e stampali.

        var selezioneById = listaStudenti.Select(n => n).Where(x => x.Id == 6).ToList();
        Console.WriteLine("Seleziona dalla listaStudenti lo studente con id = 6  e stampali.");
        foreach (var ez in selezioneById)
        {
            Console.WriteLine(ez.Nome + ez.Cognome);
        }


        var raggruppaByClasse = listaStudenti.GroupBy(x => x.Classe).ToList();
        Console.WriteLine("Ragruppa per classe e stampa la classe");

        foreach (var gruppo in raggruppaByClasse)
        {
            Console.WriteLine($"Classe: {gruppo.Key}");
            foreach (var studente in gruppo)
            {
                Console.WriteLine($"  - {studente.Nome}");
            }
        }

      















    }







}

