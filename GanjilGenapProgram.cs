namespace GanjilGenapProgram
{
    public class Program
    {
        // Tampilan MENU UTAMA program.
        public static void Menu()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("                 MENU GANJIL GENAP");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("1. Cek Ganjil Genap");
            Console.WriteLine("2. Print Ganjil/Genap (dengan Limit)");
            Console.WriteLine("3. Exit");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
        }

        // Fungsi utama program.
        public static void Main()
        {
            bool exit = false;
            while (!exit)
            {
                Menu();
                Console.Write("Pilih menu (1/2/3): ");
                string pilihmenu = Console.ReadLine();
                switch (pilihmenu)
                {
                    case "1":
                        Console.Write("Masukkan bilangan yang ingin dicek: ");
                        int input = int.Parse(Console.ReadLine());
                        Console.WriteLine(CekGanjilGenap(input));
                        break;
                    case "2":
                        Console.Write("Pilih (Ganjil/Genap): ");
                        string jenis = Console.ReadLine();
                        if (jenis == "Ganjil" || jenis == "Genap")
                        {
                            PrintGanjilGenap(jenis);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("(!)Input tidak valid. Silakan pilih lagi.(!)");
                            Console.WriteLine();
                            Console.WriteLine("====================================================");
                        }
                        break;
                    case "3":
                        exit = true;
                        Console.WriteLine("Keluar dari program.");
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("(!)Input pilihan tidak valid. Silakan pilih lagi.(!)");
                        Console.WriteLine();
                        Console.WriteLine("====================================================");
                        break;
                }
            }
        }


        // MENU 1 - Mengecek apakah bilangan yang diinput adalah ganjil atau genap menggunakan Decision.
        static string CekGanjilGenap(int input)
        {
            return (input < 1) ? "(!)Input tidak valid. Silakan pilih lagi.(!)" : (input % 2 == 0) ? "Genap" : "Ganjil";
        }


        // MENU 2 - Mencetak bilangan ganjil atau genap dengan batas limit yang ditentukan menggunakan Decision.

        static void PrintGanjilGenap(string pilihan)
        {
            Console.Write("Masukkan limit: ");

            if (int.TryParse(Console.ReadLine(), out int limit) && limit >= 1)
            {
                Console.Write($"Print bilangan 1 - {limit}: ");
                for (int i = 1; i <= limit; i++)
                {
                    if ((pilihan == "Ganjil" && i % 2 != 0) || (pilihan == "Genap" && i % 2 == 0))
                    {
                        Console.Write(i + ", ");
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("(!)Input tidak valid. Silakan pilih lagi.(!)");
            }
        }
    }
}