
namespace TP1.components;

public class Item {

    public string Nombre { get; protected set; }
    public string Tipo { get; protected set; }
    public int Efecto { get; protected set; }
    public int Precio { get; protected set; }

    public Item() {
        Nombre = "Item";
        Tipo = string.Empty;
    }

    public void usar() {
        Console.WriteLine($"se uso {Tipo}");
    }

    public void mostrarDetalle() {
        
    }
}

public class Posion : Item {
    public Posion() {
        Tipo="Posion";
    }
}
public class Reliquia : Item {
    public Reliquia() {
        Tipo = "Reliquia";
    }
}






