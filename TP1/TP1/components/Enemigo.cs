namespace TP1.components;

public class Enemigo {
    public string Nombre { get; protected set; }
    public int Vida { get; set; }
    public int PuntosAtaque { get; protected set; }
    public int OroRecompensa { get; protected set; }
    // public Item posibleDrop = ItemRandom();

    public Enemigo(string nombre, int vida, int puntosAtaque, float multiDificultad) {
        Nombre = nombre;
        Vida = Convert.ToInt32(vida * multiDificultad);
        PuntosAtaque = Convert.ToInt32(puntosAtaque * multiDificultad);
        OroRecompensa = Convert.ToInt32(20 * multiDificultad);
    }
    public void atacar(Jugador player) {
        player.VidaActual -= PuntosAtaque;  
    }
    public bool estaVivo() {
        bool estaVivo = Vida > 0 ? true : false;
        return estaVivo;
    }
   // public void ItemRandom(Random random) {
   //    double ItemProb = random.NextDouble();       
   // }

}
