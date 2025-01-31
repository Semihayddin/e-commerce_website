using System;
using BusinessLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary
{
	public static class ItemHelper
	{
		public static string GetResimYokUrl { get { return "~/Assets/images/resim_yok.png"; } set { } }
		public static int StartDate { get { return 2015; } set { } }
	}
	public static class MessageHelper
	{
		public static string SuccessMessage { get { return "Ok|İşleminiz başarıyla tamamlandı."; } set { } }
		public static string ErrorMessage { get { return "Hata|İşlem sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.!"; } set { } }
	}

	public static class KodHelper

	{

		public static string KodArttir(string kod)

		{

			string F = "";
			kod = kod.Trim();



			if (kod == "")

				return "";

			char[] kod2 = kod.ToCharArray();

			for (int i = 0; i < kod2.Length; i++)

			{

				switch (kod2[kod2.Length - 1 - i].ToString())

				{

					case "A":

						F = "B";

						break;

					case "B":

						F = "C";

						break;

					case "C":

						F = "Ç";

						break;

					case "Ç":

						F = "D";

						break;

					case "D":

						F = "E";

						break;

					case "E":

						F = "F";

						break;

					case "F":

						F = "G";

						break;

					case "G":

						F = "Ğ";

						break;

					case "Ğ":

						F = "H";

						break;

					case "H":

						F = "I";

						break;

					case "I":

						F = "İ";

						break;

					case "İ":

						F = "J";

						break;

					case "J":

						F = "K";

						break;

					case "K":

						F = "L";

						break;

					case "L":

						F = "M";

						break;

					case "M":

						F = "N";

						break;

					case "N":

						F = "O";

						break;

					case "O":

						F = "Ö";

						break;

					case "Ö":

						F = "P";

						break;

					case "P":

						F = "Q";

						break;

					case "Q":

						F = "R";

						break;

					case "R":

						F = "S";

						break;

					case "S":

						F = "T";

						break;

					case "T":

						F = "U";

						break;

					case "U":

						F = "Ü";

						break;

					case "Ü":

						F = "V";

						break;

					case "V":

						F = "W";

						break;

					case "W":

						F = "X";

						break;

					case "X":

						F = "Y";

						break;

					case "Y":

						F = "Z";

						break;

					case "Z":

						F = "A";

						break;

					case "a":

						F = "b";

						break;

					case "b":

						F = "c";

						break;

					case "c":

						F = "ç";

						break;

					case "ç":

						F = "d";

						break;

					case "d":

						F = "e";

						break;

					case "e":

						F = "f";

						break;

					case "f":

						F = "g";

						break;

					case "g":

						F = "ğ";

						break;

					case "ğ":

						F = "h";

						break;

					case "h":

						F = "ı";

						break;

					case "ı":

						F = "i";

						break;

					case "i":

						F = "j";

						break;

					case "j":

						F = "k";

						break;

					case "k":

						F = "l";

						break;

					case "l":

						F = "m";

						break;

					case "m":

						F = "n";

						break;

					case "n":

						F = "o";

						break;

					case "o":

						F = "ö";

						break;

					case "ö":

						F = "p";

						break;

					case "p":

						F = "q";

						break;

					case "q":

						F = "r";

						break;

					case "r":

						F = "s";

						break;

					case "s":

						F = "t";

						break;

					case "t":

						F = "u";

						break;

					case "u":

						F = "ü";

						break;

					case "ü":

						F = "v";

						break;

					case "v":

						F = "w";

						break;

					case "w":

						F = "x";

						break;

					case "x":

						F = "y";

						break;

					case "y":

						F = "z";

						break;

					case "z":

						F = "a";

						break;

					case "0":

						F = "1";

						break;

					case "1":

						F = "2";

						break;

					case "2":

						F = "3";

						break;

					case "3":

						F = "4";

						break;

					case "4":

						F = "5";

						break;

					case "5":

						F = "6";

						break;

					case "6":

						F = "7";

						break;

					case "7":

						F = "8";

						break;

					case "8":

						F = "9";

						break;

					case "9":

						F = "0";

						break;

					case ".":

						F = "1";

						break;

					case ",":

						F = "1";

						break;

					case "\"":

						F = "1";

						break;

					case "'":

						F = "1";

						break;

					case "*":

						F = "1";

						break;

					case "-":

						F = "1";

						break;

					case "+":

						F = "1";

						break;

					case "@":

						F = "1";

						break;

					case "?":

						F = "1";

						break;

					case "=":

						F = "1";

						break;

					case ")":

						F = "1";

						break;
					case "%":
						F = "1";
						break;
					case "&":
						F = "1";
						break;
				}

				kod2[kod2.Length - 1 - i] = Convert.ToChar(F);
				kod = "";

				foreach (char item in kod2)
				{
					kod += item;
				}

				if (kod2.Length == i + 1)
				{
					if (F == "A")
					{
						kod = "A" + kod;
						break;
					}
					if (F == "a")
					{
						kod = "a" + kod;
						break;
					}
					if (F == "Z")
					{
						kod = "Z" + kod;
						break;
					}

					if (F == "z")
					{
						kod = "z" + kod;
						break;
					}

					if (F == "0")
					{
						kod = "1" + kod;
						break;
					}
				}

				if (F != "A" && F != "a" && F != "0")
				{
					i = kod2.Length + 1;
					if (i >= kod2.Length)
						break;

				}
			}
			return kod;
		}
	}
}
