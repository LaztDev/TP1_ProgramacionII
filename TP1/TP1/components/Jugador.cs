namespace TP1.components;

public class Jugador {
    public string nombre;
    public int vidaActual;
    public int vidaMaxima;
    public int ataqueBase;
    public int ataqueTotal;
    public int oro;
    public int pisoActual;
    public Inventario inventario;
    private List<ItemReliquia> reliquias;

    public void atacar() {
        
    }

    public void equiparReliquia(ItemReliquia reliquia) {
        // Implementar la lógica para equipar la reliquia
    }

    public void mostrarEstado() {
        Console.WriteLine("====================================");
        Console.WriteLine($"Vida: {vidaActual}/{vidaMaxima}");
        Console.WriteLine($"Oro: {oro}");
        Console.WriteLine($"AtaqueTotal: {ataqueTotal} / Base: {ataqueBase}");
        Console.WriteLine($"//metodo para listar las reliquias");
        Console.WriteLine($"//metodo que muestra el inventario");
        Console.WriteLine($"PISO ACTUAL: {pisoActual}");
        Console.WriteLine("====================================");
    }
}