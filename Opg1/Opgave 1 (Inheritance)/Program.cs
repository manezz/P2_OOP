using System;

namespace Opgave_1
{
	class BilVask
	{
		// Til nedarvning
		protected int budgetVask;
		protected int sølvVask;
		protected int guldVask;
	}

	class Program : BilVask
	{
		static void Main(string[] args)
		{
			var vask = new Program();

			// Nedarvede klasser får en værdi	
			vask.budgetVask = 20;
			vask.sølvVask = 50;
			vask.guldVask = 100;

			Console.WriteLine("Buget Vask " + vask.budgetVask + " Kr.");
			Console.WriteLine("Sølv Vask " + vask.sølvVask + " Kr.");
			Console.WriteLine("Guld Vask " + vask.guldVask + " Kr.");
		}
	}
}