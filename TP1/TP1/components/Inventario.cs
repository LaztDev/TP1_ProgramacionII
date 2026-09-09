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
        if (pocionSelec > pocionesDisp || pocionSelec <= 0) {
            Console.WriteLine("Vacio...");
        }
        else {
            pociones[pocionSelec - 1].usar(player);
            pociones.RemoveAt(pocionSelec - 1);
            Console.Write("Usaste:  ");
            pociones[pocionSelec - 1].mostrarDetalle();
        }
    }
    public void listarPociones() {
        int PocionesDisp = pociones.Count() > 0 ? pociones.Count() : 0;
        if (PocionesDisp == 0) {
            for (int i = 0; i <= capacidadMaxima - 1; i++) { Console.WriteLine($"{i + 1}. Vacío"); }
        }
        else {
            for (int i = 0; i < PocionesDisp; i++) {
                Console.WriteLine($"{i + 1}. {pociones[i].Nombre}");
            }
            for (int i = PocionesDisp; i < capacidadMaxima; i++) { Console.WriteLine($"{i + 1}. Vacío"); }
        }
    }
}




