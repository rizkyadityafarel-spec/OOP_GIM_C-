
using System;
namespace KerangkaGame
{
    class Karakter

    {
        public string nama { get; private set; }
        public int kesehatan { get; private set; }
        public int senjata { get; private set; }

        public int posisiAwal { get; private set; }
        public int posisiSaatIni { get; private set; }

        public Karakter(string nama, int kesehatan, int senjata)
        {
            this.nama = nama;
            this.kesehatan = kesehatan;
            this.senjata = senjata;

            posisiAwal = 0;
            posisiSaatIni = 0;
        }

        public void Serang(Karakter target)
        {
            Console.WriteLine("===> Mulai Serangan");
            target.TerimaSerangan(this.senjata);
        }
        public void TerimaSerangan(int jumlahSerangan)
        {
            kesehatan -= jumlahSerangan;

            Console.WriteLine(
                $"{nama} diserang dengan {jumlahSerangan}. " +
                $"Sisa kesehatan {kesehatan}"
            );
        }
        public void Healing()
        {
            Console.Write("Apakah ingin melakukan healing? (yes/no): ");
            string pilihan = Console.ReadLine();

            if (pilihan == "yes")
            {
                kesehatan += 20;
                Console.WriteLine(
                    $"{nama} disembuhkan. Kesehatan sekarang {kesehatan}"
                );
            }
            else if (pilihan == "no")
            {
                Console.WriteLine(
                    $"{nama} tidak disembuhkan. Kesehatan tetap {kesehatan}"
                );
            }
            else
            {
                Console.WriteLine("Pilihan tidak ada.");
            }
        }

        public void Aksi()
        {
            Console.Write("Masukkan posisi awal: ");
            posisiAwal = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan posisi saat ini: ");

            posisiSaatIni = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{nama} berpindah posisi.");
            Console.WriteLine($"Posisi awal: {posisiAwal}");
            Console.WriteLine($"Posisi saat ini: {posisiSaatIni}");
        }
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            Karakter player1 = new Karakter("Ultragirl", 100, 80);
            Karakter musuh = new Karakter("Ultraman", 100, 100);

            player1.Serang(musuh);

            musuh.Healing();

            player1.Aksi();
        }
    }
}
