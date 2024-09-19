using Konyvtar;
using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
	private static void Main(string[] args)
	{
		List<Konyv> konyvek = new List<Konyv>();

		using (StreamReader sr = new StreamReader("konyvek.txt"))
		{
			string sor;
			while (!sr.EndOfStream)
			{
				sor = sr.ReadLine();
				string[] adatok = sor.Split(',');
				Konyv konyv = new Konyv
				{
					Cim = adatok[0],
					Szerzo = adatok[1],
					KiadasiEv = int.Parse(adatok[2]),
					Oldalszam = int.Parse(adatok[3]),
					Mufaj = adatok[4]
				};
				konyvek.Add(konyv);
			}

		}
        


        Console.Write("Szerzo konyvei ------------>");
		var kerszerzo = Kereses_szerzo(konyvek);
		foreach (var item in kerszerzo)
		{
			Console.WriteLine(item.Cim);
		}

		Console.WriteLine();
		Console.WriteLine("legrégebbi film/filmek");
		var legh_list = leghosszabb(konyvek);
		foreach (var item in legh_list)
		{
			Console.WriteLine(item);
		}
		Console.WriteLine();
		Console.WriteLine("Sorbarendezett lista:");
		var sorbar = sorbarendez(konyvek);
		foreach (var item in sorbar)
		{
			Console.WriteLine(item);
		}
	}
	//2.feladat
	public static List<Konyv> Kereses_szerzo(List<Konyv> konyvek)
	{
		List<Konyv> szerzok = new List<Konyv>();
		string szerzo = "Fekete István";
		foreach (var item in konyvek)
		{
			if (item.Szerzo.Equals(szerzo))
			{
				szerzok.Add(item);
			}
		}
		return szerzok;
	}

	//3.feladat
	public static List<Konyv> leghosszabb(List<Konyv> konyvek)
	{
		List<Konyv> leghosszabb_konyv = new List<Konyv>();
		int legregebbi = konyvek[0].Oldalszam;
		foreach (var item in konyvek)
		{
			if (item.Oldalszam < legregebbi)
			{
				legregebbi = item.Oldalszam;
			}
		}
		Console.WriteLine("A leghosszabb könyv: ");
		foreach (var item in konyvek)
		{
			if (item.Oldalszam == legregebbi)
			{
				leghosszabb_konyv.Add(item);
			}
		}
		return leghosszabb_konyv;
	}
	//4.feladat
	public static List<Konyv> sorbarendez(List<Konyv> konyvek)
	{
		Console.WriteLine("Sorbarendezett lista: ");
		List<Konyv> konyv = konyvek;


		for (int i = 0; i < konyv.Count - 1; i++)
		{
			for (int j = 0; j < konyv.Count - i - 1; j++)
			{
				if (konyv[j].Oldalszam > konyv[j + 1].Oldalszam)
				{

					Konyv temp = konyv[j];
					konyv[j] = konyv[j + 1];
					konyv[j + 1] = temp;
				}
			}
		}

		return konyv;
	}
	//5.feladat

	/*Public static List<Konyv> Megszamol(List<Konyv> konyvek)
	{
		List<Konyv> kiras = new List<Konyv>();
		var Mufaj = konyvek.GroupBy(x => x.Mufaj).OrderBy(y => y.Key);
		foreach (var m in Mufaj)
		{
            Console.WriteLine($"Műfaj : {m.Key}, Száma: {m.Count()}");
            foreach (var item in m)
            {
                Console.WriteLine($"{item.Cim} szerzője {item.Szerzo} ({item.KiadasiEv})-{item.Oldalszam} oldal.");
				
            }
		
        }
		
    }*/
}