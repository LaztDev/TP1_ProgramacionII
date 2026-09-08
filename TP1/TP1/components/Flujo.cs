using System.Runtime.CompilerServices;

namespace TP1.components;

class Flujo {
    // que recibe esta clase? 
    public int PisosTotales; 

    public Flujo (Random random) {
        PisosTotales = random.Next(10, 31); 
    }
    public void FlujoJuego(Random random) {
        // definiciones
        float multiDificultad = 0.15f;
        int[] recorridoSalas = new int[PisosTotales];
        bool juegoTerminado = false;
        //carga con un argumento nunmerico para definir los pisos de la sala
        generarPisos(recorridoSalas, random);

        Inventario inventario = new Inventario();
        Jugador player = new Jugador("Jugador1", 100, 10, 500,recorridoSalas.Length);
        Flujo flujo = new Flujo(random);
        Salas salas = new Salas();
        //lista de items disponibles del juego 
        List<Item> itemsPosibles = new List<Item> {
            new Pocion("Poción de Vida Pequeña","pocion", "vida", 15, 5),
            new Pocion("Poción de Vida Grande","pocion", "vida", 40, 20),
            new Pocion("Poción de Fuerza","pocion", "daño", 20, 30),
            new Pocion("Poción de Fuerza","pocion", "daño", 50, 20),

            new Reliquia("Filo Carmesi", "reliquia","daño", 20, 50),
            new Reliquia("Ojo del Guerrero", "reliquia","daño", 25, 60),
            new Reliquia("Runa del Berserker", "reliquia","daño", 40, 75),
            new Reliquia("Alma del Titan", "reliquia","daño", 30, 100),
            new Reliquia("Anillo Bendecido", "reliquia","vida", 20, 150),
            new Reliquia("sangre de ¿#%?¡#?", "reliquia","vida", 70, 200),
            new Reliquia("Amuleto del alma", "reliquia","vida", 20, 120),
            new Reliquia("Corazon de alma", "reliquia","vida", 15, 100)
        };
        pantallaInicio();
        Console.Clear();

        for (int i = 0; i <= recorridoSalas.Length; i++ ) {

            juegoTerminado = TipoDePiso(player, random, salas, multiDificultad, juegoTerminado, itemsPosibles, recorridoSalas[i]);
            if (juegoTerminado) {
                Console.WriteLine("FELICIDADES LOGRASTE TERMINAR ESTE INFIERNO DE JUEGO :D");
                break;
            }
            else if (juegoTerminado && player.VidaActual <= 0) {
                Console.WriteLine("GAME OVER");
                break;
            }
            player.PisoActual++;
            multiDificultad += 0.07f;
        }
    }

