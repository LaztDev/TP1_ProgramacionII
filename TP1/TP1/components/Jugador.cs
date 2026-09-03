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

    public Jugador(string nombre, int vidaMaxima, int ataqueBase, int oro) {
        Nombre = nombre;
        VidaMaxima = vidaMaxima;
        VidaActual = vidaMaxima;
        AtaqueBase = ataqueBase;
        Oro = oro;
        PisoActual = 1;
    }

    public void atacar(Enemigo monstruo, int multiplicador) {
        monstruo.Vida = ataqueTotal * multiplicador >= monstruo.Vida ? 0 : ataqueTotal * multiplicador - monstruo.Vida;
    }

    public void equiparReliquia(Reliquia reliquia) {
        reliquia.usar(this);
        reliquias.Add(reliquia);
    }

    public void mostrarEstado() {
        Console.WriteLine("====================================================================================");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"Vida: {VidaActual} / {VidaMaxima}");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"     AtaqueTotal: {ataqueTotal} / Base: {AtaqueBase}");
        Console.ResetColor();
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"Oro: {Oro}");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("           PISO ACTUAL: {PisoActual}");
        Console.ResetColor();
        Console.WriteLine("====================================================================================");
    }
}