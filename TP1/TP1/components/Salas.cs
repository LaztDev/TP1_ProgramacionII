using System.ComponentModel;
namespace TP1.components;

class Salas {
    public bool Combate(Jugador player, Random random, float multiDificultad, int PisosTotales) {
        Enemigo monstruo = new Enemigo("Monstruo", 10, 20, multiDificultad);
        Console.Clear();
        Console.ForegroundColor= ConsoleColor.Red;
        Console.WriteLine("-------------------------------COMBATE-------------------------------");
        Console.ResetColor();
        player.mostrarEstado();
        monstruo.mostrarEstado();
        bool finJuego = false;
        do {
            //turno del jugador
            accionJugador(player, monstruo, random, PisosTotales);
            //turno del monstruo
            if (monstruo.estaVivo()) {
                monstruo.atacar(player);
            }
            else {
                Console.WriteLine("El monstruo ha sido derrotado.");
                Console.WriteLine($"Obtuviste: {monstruo.OroRecompensa}g");
                player.Oro += monstruo.OroRecompensa;
            }
        } while (player.VidaActual > 0 && monstruo.estaVivo());
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("--------------------------------------------------------------------");
        Console.ResetColor();
        Console.ReadKey();
        // variable bandera para definir si es game over o no 
        return finJuego = player.VidaActual <= 0 ? true : false;
    }
    public void Tienda(Jugador player) {
        string tipoCompra = string.Empty;
        List<Item> itemsEnVenta = new List<Item> {
            new Pocion("Poción de Vida","pocion", "vida", 10, 20),
            new Pocion("Poción de Ataque","pocion", "daño", 5, 30),
            new Reliquia("Reliquia de Fuerza", "reliquia","daño", 5, 200)
        };
        // muestra los items en venta y sus precios
        //bucle que no sale hasta que el jugador decida salir de la tienda
        while (true) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-------------------------------TIENDA-------------------------------");
            Console.ResetColor();
            player.mostrarEstado();

            for (int i = 0; i < itemsEnVenta.Count; i++) {
                Console.WriteLine($"{i + 1}. {itemsEnVenta[i].Nombre}, Precio: {itemsEnVenta[i].Precio}");
            }
            Console.WriteLine($"-------------------------------------------------------------------");
            Console.WriteLine("Seleccione una accion para realizar");
            if (itemsEnVenta.Count == 0) {
                Console.WriteLine("La tienda está vacía.");
                break;
            }
            for (int i = 0; i <= itemsEnVenta.Count - 1; i++) {
                Console.Write($"[{i + 1}] Comprar {itemsEnVenta[i].Nombre}  ");
                if (i==itemsEnVenta.Count - 1) {
                    Console.WriteLine($"[{i + 2}] Salir de la tienda");
                }
            }
            int opcion = validarSeleccion(itemsEnVenta.Count() + 1);
            //Validamos salida de la tienda
            if (opcion == itemsEnVenta.Count + 1) {
                Console.WriteLine("Saliendo de la tienda...");
                break;
            }
            //validamos que item esta comprando
            tipoCompra = itemsEnVenta[opcion -1].Tipo == "pocion" ? "poción" : "reliquia";
            if (itemsEnVenta[opcion - 1].Precio <= player.Oro) {    
                if (tipoCompra == "poción") {
                    if (player.inventario.pociones.Count < 3) {
                        player.inventario.agregarPocion((Pocion)itemsEnVenta[opcion - 1]);
                        player.Oro -= itemsEnVenta[opcion - 1].Precio;
                        itemsEnVenta.RemoveAt(opcion - 1);
                    }
                    else {
                        Console.WriteLine("No puedes comprar más pociones, tu inventario está lleno.");
                    }
                }
                else if (tipoCompra == "reliquia") {
                    player.equiparReliquia((Reliquia)itemsEnVenta[opcion - 1]);
                    player.Oro -= itemsEnVenta[opcion - 1].Precio;
                    itemsEnVenta.RemoveAt(opcion - 1);
                }
            }
            else {
                Console.WriteLine("No tienes suficiente oro para comprar este item.");
            }
        }
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("--------------------------------------------------------------------");
        Console.ResetColor();

    }
    public void Descanso(Jugador player) {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("------------------------------Descanso------------------------------");
        Console.ResetColor();
        player.mostrarEstado();
        while (true) {
            Console.WriteLine("Seleccione una accion para realizar");
            Console.WriteLine("[1]Descansar y seguir  [2]Seguir adelante");
            int opcion = validarSeleccion(2);
            if (opcion == 1) {
                int VidaRecuperada = player.VidaActual <= (player.VidaMaxima / 3) * 2 ? player.VidaMaxima / 3 : player.VidaMaxima - player.VidaActual;
                player.VidaActual += VidaRecuperada;
                Console.WriteLine("has descansado tu vida se a recuperado");
                break;
            }
            else if (opcion == 2) {
                Console.WriteLine("Sigues adelante");
                break;
            }
        }
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("--------------------------------------------------------------------");
        Console.ResetColor();
        Console.ReadKey();
    }
    public void JefeFinal(Jugador player, Enemigo monstruo, Random random, float multiDificultad, int PisosTotales) {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("------------------------------Jefe Final------------------------------");
        Console.ResetColor();
        Combate(player, random,multiDificultad, PisosTotales);
    }
    public void SalaDeCofres(Random random, Jugador player) {
        Console.Clear();
        List<Reliquia> reliquias = new List<Reliquia>() {
             new Reliquia("Reliquia de Fuerza", "reliquia","daño", 15, 200),
             new Reliquia("Reliquia de Vida", "reliquia","vida", 20, 200),
             new Reliquia("Reliquia de Fuerza", "reliquia","daño", 30, 200)
        };
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("----------------------------SALA DE COFRES----------------------------");
        Console.ResetColor();
        int reliquiaAleatoria = random.Next(0, 3);
        Console.Write("se te a otorgado:");
        reliquias[reliquiaAleatoria].mostrarDetalle();
        player.equiparReliquia(reliquias[reliquiaAleatoria]);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ResetColor();
        Console.ReadKey();
    }
    public int  dados(Random random) {
        return random.Next(1, 7);
    }
    public void accionJugador(Jugador player, Enemigo monstruo, Random random, int PisosTotales) {
        Console.WriteLine("Elige una acción:");
        Console.WriteLine("[1] Atacar [2] Usar poción [3] Huir");
        int accion = validarSeleccion(3);
        switch (accion) {
            case 1:
                // implementar logica de golpes criticos
                int TipoAtaque = dados(random);
                if (TipoAtaque >= 5 && TipoAtaque <= 6) {
                    Console.WriteLine("Golpe crítico!");
                    player.atacar(monstruo, 2);
                }
                else if (TipoAtaque == 1) {
                    player.atacar(monstruo, 0);
                    Console.WriteLine("Fallaste el ataque!");
                }
                else {
                    player.atacar(monstruo, 1);
                    Console.WriteLine("Atacaste al enemigo!");
                }
                break;
            case 2:
                Console.WriteLine("Lista de pociones");
                player.inventario.listarPociones();
                int opcion = validarSeleccion(3);
                player.inventario.usarPocion(opcion, player);
                break;
            case 3:
                if (player.PisoActual == PisosTotales) {
                    Console.WriteLine("No puedes huir del Jefe, Perdiste un turno por cobarde");
                }
                else {
                    if (random.NextDouble() < 0.5) {
                        Console.WriteLine("Lograste huir de la batalla!");
                        monstruo.Vida = 0;
                    }
                    else {
                        Console.WriteLine("No lograste huir, perdiste un turno");
                    }
                }
                break;
            default:
                Console.WriteLine("Acción inválida, perdiste un turno");
                break;
        }
        Console.ReadKey();
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
