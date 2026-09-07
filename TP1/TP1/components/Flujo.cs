namespace TP1.components;

class Flujo {
    // que recibe esta clase? 
    public int PisosTotales; 

    public Flujo (Random random) {
        PisosTotales = random.Next(10, 31); 
    }
    public void FlujoJuego(Random random) {
        Inventario inventario = new Inventario();
        Jugador player = new Jugador("Jugador1", 100, 10, 500);
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
        float multiDificultad = 0.15f;
        bool juegoTerminado = false;

        pantallaInicio();
        Console.Clear();

        while (player.PisoActual < PisosTotales && !juegoTerminado) {
            multiDificultad += 0.15f;
            juegoTerminado = TipoDePiso(player, random, salas, multiDificultad, juegoTerminado, itemsPosibles);
            player.PisoActual++;
            if (juegoTerminado) {
                // agregar metodo de Fin del juego 
                Console.WriteLine("El juego ha terminado. ¡Gracias por jugar!");
            }
        }
        if (player.PisoActual == PisosTotales && !juegoTerminado) {
            Enemigo jefeFinal = new Enemigo("Jefe Final", 100, 20, multiDificultad, random, itemsPosibles);
            salas.JefeFinal(player, jefeFinal, random,multiDificultad, PisosTotales, itemsPosibles);
        }
    }

    public bool TipoDePiso(Jugador player, Random random, Salas sala, float multiDificultad, bool juegoTerminado, List<Item> itemsPosibles) {
        int Tipo = random.Next(1, 5);
        switch (Tipo) {
            case 1 :
                juegoTerminado = sala.Combate(player, random, multiDificultad, PisosTotales, itemsPosibles);
                break;
            case 2 :
                sala.Tienda(player, random, itemsPosibles);
                break;
            case 3:
                sala.Descanso(player);
                break;
            case 4:
                sala.SalaDeCofres(random, player, itemsPosibles);
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

}


