namespace TP1.components;

public class Jugador {
    public string Nombre;
    public int VidaActual;
    public int VidaMaxima;
    public int AtaqueBase;
    public int AtaqueTemporal;
    public int Oro;
    public int PisoActual;
    public Inventario inventario = new Inventario();
    private List<Reliquia> reliquias = new List<Reliquia>();

    public int ataqueTotal {
        get { return AtaqueBase + AtaqueTemporal; }
    }

    public Jugador(string nombre) {
        Nombre = nombre;
    }

    public void atacar(Enemigo monstruo) {
        monstruo.vida = ataqueTotal >= monstruo.vida ? 0 : ataqueTotal - monstruo.vida;
    }

    public void equiparReliquia(Reliquia reliquia) {
        reliquia.usar(this);
        reliquias.Add(reliquia);
    }

    public void mostrarEstado() {
        Console.WriteLine("====================================");
        Console.WriteLine($"Vida: {VidaActual}/{VidaMaxima}");
        Console.WriteLine($"Oro: {Oro}");
        Console.WriteLine($"AtaqueTotal: {ataqueTotal} / Base: {AtaqueBase}");
        Console.WriteLine($"//metodo para listar las reliquias");
        Console.WriteLine($"//metodo que muestra el inventario");
        Console.WriteLine($"PISO ACTUAL: {PisoActual}");
        Console.WriteLine("====================================");
    }
}