using System;
using LinkedList.Perpustakaan;
using LinkedList.Inventori;
using LinkedList.ManajemenKaryawan;
namespace LinkedList;


public class Program
{
    public static void Main()
    {
        //Perpustakaan
        var koleksi = new KoleksiPerpustakaan();

        koleksi.TambahBuku(new Buku("The Hobbit", "J.R.R. Tolkien", 1937));
        koleksi.TambahBuku(new Buku("1984", "George Orwell", 1949));
        koleksi.TambahBuku(new Buku("The Catcher in the Rye", "J.D. Salinger", 1951));

        Console.WriteLine("Koleksi Buku:");
        koleksi.TampilkanKoleksi();

        Console.WriteLine("\nHasil Pencarian untuk 'The':");
        var hasilPencarian = koleksi.CariBuku("The");
        foreach (var buku in hasilPencarian)
        {
            Console.WriteLine($"\"{buku.Judul}\"; {buku.Penulis}; {buku.Tahun}");
        }

        Console.WriteLine("\nMenghapus buku '1984':");
        if (koleksi.HapusBuku("1984"))
        {
            Console.WriteLine("Buku berhasil dihapus.");
            koleksi.HapusBuku("1984");
        }
        else
        {
            Console.WriteLine("Buku tidak ditemukan.");
        }

        Console.WriteLine("\nKoleksi Buku setelah penghapusan:");
        koleksi.TampilkanKoleksi();

        //Karyawan

        var daftarKaryawan = new DaftarKaryawan();

        daftarKaryawan.TambahKaryawan(new Karyawan("EMP001", "John Doe", "Software Engineer"));
        daftarKaryawan.TambahKaryawan(new Karyawan("EMP002", "Jane Smith", "Product Manager"));
        daftarKaryawan.TambahKaryawan(new Karyawan("EMP003", "Bob Johnson", "QA Tester"));
        daftarKaryawan.TambahKaryawan(new Karyawan("EMP004", "Alice Brown", "UX Designer"));

        Console.WriteLine("Daftar Karyawan:");
        string daftar = daftarKaryawan.TampilkanDaftar();
        Console.WriteLine(daftar ?? "Tidak ada karyawan");

        Console.WriteLine("\nHasil pencarian 'engineer':");
        var hasil = daftarKaryawan.CariKaryawan("engineer");
        foreach (var karyawan in hasil)
        {
            Console.WriteLine($"{karyawan.NomorKaryawan}; {karyawan.Nama}; {karyawan.Posisi}");
        }

        Console.WriteLine("\nMenghapus karyawan EMP002...");
        bool berhasilHapus = daftarKaryawan.HapusKaryawan("EMP002");
        Console.WriteLine(berhasilHapus ? "Berhasil dihapus" : "Karyawan tidak ditemukan");

        Console.WriteLine("\nDaftar setelah penghapusan:");
        daftar = daftarKaryawan.TampilkanDaftar();
        Console.WriteLine(daftar ?? "Tidak ada karyawan");

        //Inventori

        var inventori = new ManajemenInventori();

        inventori.TambahItem(new Item("Pensil", 50));
        inventori.TambahItem(new Item("Buku", 30));
        inventori.TambahItem(new Item("Penghapus", 20));

        Console.WriteLine(inventori.TampilkanInventori() ?? "Inventori kosong");

        inventori.HapusItem("Buku");

        Console.WriteLine(inventori.TampilkanInventori() ?? "Inventori kosong");
    }
}
