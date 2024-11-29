using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar
{
    internal class Program
    {
        public static Connect conn = new Connect();

        public static void HozzaAdas()
        {
            Console.Write("Add meg a könyv nevét: ");
            string konyvnev = Console.ReadLine();

            Console.Write("Add meg a könyv helyét (pl. Polc 1, Szekrény 4): ");
            string helye = Console.ReadLine();

            Console.Write("Add meg a kölcsönzés dátumát (yyyy-mm-dd): ");
            DateTime kolcsonzes;
            while (!DateTime.TryParse(Console.ReadLine(), out kolcsonzes))
            {
                Console.Write("Hibás dátumformátum! Próbáld újra (yyyy-mm-dd): ");
            }

            conn.Connection.Open();

            string sql = "INSERT INTO Konyvek (Konyvnev, Helye, Kolcsonzes) VALUES (@Konyvnev, @Helye, @Kolcsonzes)";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.Parameters.AddWithValue("@Konyvnev", konyvnev);
            cmd.Parameters.AddWithValue("@Helye", helye);
            cmd.Parameters.AddWithValue("@Kolcsonzes", kolcsonzes);

            cmd.ExecuteNonQuery();

            conn.Connection.Close();

            Console.WriteLine("Az új könyv sikeresen hozzáadva az adatbázishoz!");
        }

        public static void Torles()
        {
            Console.Write("Add meg a törölni kívánt könyv azonosítóját (Id): ");
            int id = int.Parse(Console.ReadLine());

            conn.Connection.Open();

            string sql = "DELETE FROM Konyvek WHERE Id = @Id";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();

            conn.Connection.Close();

            Console.WriteLine("A könyv törölve az adatbázisból.");
        }

        public static void KiIras()
        {
            conn.Connection.Open();

            string sql = "SELECT * FROM Konyvek";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            Console.WriteLine("\nKönyvek listája:");
            while (dr.Read())
            {
                Console.WriteLine($"Id: {dr.GetInt32(0)}, Név: {dr.GetString(1)}, Helye: {dr.GetString(2)}, Kölcsönzés dátuma: {dr.GetDateTime(3)}");
            }

            dr.Close();
            conn.Connection.Close();
        }

        public static void Frissit()
        {
            conn.Connection.Open();

            Console.Write("Add meg a frissítendő könyv ID-ját: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Add meg az új könyv nevét: ");
            string konyvnev = Console.ReadLine();

            Console.Write("Add meg az új helyet (pl. Polc 2, Szekrény 3): ");
            string helye = Console.ReadLine();

            Console.Write("Add meg az új kölcsönzés dátumát (yyyy-mm-dd): ");
            DateTime kolcsonzes = DateTime.Parse(Console.ReadLine());

            string sql = "UPDATE Konyvek SET Konyvnev = @Konyvnev, Helye = @Helye, Kolcsonzes = @Kolcsonzes WHERE Id = @Id";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            cmd.Parameters.AddWithValue("@Konyvnev", konyvnev);
            cmd.Parameters.AddWithValue("@Helye", helye);
            cmd.Parameters.AddWithValue("@Kolcsonzes", kolcsonzes);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
            conn.Connection.Close();

            Console.WriteLine("A könyv adatai sikeresen frissítve!");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nKönyvtár Kezelő");
                Console.WriteLine("1. Új könyv hozzáadása");
                Console.WriteLine("2. Könyv törlése");
                Console.WriteLine("3. Könyvek listázása");
                Console.WriteLine("4. Könyv frissítése");
                Console.WriteLine("5. Kilépés");
                Console.Write("Válassz egy opciót: ");

                string valasztas = Console.ReadLine();

                switch (valasztas)
                {
                    case "1":
                        HozzaAdas();
                        break;
                    case "2":
                        Torles();
                        break;
                    case "3":
                        KiIras();
                        break;
                    case "4":
                        Frissit();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Érvénytelen választás, próbáld újra!");
                        break;
                }
            }
        }
    }
}