    public bool TipoDePiso(Jugador player, Random random, Salas sala, float multiDificultad, bool juegoTerminado, List<Item> itemsPosibles, int recorridoSalas) {
        int Tipo = recorridoSalas;
        switch (Tipo) {
            case 1 :
                juegoTerminado = sala.Combate(player, random, multiDificultad, PisosTotales, itemsPosibles);
                break;
            case 2 :
                sala.SalaDeCofres(random, player, itemsPosibles);
                break;
            case 3:
                sala.Tienda(player, random, itemsPosibles);
                break;
            case 4:
                sala.Descanso(player);
                break;
            case 5:
                Enemigo jefeFinal = new Enemigo("Jefe Final", 100, 20, multiDificultad, random, itemsPosibles);
                sala.JefeFinal(player, jefeFinal, random, multiDificultad, PisosTotales, itemsPosibles);
                break;
        }
        return juegoTerminado;
    }
    public void pantallaInicio() {
        Console.WriteLine(
            "⣿⣿⣿⣿⣗⢄⠁⠌⠂⢕⡿⣟⠯⢸⢎⢹⣻⡿⣿⣻⡎⣕⣕⢕⢿⣾⠿⣯⣿⢟⠁⢕⢽⡟⣜⢿⣟⣿⣿⣷⣿⣿⢟⣷⣶⣧⣮⣿⡿⣟⣽⣾⣿⣿⣿⣿⠅⣫⢸⣾⣿⣿⣿⣿⣟⣾⣿⡿⢵⢫⣮⣾⡞⣾⢿⢵⠢⡓⢔⠅⣣⣹⣕⣲⣴⡦⡷⣽⠿⣽⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⣷⡯⡢⠐⡄⢆⠝⡰⣙⡌⢏⢺⢹⢋⡾⣛⠽⢩⡱⠃⣻⣮⠟⣝⢣⣷⣿⣿⣪⣾⣿⣿⣝⣙⣏⣿⣻⣺⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢟⢽⣿⢿⡑⣸⣿⣿⣿⣿⣿⣿⣿⣿⡟⡼⠃⣾⣿⡿⣻⢛⡽⡛⡜⢘⢠⣾⣿⣿⣿⡟⡎⡏⢏⢧⢫⣿⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡿⠋⠠⠁⠊⠰⢊⣾⣫⣿⣾⣼⣞⣿⣾⣼⣸⠪⠪⢌⢭⠢⡣⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣿⣿⣿⣿⣷⣿⣿⣿⣿⣿⢿⣿⣟⣎⣾⣬⢿⠿⡷⣭⡓⡝⣬⣐⣔⣿⣿⡿⡛⡃⠂⠱⠡⠪⢮⢻⣿⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡇⠄⠠⢐⢐⠁⢅⠁⠉⣼⡯⣿⣯⣿⣿⣿⡌⡢⡀⡢⡞⣽⡽⣿⣿⣿⢟⣟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣿⣿⣿⣿⣷⣽⡳⣏⡗⢁⣾⣿⣿⢿⣿⣿⣽⣿⣯⠄⠄⣐⢬⢸⠕⡮⣾⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡇⠄⠌⡄⡃⢌⠢⡁⡨⡯⡙⣼⣾⢿⣿⣿⡅⡪⠢⡹⡿⣟⣼⣽⣾⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢇⣟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⡿⣿⣿⣜⣾⣮⢂⣿⣿⢿⣯⢿⢿⣿⢿⠿⢡⢐⠭⡬⢇⠣⡑⣯⢾⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⣯⠠⠁⠰⠈⠼⣾⢿⢯⢱⡆⢝⡿⣿⡿⣻⡵⣱⣑⢵⢿⣾⢿⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⣼⢿⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣯⣿⣷⡟⡷⢱⣽⣾⡞⣷⢿⣭⠢⡣⢢⢋⣩⣭⣣⣣⣦⣥⡶⣿⠏⣾⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⣷⣟⠴⣶⣴⣅⡙⣌⢼⠠⢏⢗⢿⢫⣾⢟⡽⣻⣿⣷⡿⣿⣿⣻⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⢸⠟⢺⡯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠫⡷⠡⣿⣿⡟⡯⡫⡗⢟⠌⠆⢡⣾⣿⣿⣿⠟⡝⡮⣺⡙⣼⢿⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⣿⢳⣙⠚⢟⡿⣷⣷⣮⡏⣂⣀⡌⣝⡂⣎⢌⢪⢛⢿⣿⣿⢷⡿⣞⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⣻⡨⣸⢇⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣿⣿⣮⣺⣮⣿⣟⣷⢏⣭⣭⣶⣠⣲⣿⣿⣿⢟⢁⢃⢱⢱⡿⢰⢏⣻⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⣟⣼⠲⠌⡑⢪⢻⣹⡝⡿⡾⣾⣿⣷⣧⣭⣵⣴⣌⣢⡿⣯⣯⣻⣯⣿⣿⣿⣿⣿⣿⣻⣿⣿⣿⣿⣿⣿⣿⣿⡜⣧⣾⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢯⣿⣿⣿⣿⣫⢯⢺⡓⣅⢯⣫⣷⣿⣛⣭⣵⣬⡲⡳⣘⣎⢵⡹⢊⢴⡿⡰⣿⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⣟⣿⣢⢕⡈⠄⡡⣨⣁⢳⡡⡡⠪⣼⢿⣿⣫⣛⢟⡟⢌⢷⣿⣿⣯⣿⣿⣯⣯⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⡆⣟⡯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣽⢿⣯⡟⣿⢫⡿⢜⡬⣞⢷⣿⣿⡿⡟⣿⣿⣿⣯⣿⣵⣥⣦⣷⡍⢺⢯⡳⢛⢼⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⣿⡯⣟⣿⣿⣷⣾⣯⣮⣷⣿⣾⣿⣷⢷⣾⣷⣷⣯⣊⡧⣣⡝⡞⡽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢣⢊⡇⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣛⣽⡿⣋⠍⣒⡫⣕⣷⣻⣷⣿⣾⣿⢛⣿⣻⡇⠻⣿⢳⢺⣿⣿⣿⢿⣻⢡⡯⢏⠄⠸⢸⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡟⣻⡿⣿⣿⢨⣫⣻⣺⣻⣻⣫⣫⣾⣿⣿⣿⣿⣻⣻⣯⣿⣮⣯⣯⣯⣿⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢰⣵⡷⣿⣿⣿⣿⣿⣿⣿⣿⣷⣾⣿⣟⣿⣶⣯⣷⣮⣾⣿⣿⣿⣿⠿⢽⡨⡷⣿⡆⢄⢨⣌⠘⡙⣭⣷⣛⣡⣿⡷⡣⡎⡀⢼⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡗⡌⣿⣝⢿⢎⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⣿⠇⠆⣿⡇⣻⣿⣿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⣪⣹⢗⣷⣿⣿⣧⣊⢻⣨⠂⢄⢑⣿⢿⠿⢡⡻⣡⠄⢮⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡇⠉⢚⠿⡈⠼⣾⢿⡻⢫⢩⣾⣿⣿⣿⣿⡿⣿⡿⣻⢽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⢪⢹⣿⣳⢼⣿⣿⣕⢝⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢵⣲⠟⢿⣿⢿⣿⠘⡽⣎⡷⣎⣎⢰⣾⣼⡏⠄⢸⡣⠃⠈⠨⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡇⠕⢰⣰⡗⣮⡖⣽⣺⣕⡤⡹⡿⡿⢟⡯⣏⢯⠮⡽⣨⣿⡯⣿⣿⣿⣯⠟⢉⣽⣿⠿⢿⢛⢟⢭⣧⣷⠣⣻⢽⡟⢚⠽⣿⣿⣿⣷⣯⣯⣯⣭⣿⣿⣻⡗⠈⡩⢛⠻⠿⣽⣿⣿⣯⣞⢟⣵⣿⠣⡢⣿⣼⣮⣶⢃⣿⣳⡉⠑⢓⠲⣪⠂⡎⢺⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡇⠈⠠⣳⢙⠼⣷⢹⢋⢍⠕⣕⣯⣿⣿⣿⣞⢧⣿⣿⣟⢿⠏⠻⢛⢉⡐⡨⣴⣿⣿⣿⣿⣾⣽⣝⢛⣏⡾⣗⣿⡇⣳⠄⣋⢿⣿⣿⣿⡿⣿⣛⡭⣿⣋⠌⠰⡰⡠⣵⣿⢿⣾⢗⢿⠹⣻⣿⣿⣳⣺⣻⡿⣟⡵⣽⡧⣱⡡⢖⡎⠸⡄⠐⡌⢸⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⣷⢤⡀⠘⢜⡲⣿⣷⣵⡓⢝⢐⢽⣷⢿⡾⣽⡿⣿⣳⢱⠝⢄⣽⡶⡱⢎⢖⠇⣿⣿⣿⣿⣿⠿⡽⢸⣾⢡⢮⢷⡣⣽⣾⣽⣷⣋⢭⣖⣾⣾⣿⢿⡿⣾⠇⡕⣜⣼⣿⣇⢮⣼⢏⠃⢽⣻⣿⣿⣿⣾⢞⣩⢮⠿⢛⠩⣁⡆⢁⡇⠅⠛⡠⠂⡰⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡗⢿⣺⣦⣈⠉⠳⢉⠙⠿⡇⢢⢺⢽⣻⣝⣧⡿⣯⣶⣻⣾⣬⡗⣲⣿⣮⣻⣧⢻⣿⠿⠛⢃⡸⢭⣿⣗⡧⣽⣹⣧⢷⣿⣿⣽⣱⣳⡹⠨⢿⣿⣿⣿⣿⣞⣮⣾⣿⣷⣿⣿⢓⣬⣰⣿⢛⢟⣼⣳⣵⡋⠁⢀⠠⠄⠁⢕⠇⣘⡜⢸⠄⢀⡜⢸⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡇⠄⠡⠿⡿⠆⡀⡈⢔⠄⠈⠄⣉⣾⡾⢝⣑⠿⣻⣞⣿⠿⠫⣾⣮⣿⢹⣿⣾⣗⡯⡰⡪⡲⣕⣿⣿⣾⣟⣿⣞⣯⣟⢿⡿⣿⣿⣜⣟⢜⢵⢫⢝⠻⢾⡿⢿⣿⣿⡿⣻⣼⣾⣿⣿⡟⡾⢻⣐⡽⠹⡚⠷⠒⣒⣦⡑⡼⡐⠏⡨⢊⢰⡕⠁⡜⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⣇⠄⠄⠄⢰⣻⡿⠄⣤⣶⢷⡛⠩⢱⢌⣻⢻⣎⠃⡯⠢⣺⡮⣳⣿⡿⣝⣭⡿⡛⣜⢁⢦⡿⣽⣯⣿⣿⣵⣿⣟⣯⣾⡅⠖⠘⣫⣿⣮⣓⢼⣿⣽⢿⣶⣦⡁⢝⠻⣿⣿⣿⣿⣿⠏⣷⢡⡞⣰⡇⠔⢀⢄⠉⠙⠚⠿⢿⢷⣷⢪⡄⠃⠄⠄⢞⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡇⢀⢄⠐⠈⠺⣿⡳⣶⡙⠿⣿⣶⣷⡾⢼⣾⣛⡻⣾⠿⠮⣉⣩⡴⠜⢉⠡⡨⡬⡪⡳⣽⣿⣿⣿⣿⢻⣷⣽⣷⣿⠽⠄⢀⠄⢿⣿⣿⢿⡶⣔⣹⠻⠛⡿⢿⣲⣫⢷⣯⣝⣝⡿⢏⢶⠙⢁⡜⣄⡄⠜⠌⠄⣀⡰⣶⣿⠟⡡⢞⡔⠄⠄⠄⢜⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡗⡕⠈⠆⢀⠄⠜⣿⣾⣷⡀⠉⠉⣾⠪⣿⣿⣿⢺⣦⣭⣭⣓⢆⣔⣬⣶⡫⢟⢱⣱⣿⣯⣿⣯⣿⣿⢹⣿⡿⠿⠛⠃⠐⠄⢀⢈⠛⠿⢥⣅⡛⠧⣭⣃⢪⣡⢝⣝⣷⢗⡟⢿⢹⣹⣥⣮⢍⠰⡫⢂⣪⣀⣙⣙⡻⣙⡏⣽⠅⢋⠄⢀⠐⠄⢑⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡇⠄⡂⡀⢙⠛⠶⡦⣌⢿⣖⡄⠄⠄⢰⡻⡷⢋⢸⡟⢟⣿⣿⣿⣿⣿⣺⣴⣷⢯⠯⢾⢵⣿⣻⣽⣿⢟⣃⣾⣿⣿⣗⠠⠂⠄⣼⣿⣿⣄⡩⠧⣂⡙⡙⡽⣽⡷⢷⢦⣯⣛⢮⢝⡽⣛⣽⣶⢱⣍⡟⠟⣸⢾⣿⣿⠻⢱⡟⠁⡒⠄⣣⡵⠲⢲⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡇⠈⠄⡗⢸⣿⠇⣴⡍⠈⠛⣷⠤⠄⠙⣧⡫⠂⠐⠠⢬⢿⠛⢽⡿⢿⡳⣓⡓⢡⢦⡔⡅⡑⡉⣍⣴⣽⣿⣿⣿⣿⣟⠄⣰⠄⢿⣿⣿⣿⣷⣖⣥⣤⠭⠍⣂⢪⢷⠷⣶⣶⣿⣿⡃⢻⠿⡿⢸⢾⡷⠐⢴⡟⣛⣁⣌⢎⠐⠁⠡⠐⣁⡀⠈⠐⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡇⠄⠄⠄⠄⠃⠴⢉⣴⣦⠠⠈⠃⣄⠫⢇⠃⠆⠄⢔⡈⠑⡁⣂⣬⠦⣩⢲⣚⠯⣇⣷⣮⢶⠿⡭⣿⣿⣿⣿⣿⣿⡧⠄⠿⠄⢹⢿⣿⣿⣟⣟⣟⣿⣿⣷⢦⣷⣌⠡⡳⡻⢿⣷⣷⣦⣄⠁⠛⡿⢝⣰⠇⠋⠃⢜⠋⠉⢀⢤⠔⢉⠐⠄⠐⠠⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡇⠄⠄⠄⠆⠄⠄⠑⢿⣿⡾⠖⠂⠈⡨⠵⢷⣶⠄⠘⠄⠁⢙⠢⡃⠿⠿⣸⣇⣿⣽⣽⣚⣟⣿⣿⢿⢿⢿⣿⣿⣿⠫⠠⢔⢎⡰⡐⣻⣻⣿⣿⣿⣿⣻⣛⢿⣾⣿⣷⣾⣿⠿⣋⠜⡛⢄⠄⠄⢕⡫⠤⠣⢀⡨⠖⢉⣠⠖⠁⠌⠄⡀⠄⠄⡨⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡇⠄⠄⠄⢐⠑⣀⡀⡀⠄⣠⣠⡄⡀⢀⠒⠄⣘⡙⣶⣤⣅⣤⣄⡉⣅⢬⣺⣳⣿⣯⣿⣿⣿⣾⠾⡿⣿⣿⣽⣭⣦⣭⣬⣖⡰⠐⡍⢝⠽⡻⣿⣿⣿⣵⣽⣿⡿⣫⢝⢮⡴⠚⣃⠡⠠⣀⣄⣴⣍⡄⠂⠃⠄⣀⡤⠉⠁⠄⣀⠄⠂⢀⠄⠁⢄⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡇⠄⠄⠄⡀⠊⠓⠅⢠⠄⠙⢙⠸⣮⢳⢟⢧⢓⣶⣶⢯⠍⡘⠨⢿⣷⡛⣽⣻⢿⡻⡯⣫⣬⣾⣿⣿⣿⣿⣿⣯⣿⣽⣿⣿⣯⡮⣮⣷⣵⣿⣿⢻⣯⠿⢟⢝⡽⠘⢁⡡⣐⡡⠶⡿⡃⣵⠿⠋⠁⠔⢉⢐⠉⠑⣨⠴⠂⡠⠑⠨⠐⠁⠄⠄⢐⣿⣿⣿⣿\r\n" +
            "⣿⣿⣿⣿⡇⠄⠄⠄⢈⢄⠄⠄⠑⠒⠈⠄⠄⠄⠊⣈⠓⠊⡧⣂⠄⠉⠄⠘⠲⢛⠿⣮⣲⡻⡽⣧⢟⢿⣿⣷⣿⡹⠿⣽⣽⣻⣹⣲⢯⠧⡯⠻⠺⠩⡉⣀⣠⣤⣾⣾⣟⣁⡦⢗⢮⣫⢵⠺⠈⠠⠁⠃⣀⠵⠊⡡⠡⠐⠊⠠⠔⠋⠁⠄⠁⠄⠄⠄⠄⠂⣿⣿⣿⣿\r\n");
        Console.WriteLine("" +
            "▄█████ ▄▄     ▄▄▄  ▄▄ ▄▄   ▄▄▄▄▄▄ ▄▄ ▄▄ ▄▄▄▄▄   ▄█████ ▄▄▄▄  ▄▄ ▄▄▄▄  ▄▄▄▄▄\r\n" +
            "▀▀▀▄▄▄ ██    ██▀██ ▀███▀     ██   ██▄██ ██▄▄    ▀▀▀▄▄▄ ██▄█▀ ██ ██▄█▄ ██▄▄\r\n" +
            "█████▀ ██▄▄▄ ██▀██   █       ██   ██ ██ ██▄▄▄   █████▀ ██    ██ ██ ██ ██▄▄▄");
        Console.Write("\npresione cualquier tecla para continuar: ");
        Console.ReadKey();   
    }
    //metodo que genera los pisos y se encarga de no repetir muchas salas de bonus
    public void generarPisos(int[] recorridoSalas, Random random) {
        int tipoSala = 0, rompeSuerte = 0;

        for (int i = 0; i < recorridoSalas.Length; i++) {
            if (i == recorridoSalas.Length - 1) {   // establece la ubicacion de la sala del jefe
                recorridoSalas[i] = 5;
            }
            else if (i == 0 ) {                 // definimos quee debe comenzar con un cofre o con un combate 
                tipoSala = random.Next(1, 3);
                recorridoSalas[i] = tipoSala;
            }
            else {                              // define el comportamiento para el resto de salas evitando salas repetidas 
                tipoSala = random.Next(1, 5);
                if (recorridoSalas[i - 1] == 1 && tipoSala == 1) {
                    recorridoSalas[i] = tipoSala;
                }
                else { 
                    while (recorridoSalas[i - 1] == tipoSala) {
                        tipoSala = random.Next(1, 5);
                    }
                    recorridoSalas[i] = tipoSala;
                }
            }
        }
        for (int i = 0; i < recorridoSalas.Length; i++ ) {
            if (recorridoSalas[i] > 1 || recorridoSalas[i] < 5) {
                rompeSuerte++;
                if (rompeSuerte > 2) {
                    recorridoSalas[i] = 1;
                    rompeSuerte = 0;
                }
            }
        }
    }
}


