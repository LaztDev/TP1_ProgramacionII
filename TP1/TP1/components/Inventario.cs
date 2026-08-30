namespace TP1.components;

public class Inventario {
    public List<Pocion> pociones = new List<Pocion>(); //lista que guardara objetos del tipo pocion
    private int capacidadMaxima = 3;

    public void agregarPocion(Pocion pocionInv) {
        if (pociones.Count() < capacidadMaxima && pociones.Count() >= 0) {
            pociones.Add(pocionInv);
        }
        else {
            Console.WriteLine("Inventario lleno");
        }
    }
    public void usarPocion(int pocionSelec, Jugador player) {
        int pocionesDisp = pociones.Count();
        if (pocionSelec > pocionesDisp - 1 && pocionSelec < 0) {
            Console.WriteLine("Vacio...");
        }
        else {
            pociones[pocionSelec - 1].usar(player);
            pociones.RemoveAt(pocionSelec - 1);
        }

    }
    public void listarPociones() {
        foreach (Pocion pocion in pociones) {
            pocion.mostrarDetalle();
        }
    }
}




