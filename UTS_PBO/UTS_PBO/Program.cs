using System;
using System.Collections;

namespace UTS_PBO

{
        class Produk
        {
            public string Nama { get; set; }
            public double Harga { get; set; }

            public Produk(string nama, double harga)
            {
                Nama = nama;
                Harga = harga;
            }

            public virtual void InfoProduk()
            {
                Console.WriteLine($"Nama: {Nama}, Harga: {Harga}");
            }

            public virtual string Kategori()
            {
                return "Produk Umum";
            }
        }
    class Toko
    {
        private List<Produk> daftarProduk = new List<Produk>();

        public void TambahProduk(Produk produk)
        {
            daftarProduk.Add(produk);
        }

        public void DaftarProduk()
        {
            foreach (var p in daftarProduk)
            {
                p.InfoProduk();
                Console.WriteLine($"Kategori: {p.Kategori()}");
            }
        }
    }

    class Elektronik : Produk
        {
            public int Garansi { get; set; }

            public Elektronik(string nama, double harga, int garansi)
                : base(nama, harga)
            {
                Garansi = garansi;
            }

            public void CekGaransi()
            {
                Console.WriteLine($"Garansi: {Garansi} bulan");
            }

            public override string Kategori()
            {
                return "Elektronik";
            }
        }

        class Makanan : Produk
        {
            public DateTime TanggalKadaluarsa { get; set; }

            public Makanan(string nama, double harga, DateTime tgl)
                : base(nama, harga)
            {
                TanggalKadaluarsa = tgl;
            }

            public void CekKadaluarsa()
            {
                Console.WriteLine($"Kadaluarsa: {TanggalKadaluarsa.ToShortDateString()}");
            }

            public override string Kategori()
            {
                return "Makanan";
            }
        }

        class Laptop : Elektronik
        {
            public Laptop(string nama, double harga, int garansi)
                : base(nama, harga, garansi) { }

            public void InstallSoftware()
            {
                Console.WriteLine("Software berhasil diinstall.");
            }

            public override string Kategori()
            {
                return "Laptop";
            }
        }

        class HP : Elektronik
        {
            public HP(string nama, double harga, int garansi)
                : base(nama, harga, garansi) { }

            public void Telepon()
            {
                Console.WriteLine("Melakukan panggilan...");
            }

            public override string Kategori()
            {
                return "HP";
            }
        }

        class Snack : Makanan
        {
            public Snack(string nama, double harga, DateTime tgl)
                : base(nama, harga, tgl) { }

            public void Makan()
            {
                Console.WriteLine("Snack dimakan.");
            }

            public override string Kategori()
            {
                return "Snack";
            }
        }

        class Minuman : Makanan
        {
            public Minuman(string nama, double harga, DateTime tgl)
                : base(nama, harga, tgl) { }

            public void Dinginkan()
            {
                Console.WriteLine("Minuman didinginkan.");
            }

            public override string Kategori()
            {
                return "Minuman";
            }
        }
        
    class Program
    {
        static void Main()
        {
            Toko toko = new Toko();

            Laptop laptop = new Laptop("Asus", 8000000, 12);
            HP hp = new HP("Samsung", 5000000, 12);
            Snack snack = new Snack("Chitato", 10000, DateTime.Now.AddDays(30));
            Minuman minuman = new Minuman("Teh Botol", 5000, DateTime.Now.AddDays(10));

            toko.TambahProduk(laptop);
            toko.TambahProduk(hp);
            toko.TambahProduk(snack);
            toko.TambahProduk(minuman);

            toko.DaftarProduk();

            // Polymorphism
            Produk p = new HP("Xiaomi", 3000000, 12);
            Console.WriteLine(p.Kategori());

            // Method khusus
            laptop.InstallSoftware();
            minuman.Dinginkan();
        }
    }
}