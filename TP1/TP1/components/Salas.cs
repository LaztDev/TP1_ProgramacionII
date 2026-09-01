namespace TP1.components;

class Salas {

    
    public void Combate(Jugador player, Enemigo monstruo, Random random) {
        do {
            //turno del jugador
            accionJugador(player, monstruo, random);
            //turno del monstruo
            monstruo.atacar(player);
        } while (player.VidaActual > 0 && monstruo.estaVivo());
    }
    public void Tienda() {

    }
    public void Descanso() {

    }
    public void JefeFinal() {

    } 
    public void SalaDeCofres() {

    }
    public int  dados(Random random) {
        return random.Next(1, 7);
    }
    public void accionJugador(Jugador player, Enemigo monstruo, Random random) {
        Console.WriteLine("Elige una acción:");
        Console.WriteLine("1. Atacar");
        Console.WriteLine("2. Usar poción");
        Console.WriteLine("3. Huir");
        int accion = validarSeleccion();
        switch (accion) {
            case 1:
                // implementar logica de golpes criticos
                int TipoAtaque = dados(random);
                player.atacar(monstruo);
                break;
            case 2:
                Console.WriteLine("Lista de pociones");
                player.inventario.listarPociones();
                int opcion = validarSeleccion();
                player.inventario.usarPocion(opcion, player);
                break;
            case 3:
                if (random.NextDouble() < 0.5) {
                    Console.WriteLine("Lograste huir de la batalla!");
                    monstruo.Vida = 0;
                }
                else {
                    Console.WriteLine("No lograste huir, perdiste un turno");
                }
                break;
            default:
                Console.WriteLine("Acción inválida, perdiste un turno");
                break;
        }
    }
    public int validarSeleccion() {
        int opcion;
        while (true) {
            if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= 3) {
                return opcion;
            }
            else { 
                Console.WriteLine("Selección inválida, intenta de nuevo."); 
            }
        }
    }

}
