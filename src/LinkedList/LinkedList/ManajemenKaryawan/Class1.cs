using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace LinkedList.ManajemenKaryawan;

public class Karyawan
{
    public string NomorKaryawan { get; set; }
    public string Nama { get; set; }
    public string Posisi { get; set; }

    public Karyawan(string nomorKaryawan, string nama, string posisi)
    {
        NomorKaryawan = nomorKaryawan;
        Nama = nama;
        Posisi = posisi;
    }   
}

public class KaryawanNode
{
    public Karyawan Karyawan { get; set; }
    public KaryawanNode Next { get; set; }
    public KaryawanNode Prev { get; set; }

    public KaryawanNode(Karyawan karyawan)
    {
        Karyawan = karyawan;
        Next = null;
        Prev = null;
    }

}

public class DaftarKaryawan
{
    private KaryawanNode Head { get; set; }
    private KaryawanNode Tail { get; set; }

    public void TambahKaryawan(Karyawan karyawan)
    {
        var node = new KaryawanNode(karyawan);

        if (Head == null)
        {
            Head = node;
            Tail = node;
        }
        else
        {
            Tail.Next = node;
            node.Prev = Tail;
            Tail = node;
        }
    }
    public bool HapusKaryawan(string nomorKaryawan)
    {

        var current = Head;
        while (current != null)
        {
            if (current.Karyawan.NomorKaryawan == nomorKaryawan)
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    Head = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    Tail = current.Prev;
                }

                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public Karyawan[] CariKaryawan(string kataKunci)
    {
        var hasil = new List<Karyawan>();
        var current = Head;
        while (current != null)
        {
            if (current.Karyawan.Nama.Contains(kataKunci, StringComparison.OrdinalIgnoreCase) ||
                current.Karyawan.Posisi.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
            {
                hasil.Add(current.Karyawan);
            }
            current = current.Next;
        }
        return hasil.ToArray();
    }

    public string TampilkanDaftar()
    {   
        if (Head == null) return null;
        var result = "";
        var current = Tail;
        while (current != null)
        {
           result += $"{current.Karyawan.NomorKaryawan}; {current.Karyawan.Nama}; {current.Karyawan.Posisi}\n";
            current = current.Prev;
        }
        return result;
    }
}
