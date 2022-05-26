using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SqlConnectionTest
{
    internal class Program
    {
        static string baglanticumlesi = @"Server=localhost;
                                       Database=Northwind;
                                       User Id=sa;
                                       Password=123;";
        static void Main(string[] args)
        {
            SqlBaglanti();
            //SqlKayitEkle();
            //KayitSayisi();
        }
        private static void GetShippers()
        {
            List<Shipper> kargocular = new List<Shipper>();

            string sqlKomut = @"Select * from Shippers";
            
            SqlConnection sqlConnection = new SqlConnection(baglanticumlesi);
            try
            {
                SqlCommand sqlCommand = new SqlCommand(sqlKomut, sqlConnection);
                sqlConnection.Open();

                // ExecuteScaler geriye sabit bir deger dondugunde kullanilir
                SqlDataReader rdr = sqlCommand.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr["CompanyName"] + " " + rdr["Phone"]);
                    Shipper kargocu = new Shipper();
                    kargocu.ShipperId = (int)rdr["ShipperId"];
                    kargocu.CompanyName = (string)rdr["CompanyName"];
                    kargocu.Phone = (string)rdr["Phone"];

                    kargocular.Add(kargocu);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {

                sqlConnection.Close();
            }
        }
        public static void KayitSayisi()
        {
            string sqlKomut = "Select count(*) from Orders";
            string baglanticumlesi = @"Server=localhost;
                                       Database=Northwind;
                                       User Id=sa;
                                       Password=123;";
            SqlConnection sqlConnection = new SqlConnection(baglanticumlesi);
            try
            {

                SqlCommand sqlCommand = new SqlCommand(sqlKomut, sqlConnection);
                sqlConnection.Open();
                //ExecuteNonQuery adi uzerinde NonQuery
                int sonuc = (int)sqlCommand.ExecuteScalar();
                if (sonuc > 0)
                {
                    Console.WriteLine("Toplam siparis sayısı"+sonuc);
                }
                else
                {
                    Console.WriteLine("Basarısız işlem.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public static void SqlKayitEkle()
        {
            string sqlKomut = "Insert into shippers (CompanyName,Phone)Values('Mng Kargo','2124551212')";
            string baglanticumlesi = @"Server=localhost;
                                       Database=Northwind;
                                       User Id=sa;
                                       Password=123;";
            SqlConnection sqlConnection = new SqlConnection(baglanticumlesi);
            try
            {

                SqlCommand sqlCommand = new SqlCommand(sqlKomut, sqlConnection);
                sqlConnection.Open();
                //ExecuteNonQuery adi uzerinde NonQuery
                int sonuc = sqlCommand.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    Console.WriteLine("İşlem Basarılı");
                }
                else
                {
                    Console.WriteLine("Kayıt Yapılamadı.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        private static void SqlBaglanti()
        {
            //Çalıstıracagımız komut.
            string sqlkomut = "Select * from Customers";

            //Sql server'a baglantı için bir connectionstrings tanımlamamız gerekir.
            string baglanticumlesi = @"Server=localhost;
                            Database=Northwind;
                            User Id=sa;
                            Password=123;";

            //sqlServer'a baglanmak için ADO.Net nesnesi
            //sqlconnection nesnesi sadece baglantı kurmaya yarar
            //komut calıstırmaz. Baglantıyı acar ve kapar.
            SqlConnection db = new SqlConnection(baglanticumlesi);
            db.Open();
            Console.WriteLine("Baglantı durumu: " + db.State);

            //Komut calıstırmak icin gerekli nesne
            SqlCommand cmd = new SqlCommand(sqlkomut, db);

            //verilen komut sonuc seti geri donuyorsa sqldatareader ile verileri karsılarız.
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr["CustomerID"] + " " + rdr["CompanyName"] + " " + rdr["ContactName"]);
            }


            Console.WriteLine("Hello World!");
            db.Close();
            Console.WriteLine("Baglantı durumu: " + db.State);
        }
    }
}
