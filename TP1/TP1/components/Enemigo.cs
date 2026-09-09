namespace TP1.components;

public class Enemigo {
    public Item? posibleDrop; // el ? indica que puede ser null, esto por la exccepcion decompilador preguntar al profe####################################
    public string Nombre { get; set; }
    public int Vida { get; set; }
    public int PuntosAtaque { get; set; }
    public int OroRecompensa { get; protected set; }

    public Enemigo(string nombre, int vida, int puntosAtaque, float multiDificultad, Random random, List<Item> itemsposibles) {
        Nombre = nombre;
        Vida = Convert.ToInt32(vida * multiDificultad);
        PuntosAtaque = Convert.ToInt32(puntosAtaque * multiDificultad);
        OroRecompensa = Convert.ToInt32(20 * multiDificultad);
        ItemRandom(random, itemsposibles);
    }
    public void atacar(Jugador player, int tipoAtaque) {
        Console.Write($"{Nombre}");
        if (tipoAtaque >= 5 && tipoAtaque <= 6) {
            Console.WriteLine($"dio un golpe critico");
            player.VidaActual -= PuntosAtaque * 2;
        }
        else if (tipoAtaque >= 2 && tipoAtaque <= 4) {
            player.VidaActual -= PuntosAtaque * 1;
            Console.WriteLine($"dio un golpe normal");
        }
        else if (tipoAtaque == 1) {
            player.VidaActual -= PuntosAtaque * 0;
            Console.WriteLine($"fallo el golpe");
        }
        Console.WriteLine("-----------------");
    }
    public bool estaVivo() {
        bool estaVivo = Vida > 0 ? true : false;
        return estaVivo;
    }
    public void mostrarEstado() {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"❤  {Vida}  ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"🗡  {PuntosAtaque}  ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"🪙  {OroRecompensa}  \n");
        Console.ResetColor();
        Console.WriteLine("\n=====================================================================");
    }


    private void  ItemRandom(Random random, List<Item> itemsPosibles) {
        Item itemDrop = itemsPosibles[random.Next(0, itemsPosibles.Count())];
        posibleDrop = itemDrop;
    }

}
