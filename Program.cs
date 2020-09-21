using System;

namespace TubesAI
{
	class MainClass
	{
		//untuk generate random double
		static double GetRandomNumber(double min, double max)
		{
			Random random = new Random();
			return random.NextDouble() * (max - min) + min;
		}

		//untuk memasukan x dan y ke dalam fungsi
		static double fungsi(double x, double y)
		{
			return -1 * Math.Abs(Math.Sin(x)*Math.Cos(y)*Math.Exp(Math.Abs(1-Math.Sqrt(x*x+y*y)/Math.PI)));
		}

		//untuk generate nilai random baru jika nilai random awal tidak bagus
		static double newRandom(double x) {
			double newx = x + GetRandomNumber(-2,2); //ubah2
			while (newx>10 || newx<-10 ) {

				newx = x + GetRandomNumber(-2,2); 
			}
			return newx;
		}


		// fungsi probabilitas
		static double probs (double dE, double t) {
			return Math.Exp((-1*dE)/t); 
		}

		//variabel random dan hasil fungsi
		static double r1 = GetRandomNumber(-10,10); //generate random x1
		static double r2 = GetRandomNumber(-10, 10); //generate random x2

		static double hasil = fungsi(r1,r2); //hasil fungsi menggunakan x1 & x2

		//pengaturan suhu
		static double t = 100; //dipanaskan hingga suhu t
		static double tbawah = 0.0001; //berhenti ketika t sudah mencapat tbawah


		//main program
		public static void Main(string[] args)
		{
			while (t>tbawah) {  //selama t belum mencapai tbawah
				//Console.Write("T = "+t);

				//menggenerati nilai random baru berdasarkan nilai dari x1 dan x2
				double newRand1 = newRandom(r1);
				double newRand2 = newRandom(r2);

				//hasil fungsi baru menggunakan x1 dan x2 baru
				double hasilbaru = fungsi(newRand1,newRand2);

				//Console.WriteLine("x skrg : "+ r1);
				//Console.WriteLine("y skrg : " + r2);

				//Console.WriteLine("x baru : " + newRand1);
				//Console.WriteLine("y baru : " + newRand2);

				//Console.WriteLine("fungsi skrg : " +hasil );
				//Console.WriteLine("fungsi baru : " + hasilbaru);

				//menghitung delta E
				double dE = hasilbaru - hasil;
				//Console.WriteLine("Delta E : "+dE);


				if (hasilbaru < hasil)
				{
					//r1 = newRand1;
					//r2 = newRand2;
					//hasil = fungsi(r1, r2);
					hasil = hasilbaru;
				} else {
					double randP = GetRandomNumber(0,1);
					double p = probs(dE,t); //mengitung probabilitas
					if (randP<p) {
						r1 = newRand1;
						r2 = newRand2;	
					}
				}

				//Console.WriteLine("hasil fungsi : "+hasil);
				t = t * 0.99999;




			
			}
			Console.WriteLine("final : "+ hasil);
			Console.ReadKey();
		}
	}
}
