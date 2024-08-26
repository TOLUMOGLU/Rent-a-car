using Microsoft.AspNetCore.Mvc;
using Rent_A_Car.Models;
using System.Data.SqlClient;
using System.Reflection;

namespace Rent_A_Car.Controllers
{
    public class CarsController : Controller
    {
        #region Cars

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Araba model)
        {

            String ad = "";
            int arabaUcret = 0;
            Console.WriteLine(model.ArabaSinifID);
            if (model.ArabaSinifID == 1)
            {
                ad = "SUV";
                arabaUcret = 500;
            }
            else if (model.ArabaSinifID == 2)
            {
                ad = "Sedan";
                arabaUcret = 200;
            }
            else if (model.ArabaSinifID == 3)
            {
                ad = "Hatchback";
                arabaUcret = 100;
            }
            else if (model.ArabaSinifID == 4)
            {
                ad = "Station Wagon";
                arabaUcret = 400;
            }




            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "INSERT INTO Arac " +
                    "(SinifID,Plaka,Marka,Model,Renk)VALUES " + "(@sinifID,@plaka,@marka,@model,@renk);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@sinifID", model.ArabaSinifID);
                        command.Parameters.AddWithValue("@plaka", model.ArabaPlaka);
                        command.Parameters.AddWithValue("@marka", model.ArabaMarka);
                        command.Parameters.AddWithValue("@model", model.ArabaModel);
                        command.Parameters.AddWithValue("@renk", model.ArabaRenk);


