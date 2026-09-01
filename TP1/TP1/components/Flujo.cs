namespace TP1.components;

class Flujo {
    // que recibe esta clase? 
    public int PisosTotales; 

    public Flujo (Random random) {
        PisosTotales = random.Next(10, 31); 
    }

    public void TipoDePiso(Random random) {
        int Tipo = random.Next(1, 6);
        switch (Tipo) {
            case 1 :
                // logica que defina el tipo de sala
                break;
            case 2 :
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }


    }




}


