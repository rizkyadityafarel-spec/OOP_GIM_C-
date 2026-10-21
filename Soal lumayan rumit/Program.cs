using System;

namespace KerangkaGame
{
    class Karakter
    {
        public string nama { get; private set; }
        public int kesehatan { get; private set; }
        public int senjata { get; private set; }

        public Karakter(string nama, int kesehatan, int senjata)
        {
            this.nama = nama;
            this.kesehatan = kesehatan;
            this.senjata = senjata;
        }

        public void Serang(Karakter target)
        {
            Console.WriteLine("===> Mulai Serangan");
            target.TerimaSerangan(this.senjata);
        }

        public void TerimaSerangan(int jumlahSerangan)
        {
            kesehatan -= jumlahSerangan;
            Console.WriteLine($"{nama} diserang dengan {jumlahSerangan}. Sisa kesehatan {kesehatan}");
        }

        public void Healing()
        {
            kesehatan += 20;
            Console.WriteLine($"{nama} melakukan healing. Kesehatan sekarang {kesehatan}");
        }
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            Karakter player1 = new Karakter("Ultramen", 100, 30);
            Karakter musuh = new Karakter("Ultragirl", 100, 100);

            player1.Serang(musuh);

            musuh.Healing();
        }
    }
}