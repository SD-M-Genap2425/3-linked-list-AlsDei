using System.Diagnostics.Contracts;

namespace LinkedList.Inventori;

public class Item
{
    public string Nama { get; set; }
    public int Kuantitas { get; set; }

    public Item(string nama, int kuantitas)
    {
        Nama = nama;
        Kuantitas = kuantitas;
    }
}

public class ManajemenInventori
{
    private List<Item> _inventori = new List<Item>();

    public void TambahItem(Item item)
    {
        _inventori.Add(item);
    }

    public bool HapusItem(string nama)
    {
        var item = _inventori.FirstOrDefault(i => i.Nama == nama);
        if (item != null)
        {
            _inventori.Remove(item);
            return true;
        }
        return false;
    }

    public string TampilkanInventori()
    {
        if (_inventori.Count == 0)
        {
            return null;
        }

        var result = "";
        foreach (var item in _inventori)
        {
            result += $"{item.Nama}; {item.Kuantitas}{Environment.NewLine}";
        }

        return result.TrimEnd();
    }
}
