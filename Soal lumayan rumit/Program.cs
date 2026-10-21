
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
        public void Posisi()
        {
            Console.WriteLine("\n===> Perpindahan Posisi Karakter <===");
            Console.WriteLine("Mana Yang Kamu Pilih ?");
            Console.WriteLine("1. Perpindahan angka");
            Console.WriteLine("2. Tombol Keyboard");
            Console.Write("Pilihanmu: ");

            string pilihan = Console.ReadLine();

            if (pilihan == "1")
            {
                Console.Write("Masukkan posisi awal: ");
                posisiAwal = Convert.ToInt32(Console.ReadLine());
                posisiSaatIni = posisiAwal;

                Console.Write("Masukkan jumlah perpindahan: ");
                int perpindahan = Convert.ToInt32(Console.ReadLine());
                posisiSaatIni += perpindahan;

                Console.WriteLine($"{nama} berpindah posisi.");
                Console.WriteLine($"Posisi awal: {posisiAwal}");
                Console.WriteLine($"Posisi saat ini: {posisiSaatIni}");
            }
            else if (pilihan == "2")
            {
                Console.WriteLine(
                    $"\nKaraktermu: {nama} / Kekuatan: {senjata} / Kesehatan: {kesehatan}"
                );

                Console.WriteLine($"Posisi saat ini: {posisiSaatIni}");
                Console.WriteLine("Panah kanan = maju 2 langkah");
                Console.WriteLine("Panah kiri = mundur 1 langkah");
                Console.WriteLine("ESC = berhenti");

                while (true)
                {
                    ConsoleKeyInfo tombol = Console.ReadKey(true);

                    if (tombol.Key == ConsoleKey.RightArrow)
                    {
                        posisiSaatIni += 2;
                    }
                    else if (tombol.Key == ConsoleKey.LeftArrow)
                    {
                        posisiSaatIni -= 1;
                    }
                    else if (tombol.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("\nPermainan berhenti.");
                        break;
                    }
                    else
                    {
                        continue;
                    }

                    Console.WriteLine(
                        $"Posisi saat ini: {posisiSaatIni}"
                    );
                }
            }
            else
            {
                Console.WriteLine("Pilihan tidak tersedia!");
            }
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

            player1.Posisi();
        }
    }
}
