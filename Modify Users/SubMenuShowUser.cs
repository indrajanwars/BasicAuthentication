namespace BasicAuthentication
{
    public static class SubMenuShowUser
    {
        public static void SubMenu(List<User> daftarUser)
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Back");

            Console.Write("Pilih menu: ");
            string submenuPilih = Console.ReadLine();

            switch (submenuPilih)
            {
                case "1":
                    EditUser(daftarUser);
                    break;
                case "2":
                    DeleteUser(daftarUser);
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Input tidak valid.");
                    break;
            }
        }

        public static void EditUser(List<User> daftarUser)
        {
            Console.WriteLine("== EDIT USER ==");
            Console.Write("Masukkan ID user yang ingin diedit: ");
            if (int.TryParse(Console.ReadLine(), out int userId) && userId >= 1 && userId <= daftarUser.Count)
            {
                // Mendapatkan pengguna berdasarkan ID.
                User userToEdit = daftarUser[userId - 1];

                Console.Write("Edit First Name: ");
                string newFirstName = Console.ReadLine();
                Console.Write("Edit Last Name: ");
                string newLastName = Console.ReadLine();
                Console.Write("Edit Password: ");
                string newPassword = Console.ReadLine();

                // Update data pengguna.
                userToEdit.FirstName = newFirstName;
                userToEdit.LastName = newLastName;
                userToEdit.Password = newPassword;

                Console.WriteLine("Data user berhasil diubah.");
            }
            else
            {
                Console.WriteLine("ID user tidak valid.");
            }

            Console.ReadLine();
            Program.ShowUser();
        }


        public static void DeleteUser(List<User> daftarUser)
        {
            Console.WriteLine("== DELETE USER ==");
            Console.Write("Masukkan ID user yang ingin dihapus: ");
            if (int.TryParse(Console.ReadLine(), out int userId) && userId >= 1 && userId <= daftarUser.Count)
            {
                // Mendapatkan pengguna berdasarkan ID.
                User userToDelete = daftarUser[userId - 1];

                // Konfirmasi penghapusan.
                Console.Write($"Apakah Anda yakin ingin menghapus user {userToDelete.FirstName} {userToDelete.LastName}? (Y/N): ");
                string confirmation = Console.ReadLine();

                if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    daftarUser.Remove(userToDelete);
                    Console.WriteLine("Data user berhasil dihapus.");
                }
                else
                {
                    Console.WriteLine("Penghapusan dibatalkan.");
                }
            }
            else
            {
                Console.WriteLine("ID user tidak valid.");
            }

            Console.ReadLine();
            Program.ShowUser();
        }
    }

}
