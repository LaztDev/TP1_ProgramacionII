namespace TP1.components;

public class Enemigo {
    public string Nombre { get; protected set; }
    public int Vida { get; set; }
    public int PuntosAtaque { get; protected set; }
    public int OroRecompensa { get; protected set; }
    // public Item posibleDrop = ItemRandom();

    public Enemigo(string nombre) {
        Nombre = nombre;
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
