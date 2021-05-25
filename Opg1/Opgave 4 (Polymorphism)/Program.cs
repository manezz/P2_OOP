using System;

namespace Opgave_4
{
	class Frugt
	{
        public virtual void frugtSlags()
        {
            Console.WriteLine("Det er et Æble");
        } 
	}

    class Frugt2 : Frugt
    {
        public override void frugtSlags()
        {
            Console.WriteLine("Det er en Bannan");
        }
    }

    class Frugt3 : Frugt
    {
        public override void frugtSlags()
        {
            Console.WriteLine("Det er en Blomme");
        }
    }

	class Program
	{
        // Det bruger alle sammen frugtSlags()
        //men det giver forskæligt resultat efter hvem der kalder på den
		static void Main(string[] args)
		{
            Frugt myApple = new Frugt();
            Frugt myBanana = new Frugt2();
            Frugt myBlomme = new Frugt3();

            myApple.frugtSlags();
            myBanana.frugtSlags();
            myBlomme.frugtSlags();
		}
	}
}