                        command.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index", "Anasayfa");

        }

        [HttpGet]

        public IActionResult Edit(string id)
        {
            Araba araba = new Araba();

            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Select * from Arac Where Plaka=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader()) {

                            if (reader.Read())
                            {


                                araba.ArabaPlaka = reader.GetString(0);
                                araba.ArabaMarka = reader.GetString(1);
                                araba.ArabaModel = reader.GetString(2);
                                araba.ArabaRenk = reader.GetString(3);
                                araba.ArabaSinifID = reader.GetInt32(4);


                            }


                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ViewBag.sinifID = araba.ArabaSinifID;
            ViewBag.plaka = araba.ArabaPlaka;
            ViewBag.marka = araba.ArabaMarka;
            ViewBag.model = araba.ArabaModel;
            ViewBag.renk = araba.ArabaRenk;

            return View();
        }


        [HttpPost]

        public IActionResult Edit(Araba model)
        {
            String ad = "";

            Console.WriteLine(model.ArabaSinifID);
            if (model.ArabaSinifID == 1)
            {
                ad = "SUV";

            }
            else if (model.ArabaSinifID == 2)
            {
                ad = "Sedan";

            }
            else if (model.ArabaSinifID == 3)
            {
                ad = "Hatchback";

            }
            else if (model.ArabaSinifID == 4)
            {
                ad = "Station Wagon";

            }

            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "UPDATE Arac  SET ArabaSinifID=@sinifID, Marka=@marka, Model=@model, Renk=@renk , SinifID=@sinifID  WHERE plaka=@plaka";

                    Console.WriteLine(sql);
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@sinifID", model.ArabaSinifID);
                        command.Parameters.AddWithValue("@plaka", model.ArabaPlaka);
                        command.Parameters.AddWithValue("@marka", model.ArabaMarka);
                        command.Parameters.AddWithValue("@model", model.ArabaModel);
                        command.Parameters.AddWithValue("@renk", model.ArabaRenk);


                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index", "Anasayfa");
        }


        public IActionResult Delete(string id)
        {
            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Delete from Arac Where Plaka=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index", "Anasayfa");
        }

        [HttpGet]
        public IActionResult Rent(string id)
        {
            Araba araba = new Araba();

            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Select * from Arac Where Plaka=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                araba.ArabaSinifID = reader.GetInt32(0);
                                araba.ArabaPlaka = reader.GetString(1);
                                araba.ArabaMarka = reader.GetString(2);
                                araba.ArabaModel = reader.GetString(3);
                                araba.ArabaRenk = reader.GetString(4);




                            }


                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            ViewBag.sinifID = araba.ArabaSinifID;
            ViewBag.plaka = araba.ArabaPlaka;
            ViewBag.marka = araba.ArabaMarka;
            ViewBag.model = araba.ArabaModel;
            ViewBag.renk = araba.ArabaRenk;



            return View();
        }

        [HttpPost]

        public IActionResult Rent(Musteri model, Kira model2, int ucret)
        {



            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "INSERT INTO Musteri " +
                    "(TC,Ad,Adres,Telefon)VALUES " + "(@tck,@ad,@adres,@telefon);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@tck", model.MusteriTCK);
                        command.Parameters.AddWithValue("@ad", model.MusteriAd);
                        command.Parameters.AddWithValue("@adres", model.MusteriAdres);
                        command.Parameters.AddWithValue("@telefon", model.MusteriTelefon);
                        command.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "INSERT INTO Kiralama " +
                    "(MusteriTC,ArabaPlaka,Tarih,Ucret)VALUES " + "(@musteriTc,@arabaPlaka,@tarih,@ucret);";
                    DateTime today = DateTime.Today;
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@musteriTc", model2.kiraMusteriTc);
                        command.Parameters.AddWithValue("@arabaPlaka", model2.kiraArabaPlaka);
                        command.Parameters.AddWithValue("@tarih", today.ToString());
                        command.Parameters.AddWithValue("@ucret", model2.kiraUcret);

                        command.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index", "Anasayfa");
        }

        #endregion

        #region Customers

        public List<Musteri> _musteriler = new List<Musteri>();
        public IActionResult Customers()
        {
            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "Select * from Musteri";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                Musteri musteri = new Musteri();
                                musteri.MusteriTCK = reader.GetString(0);
                                musteri.MusteriAd = reader.GetString(1);
                                musteri.MusteriAdres = reader.GetString(2);
                                musteri.MusteriTelefon = reader.GetString(3);

                                Console.WriteLine(musteri);
                                _musteriler.Add(musteri);

                            }

                        }
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is" + ex.ToString());
            }
            return View(_musteriler);
        }

        [HttpGet]

        public IActionResult CustomersEdit(long id)
        {
            Musteri musteri = new Musteri();

            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Select * from Musteri Where TC=@tck";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@tck", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                musteri.MusteriTCK = reader.GetString(0);
                                musteri.MusteriAd = reader.GetString(1);
                                musteri.MusteriAdres = reader.GetString(2);
                                musteri.MusteriTelefon = reader.GetString(3);
                            }


                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ViewBag.tck = musteri.MusteriTCK;
            ViewBag.ad = musteri.MusteriAd;
            ViewBag.adres = musteri.MusteriAdres;
            ViewBag.telefon = musteri.MusteriTelefon;
            return View();
        }


        [HttpPost]

        public IActionResult CustomersEdit(Musteri model)
        {


            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "UPDATE Musteri SET TC=@tck, Ad=@ad, Adres=@adres, Telefon=@telefon WHERE tck=@tck";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@tck", model.MusteriTCK);
                        command.Parameters.AddWithValue("@ad", model.MusteriAd);
                        command.Parameters.AddWithValue("@adres", model.MusteriAdres);
                        command.Parameters.AddWithValue("@telefon", model.MusteriTelefon);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Bura");
            }

            return RedirectToAction("Customers", "Cars");
        }


        public IActionResult CustomersDelete(long id)
        {
            Console.WriteLine(id);
            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Delete from Musteri Where TC=@tck";


                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@tck", id);
                        command.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Customers", "Cars");
        }


        [HttpGet]
        public IActionResult CustomersCreate()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CustomersCreate(Musteri model)
        {




            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "INSERT INTO Musteri " +
                    "(TC,Ad,Adres,Telefon)VALUES " + "(@tck,@ad,@adres,@telefon);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@tck", model.MusteriTCK);
                        command.Parameters.AddWithValue("@ad", model.MusteriAd);
                        command.Parameters.AddWithValue("@adres", model.MusteriAdres);
                        command.Parameters.AddWithValue("@telefon", model.MusteriTelefon);
                        command.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Customers", "Cars");

        }


        #endregion

        /// <summary>
        /// ////////////////////
        /// </summary>

        #region Kira
        public List<Kira> _kiralar = new List<Kira>();
        public IActionResult Rents()
        {
            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "Select * from Kiralama";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                Kira kira = new Kira();
                                kira.kiraTarih = reader.GetString(0);
                                kira.kiraUcret = reader.GetString(1);
                                kira.kiraMusteriTc = reader.GetString(2);
                                kira.kiraArabaPlaka = reader.GetString(3);
                                _kiralar.Add(kira);

                            }

                        }
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is" + ex.ToString());
            }
            return View(_kiralar);
        }

        [HttpGet]
        public IActionResult RentsCreate()
        {
            return View();
        }



        [HttpPost]
        public IActionResult RentsCreate(Kira model)
        {


            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "INSERT INTO Kiralama " +
                    "(MusteriTC,ArabaPlaka,Tarih,Ucret)VALUES " + "(@tc,@plaka,@tarih,@ucret);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@tc", model.kiraMusteriTc);
                        command.Parameters.AddWithValue("@plaka", model.kiraArabaPlaka);
                        command.Parameters.AddWithValue("@tarih", model.kiraTarih);
                        command.Parameters.AddWithValue("@ucret", model.kiraUcret);
                        command.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Rents", "Cars");

        }

        [HttpGet]

        public IActionResult RentsEdit(string id)
        {
            Console.WriteLine(id);
            Kira kira = new Kira();

            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Select * from Kiralama Where Tarih=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                kira.kiraMusteriTc = reader.GetString(0);
                                kira.kiraArabaPlaka = reader.GetString(1);
                                kira.kiraTarih = reader.GetString(2);
                                kira.kiraUcret = reader.GetString(3);



                            }


                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ViewBag.Tarih = kira.kiraTarih;
            ViewBag.cret = kira.kiraUcret;
            ViewBag.MusteriTC = kira.kiraMusteriTc;
            ViewBag.ArabaPlaka = kira.kiraArabaPlaka;
            return View();
        }


        [HttpPost]

        public IActionResult RentsEdit(Kira model)
        {


            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "UPDATE Kiralama SET  MusteriTC=@tck, ArabaPlaka=@plaka, Ucret=@ucret,   WHERE Tarih=@tarih";

                    Console.WriteLine(sql);
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ucret", model.kiraMusteriTc);
                        command.Parameters.AddWithValue("@tck", model.kiraArabaPlaka);
                        command.Parameters.AddWithValue("@plaka", model.kiraUcret);
                        command.Parameters.AddWithValue("@tarih", model.kiraTarih);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Rents", "Cars");
        }


        public IActionResult RentsDelete(string id)
        {
            try
            {
                String connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=RentaCar;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    String sql = "Delete from Kiralama Where Tarih=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Rents", "Cars");
        }



        #endregion

        // Araç Sınıfları



    }
}
