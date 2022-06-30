//inicio de el tp9 ,manejo de archivos json
// See https://aka.ms/new-console-template for more information
using System;
using System.IO; // uso la libreria para el manejo de archivos
using System.Text.Json;
using System.Text.Json.Serialization;
//inicio de la creacion de los productos
Random aux= new Random();
int ano, dia, mes;
List<Productos> elementos= new List<Productos>();
string archivo="productos.json";
if (!File.Exists(archivo))
{
    File.Create(archivo);
}
for (int i = 0; i < 2; i++)
{
    //elementos[i]=new Productos();
    System.Console.WriteLine("Nombre de el producto");
    string Nombres=Console.ReadLine();
    System.Console.WriteLine("Año de creacion: ");
    ano=Int32.Parse(Console.ReadLine());
    System.Console.WriteLine("mes de creacion: ");
    mes=Int32.Parse(Console.ReadLine());
    System.Console.WriteLine("dia de creacion: ");
    dia=Int32.Parse(Console.ReadLine());
    DateTime auxDos= new DateTime(ano, mes,dia);
    // elementos[i].FechaVencimiento=auxDos;
    System.Console.WriteLine("Tamaño del producto");
    string Tamanios=Console.ReadLine();
    // elementos[i].aleatorios();
    elementos.Insert(i,new Productos{Nombre=Nombres,FechaVencimiento=auxDos, Tamanio=Tamanios});
    elementos[i].aleatorios();
    string texto= JsonSerializer.Serialize(elementos[i]);
}
string textos= JsonSerializer.Serialize(elementos);
//añado los datos a el archivo .json
File.WriteAllText(archivo,textos);
var listao= JsonSerializer.Deserialize<List<Productos>>(textos);
for (int e = 0; e < 2; e++)
{
    System.Console.WriteLine("Nombre: "+ listao[e].Nombre);
    System.Console.WriteLine("Fecha de nacimiento: "+ (listao[e].FechaVencimiento).ToString("MM/dd/yyyy"));
    System.Console.WriteLine("Tamañio: "+ listao[e].Tamanio);
    System.Console.WriteLine("Precio: "+ listao[e].Precio);
}
class Productos
{
    private string nombre;
    public string Nombre{
        get{
            return nombre;
        }
        set{
            nombre=value;
        }
    }
    private DateTime fechaVencimiento;
    public DateTime FechaVencimiento{
        get{
            return fechaVencimiento;
        }
        set{
            fechaVencimiento=value;
        }
    }
    private int precio;
    public int Precio{
        get{
            return precio;
        }
    }
    private string tamanio;
    public string Tamanio{
        get{
            return tamanio;
        }
        set{
            tamanio=value;
        }
    }
    private Random aux=new Random();
    public void aleatorios(){
        this.precio=aux.Next(1000,5001);
    }
}