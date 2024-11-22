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
        static Connect conn = new Connect();

        public static void GetAllBooks()
        {
            conn.Connection.Open();
            string sql = "SELECT * FROM Konyvek";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            Console.WriteLine("Könyvek listája:");

            while (dr.Read())
            {
                var book = new
                {
                    Id = dr.GetInt32(0),
                    Konyvnev = dr.GetString(1),
                    Helye = dr.GetString(2),
                    Kolcsonyzes = dr.GetDateTime(3)
                };

                Console.WriteLine($"ID: {book.Id}, Név: {book.Konyvnev}, Helye: {book.Helye}, Kölcsönzés dátuma: {book.Kolcsonyzes}");
            }

            dr.Close();
            conn.Connection.Close();
        }

        static void Main(string[] args)
        {
            GetAllBooks();
        }
    }
}

