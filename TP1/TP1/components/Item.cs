
namespace TP1.components;

public abstract class Item {

    public string Nombre { get; protected set; }    //nombre del item 
    public string Tipo { get; protected set; }  //tipo de item (pocion o reliquia)
    public string SubTipo { get; protected set; }
    public int Efecto { get; protected set; }   //un numero que modifica algo 
    public int Precio { get; protected set; }   //precio del item en oro

    public Item() {
        Nombre = string.Empty;
        Tipo = string.Empty;
        SubTipo = string.Empty;
    }

    public abstract void usar(Jugador player);
    //aqui realizamos un metodo que se encargue de modificar params de jugador 
    //tambien modifica el inventario dejando un param vacio
    public abstract void mostrarDetalle();
}

public class Pocion : Item {
    public Pocion(string nombre, string tipo, string subTipo, int efecto, int precio) {
        Nombre = nombre;
        Efecto = efecto;
        Precio = precio;
        Tipo = tipo;
        SubTipo = subTipo;
    }
    public override void usar(Jugador player) {
        int diferenciaDeVida = player.VidaMaxima - player.VidaActual;
        if (SubTipo== "vida") {
            player.VidaActual += (player.VidaActual + Efecto >= player.VidaMaxima? diferenciaDeVida : Efecto);
        }
        else if (SubTipo == "daño") {
            player.AtaqueTemporal += Efecto;
        }
    }
    public override void mostrarDetalle() {
        if (SubTipo == "vida") {
            Console.WriteLine($"Nombre: {Nombre}\n Tipo: {Tipo}\n Efecto: +{Efecto} hp\n Precio: {Precio}g");
        }
        else if (SubTipo == "daño") {
            Console.WriteLine($"Nombre: {Nombre}\n Tipo: {Tipo}\n Efecto: +{Efecto} atq\n Precio: {Precio}g");
        }   
    }
}
public class Reliquia : Item {
    public Reliquia(string nombre, string tipo, string subTipo, int efecto, int precio) {
        Nombre = nombre;
        Efecto = efecto;
        Precio = precio;
        Tipo = tipo;
        SubTipo = subTipo;
    }
    public override void usar(Jugador player) {
        if (SubTipo == "vida") {
            if (player.VidaActual == player.VidaMaxima) {
                player.VidaMaxima += Efecto;
                player.VidaActual += Efecto;
            }
            else {
                player.VidaMaxima += Efecto;
            }
        }
        else if (SubTipo == "daño") {
            player.AtaqueBase += Efecto;
        }
    }
    public override void mostrarDetalle() {
        if (SubTipo == "vida") {
            Console.WriteLine($"Nombre: {Nombre}\n Tipo: {Tipo}\n Efecto: +{Efecto} hp\n Precio: {Precio}g");
        }
        else if (SubTipo == "daño") {
            Console.WriteLine($"Nombre: {Nombre}\n Tipo: {Tipo}\n Efecto: +{Efecto} atq\n Precio: {Precio}g");
        }
    }
}
