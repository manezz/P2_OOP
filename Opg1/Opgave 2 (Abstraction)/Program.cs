using System;

namespace Opgave_2
{
	abstract class Food
	{
		public abstract void foodIsReady();

		public void foodIsNotReady()
		{
			Console.WriteLine("Food is not ready");
		}
	}
	class Restaurant : Food
	{
		public override void foodIsReady()
		{
			Console.WriteLine("Food is ready");
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Restaurant myRestaurant = new Restaurant();
			myRestaurant.foodIsReady();
			myRestaurant.foodIsNotReady();
		}
	}
}
