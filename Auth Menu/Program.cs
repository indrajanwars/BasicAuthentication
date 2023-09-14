using GanjilGenapProgram;

namespace BasicAuthentication
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Program
    {
        static List<User> daftarUser = new();

        public static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("== BASIC AUTHENTICATION ==");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Show User");
                Console.WriteLine("3. Search User");
                Console.WriteLine("4. Login User");
                Console.WriteLine("5. Exit");
                Console.Write("Masukkan Input: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateUser();
                        break;
                    case "2":
                        ShowUser();
                        break;
                    case "3":
                        SearchUser();
                        break;
                    case "4":
                        LoginUser();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("Exiting program.");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }


        // MENU 1. Create User
        public static void CreateUser()
        {
            Console.Clear();
            Console.WriteLine("==CREATE USER==");
            Console.Write("Create First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Create Last Name: ");
            string lastName = Console.ReadLine();
            string password;

            do
            {
                Console.Write("Create Password: ");
                password = Console.ReadLine();

                if (IsPasswordValid(password))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Password harus memiliki minimal 8 karakter, minimal 1 huruf Kapital, minimal 1 huruf kecil dan minimal 1 angka.");
                }
            }
            while (true);

            if (firstName.Length >= 2 && lastName.Length >= 2)
            {
                string username = firstName.Substring(0, 2) + lastName.Substring(0, 2);

                var createUser = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Username = $"{firstName.Substring(0, 2)}{lastName.Substring(0, 2)}",
                    Password = password
                };

                daftarUser.Add(createUser);
                Console.WriteLine("Data user berhasil dibuat.");
            }
            else
            {
                Console.WriteLine("Input data tidak valid. First Name dan Last Name harus memiliki minimal 2 karakter.");
            }

            Console.ReadLine();
        }

        // Metode untuk memeriksa apakah password memenuhi syarat
        private static bool IsPasswordValid(string password)
        {
            // Memeriksa panjang password dan karakter-karakternya
            if (password.Length < 8)
            {
                return false;
            }

            // Memeriksa apakah terdapat setidaknya satu huruf kapital
            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            // Memeriksa apakah terdapat setidaknya satu huruf kecil
            if (!password.Any(char.IsLower))
            {
                return false;
            }

            // Memeriksa apakah terdapat setidaknya satu angka
            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            return true;
        }


        // MENU 2. Show User
        public static void ShowUser()
        {
            Console.Clear();
            Console.WriteLine("== SHOW USER ==");
            Console.WriteLine("========================");

            if (daftarUser.Count == 0)
            {
                Console.WriteLine("Tidak ada data yang tersedia. Silahkan membuat user baru.");
                Console.WriteLine();
                Console.WriteLine("Tekan Enter untuk kembali.");
            }

            else
            {
                foreach (var user in daftarUser)
                {
                    string firstName = user.FirstName;
                    string lastName = user.LastName;
                    string username = firstName.Substring(0, 2) + lastName.Substring(0, 2);

                    Console.WriteLine($"ID       : {daftarUser.IndexOf(user) + 1}");
                    Console.WriteLine($"Name     : {firstName} {lastName}");
                    Console.WriteLine($"Username : {username}");
                    Console.WriteLine($"Password : {user.Password}");
                    Console.WriteLine("========================");
                }

                // Tampilkan submenu setelah menampilkan daftar pengguna.
                SubMenuShowUser.SubMenu(daftarUser);
            }
            Console.ReadLine();
        }


        // MENU 3. Search User
        static void SearchUser()
        {
            Console.Clear();
            Console.WriteLine("== CARI AKUN ==");
            Console.Write("Masukkan Nama : ");
            string cariUser = Console.ReadLine();

            bool userFound = false;

            Console.WriteLine("========================");
            foreach (var user in daftarUser)
            {
                string firstName = user.FirstName;
                string lastName = user.LastName;
                string fullName = $"{firstName} {lastName}";
                string username = firstName.Substring(0, 2) + lastName.Substring(0, 2);

                // Jika nama pengguna terdapat string pencarian, maka tampilkan detail pengguna.
                if (fullName.Contains(cariUser, StringComparison.OrdinalIgnoreCase))
                {
                    //string username = firstName.Substring(0, 2) + lastName.Substring(0, 2);
                    Console.WriteLine($"ID       : {daftarUser.IndexOf(user) + 1}");
                    Console.WriteLine($"Name     : {fullName}");
                    Console.WriteLine($"Username : {username}");
                    Console.WriteLine($"Password : {user.Password}");
                    Console.WriteLine("========================");
                    userFound = true;
                }
            }

            if (!userFound)
            {
                Console.WriteLine("User tidak ditemukan.");
            }

            Console.ReadLine();
        }



        // MENU 4. Login User
        public static void LoginUser()
        {
            Console.Clear();
            Console.WriteLine("== LOGIN ==");
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            // Cari pengguna dengan username yang cocok.
            User userToLogin = daftarUser.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (userToLogin != null && userToLogin.Password == password)
            {
                Console.WriteLine("Login Berhasil");

                // Setelah login berhasil, jalankan program GanjilGenap.
                GanjilGenapProgram.Program.Main(); // Panggil metode untuk menjalankan program GanjilGenap.
            }
            else
            {
                Console.WriteLine("Login Gagal. Username atau Password salah.");
            }

            Console.ReadLine();
        }

    }
}