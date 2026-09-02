using System.ComponentModel;

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
    public void Tienda(Jugador player) {
        List<Item> itemsEnVenta = new List<Item> {
            new Pocion("Poción de Vida","pocion", "vida", 10, 20),
            new Pocion("Poción de Ataque","pocion", "ataque", 5, 30),
            new Reliquia("Reliquia de Fuerza", "reliquia","daño", 5, 200)
        };
        for (int i = 0; i < itemsEnVenta.Count; i++) {
            Console.WriteLine($"{i + 1}. {itemsEnVenta[i].Nombre}");
        }
        Console.WriteLine("Seleccione una accion para realizar");
        Console.WriteLine("[1]Comprar   [2]Comprar   [3]Salir sin comprar");
        int opcion = validarSeleccion(4);
        while (true) { 
            if (opcion == 1 || opcion == 2) {
                for (int i = 0; i < itemsEnVenta.Count; i++) {
                    if (opcion == i) {
                        if (player.Oro > itemsEnVenta[i].Precio) { 
                            if (player.inventario.pociones.Count < 3) {
                                player.Oro -= itemsEnVenta[i].Precio;
                                player.inventario.agregarPocion((Pocion)itemsEnVenta[i]);
                                itemsEnVenta.RemoveAt(i);
                            }
                            else {
                                Console.WriteLine("No puedes comprar más pociones, tu inventario está lleno.");
                            }
                        }
                        else {
                            Console.WriteLine("No tienes suficiente oro para comprar este item.");
                        }
                    }
                }
            }
            else {
                Console.WriteLine("Saliendo de la tienda...");
                break;
            }
        }
    }
    public void Descanso(Jugador player) {
        while (true) { 
            Console.WriteLine("Seleccione una accion para realizar");
            Console.WriteLine("[1]Descansar y seguir  [2]Seguir adelante");
            int opcion = validarSeleccion(2);
            if (opcion == 1) {
                player.VidaActual += player.VidaActual <= (player.VidaMaxima / 3) * 2 ? player.VidaMaxima / 3 : player.VidaMaxima;
                Console.WriteLine("has descansado tu vida se a recuperado");
                break;
            }
            else if (opcion == 2) { 
                Console.WriteLine("Sigues adelante"); 
                break;
            }
            
        }
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
        Console.WriteLine("[1] Atacar [2] Usar poción [3] Huir");
        int accion = validarSeleccion(3);
        switch (accion) {
            case 1:
                // implementar logica de golpes criticos
                int TipoAtaque = dados(random);
                player.atacar(monstruo);
                break;
            case 2:
                Console.WriteLine("Lista de pociones");
                player.inventario.listarPociones();
                int opcion = validarSeleccion(3);
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
    public int validarSeleccion(int maxOpcion) {
        int opcion;
        while (true) {
            if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= maxOpcion) {
                return opcion;
            }
            else { 
                Console.WriteLine("Selección inválida, intenta de nuevo."); 
            }
        }
    }

}
