using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar
{
	internal class Konyv
	{
		public string Cim { get; set; }
		public string Szerzo { get; set; }
		public int KiadasiEv { get; set; }
		public int Oldalszam { get; set; }
		public string Mufaj { get; set; }
		public override string ToString()
		{
			return $"{Cim} ({Szerzo}) - Kiadasi Év: {KiadasiEv}, Hossz: {Oldalszam} oldal, Műfaj: {Mufaj}";
		}
	}
}
