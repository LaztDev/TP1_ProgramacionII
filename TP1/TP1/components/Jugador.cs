namespace TP1.components;

public class Jugador {
    public string Nombre;
    public int VidaActual;
    public int VidaMaxima;
    public int AtaqueBase;
    public int AtaqueTemporal;
    public int Oro;
    public int PisoActual;
    public int PisosTotales;
    public Inventario inventario = new Inventario();
    private List<Reliquia> reliquias = new List<Reliquia>();

    public int ataqueTotal {
        get { return AtaqueBase + AtaqueTemporal; }
    }

    public Jugador(string nombre, int vidaMaxima, int ataqueBase, int oro, int SalasTotales) {
        Nombre = nombre;
        VidaMaxima = vidaMaxima;
        VidaActual = vidaMaxima;
        AtaqueBase = ataqueBase;
        Oro = oro;
        PisoActual = 1;
        PisosTotales = SalasTotales;
    }

    public void atacar(Enemigo monstruo, int tipoAtaque) {

        if (tipoAtaque>= 5 && tipoAtaque <= 6) {
            Console.WriteLine("Ataque crítico!");
            monstruo.Vida = ataqueTotal * 2 >= monstruo.Vida ? 0 : monstruo.Vida - ataqueTotal * 2;
        }
        else if (tipoAtaque >= 2 && tipoAtaque <= 4) {
            Console.WriteLine("ataque normal!");
            monstruo.Vida = ataqueTotal * 1 >= monstruo.Vida ? 0 : monstruo.Vida - ataqueTotal * 1;
        }
        else if (tipoAtaque == 1) {
            Console.WriteLine("Fallaste el ataque!");
            monstruo.Vida = ataqueTotal * 0 >= monstruo.Vida ? 0 : monstruo.Vida - ataqueTotal * 0;
        }
    }
    public void equiparReliquia(Reliquia reliquia) {
        reliquia.usar(this);
        reliquias.Add(reliquia);
    }

    public void mostrarEstado() {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"❤  {VidaActual} / {VidaMaxima}  ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"🗡  {ataqueTotal} / Base: {AtaqueBase}  ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"🪙  {Oro}  ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"PISO ACTUAL: {PisoActual} / {PisosTotales} ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n=====================================================================");
        Console.ResetColor();
    }
}