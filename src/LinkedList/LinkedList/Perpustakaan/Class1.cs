namespace LinkedList.Perpustakaan;

public class Buku
{
    public string Judul { get; }
    public string Penulis { get; }
    public int Tahun { get; }

    public Buku(string judul, string penulis, int tahun)
    {
        Judul = judul;
        Penulis = penulis;
        Tahun = tahun;
    }
}

public class BukuNode
{
    public Buku Data { get; }
    public BukuNode? Next { get; set; }

    public BukuNode(Buku buku)
    {
        Data = buku;
        Next = null;
    }
}

public class KoleksiPerpustakaan
{
    private BukuNode? head;

    public void TambahBuku(Buku buku)
    {
        var newNode = new BukuNode(buku);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            var current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public bool HapusBuku(string judul)
    {
        if (head == null) return false;

        if (head.Data.Judul == judul)
        {
            head = head.Next;
            return true;
        }

        var current = head;
        while (current.Next != null && current.Next.Data.Judul != judul)
        {
            current = current.Next;
        }

        if (current.Next == null) return false;

        current.Next = current.Next.Next;
        return true;
    }

    public Buku[] CariBuku(string kataKunci)
    {
        var hasil = new List<Buku>();
        var current = head;

        while (current != null)
        {
            if (current.Data.Judul.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
            {
                hasil.Add(current.Data);
            }
            current = current.Next;
        }

        return hasil.ToArray();
    }

    public string TampilkanKoleksi()
    {
        var current = head;
        var result = "\0";
        if(current == null)
        {
            return "";
        }
        while (current != null)
        {
           result += $"\"{current.Data.Judul}\"; {current.Data.Penulis}; {current.Data.Tahun}";
            current = current.Next;
        }
        return result;
    }
}
