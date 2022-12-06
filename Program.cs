
using Archivos.Clases;
using System.Diagnostics;
using System.Text;

Console.WriteLine("¡TRABAJANDO CON ARCHIVOS!");

var rutaOrigen = @"C:\Users\josantiago\Documents\Cursos Udemy\Programando en C# de Principiante a Profesional\S11 - Trabajando con Archivos\ejemplo.txt";
var rutaDestino = @"C:\Users\josantiago\Documents\Cursos Udemy\Programando en C# de Principiante a Profesional\S11 - Trabajando con Archivos\ejemplo-copiado.txt";

/* Clase File - Leyendo archivo */
if (File.Exists(rutaOrigen)) {
    var contenido = File.ReadAllText(rutaOrigen);
    Console.WriteLine(contenido);
    File.Copy(rutaOrigen, rutaDestino, overwrite: true);
} else {
    Console.WriteLine("El archivo no fue encontrado");
}

var contenidoLineas = File.ReadAllLines(@"C:\Users\josantiago\Documents\Cursos Udemy\Programando en C# de Principiante a Profesional\S11 - Trabajando con Archivos\ejemplo-lineas.txt");
Console.WriteLine();

foreach (var line in contenidoLineas) {
    Console.WriteLine(line);
}

/* Clase Directory - Creando un directorio */
var rutaDirectorio = @"C:\Users\josantiago\Documents\Cursos Udemy\Programando en C# de Principiante a Profesional\S11 - Trabajando con Archivos\Carpeta-Archivos";
Directory.CreateDirectory(rutaDirectorio);

Console.WriteLine();

var rutaPadre = @"C:\Users\josantiago\Documents\Cursos Udemy\Programando en C# de Principiante a Profesional\S11 - Trabajando con Archivos";
//var rutas = Directory.EnumerateDirectories(rutaPadre, "*", SearchOption.AllDirectories);
var rutas = Directory.EnumerateFiles(rutaPadre, "*", SearchOption.AllDirectories);


/* Clase Path - Extraer nombre de un archivo */
foreach (var ruta in rutas) {
    var nombreArchivo = Path.GetFileName(ruta);
    var extension = Path.GetExtension(ruta);
    Console.WriteLine($"Archivo: { nombreArchivo }");
}

/* StreamWriter - Escribiendo archivos */
var rutaStream = @"C:\Users\josantiago\Documents\Cursos Udemy\Programando en C# de Principiante a Profesional\S11 - Trabajando con Archivos\stream-write.txt";
using (var streamWriter = new StreamWriter(rutaStream, append: true)) {
    streamWriter.WriteLine("Buenos días Fernando");
    streamWriter.WriteLine("Este es un mensaje de prueba");
    streamWriter.WriteLine($"La hora actual es: { DateTime.Now.ToString("hh:mm:ss") }");
    //streamWriter.Dispose();
}

/* Listado a archivo de texto */
var rutaPersonas = @"C:\Users\josantiago\Documents\Cursos Udemy\Programando en C# de Principiante a Profesional\S11 - Trabajando con Archivos\personas.txt";

var personas = new List<Persona> { 
    new Persona() { Id = 1, Nombre = "Fernando Nicolás", Salario = 15000 },
    new Persona() { Id = 2, Nombre = "Luis Nicolás", Salario = 18000 },
    new Persona() { Id = 3, Nombre = "Wendy Torres", Salario = 10000 },
    new Persona() { Id = 4, Nombre = "Marisol Contreras", Salario = 12000 },
    new Persona() { Id = 5, Nombre = "Maria Dae", Salario = 12000 },
    new Persona() { Id = 6, Nombre = "Juan Perez", Salario = 13000 },
};

var stringBuilder = new StringBuilder();

/*foreach (var persona in personas) {
    var id = persona.Id.ToString().PadLeft(5, '0');
    var nombre = persona.Nombre.PadLeft(20);
    var salario = persona.Salario.ToString("N2").Replace(".", "").PadLeft(5, '0');

    stringBuilder.AppendLine($"{ id }{ nombre }{ salario }");
}

using (var sw = new StreamWriter(rutaPersonas, append: false)) { 
    sw.Write(stringBuilder.ToString());
}*/

/* Creando un CSV */
var rutaPersonas2 = @"C:\Users\josantiago\Documents\Cursos Udemy\Programando en C# de Principiante a Profesional\S11 - Trabajando con Archivos\personas.csv";

foreach (var persona in personas) {
    stringBuilder.AppendLine($"{ persona.Id },{ persona.Nombre },{ persona.Salario }");
}

using (var sw = new StreamWriter(rutaPersonas2, append: false, Encoding.UTF8)) {
    sw.Write(stringBuilder.ToString());
}

/* StreamReader y Stopwatch */
var rutaGeneracion = @"C:\Users\josantiago\Documents\Cursos Udemy\Programando en C# de Principiante a Profesional\S11 - Trabajando con Archivos\numeros.csv";

/* Creando el archivo */
/* using (var sw = new StreamWriter(rutaGeneracion, append: false)) {
    for (int i = 0; i < 10_000_000; i++) {
        sw.WriteLine($"{ i },Persona { i },{i}.00");
    }
} */

var reloj = new Stopwatch();
reloj.Start();
var primeraLinea = File.ReadAllLines(rutaGeneracion)[0];
reloj.Stop();

Console.WriteLine();
Console.WriteLine($"Primera linea: { primeraLinea }");
Console.WriteLine($"Duración de File.ReadAllLines: { reloj.ElapsedMilliseconds / 1000.0 } segundos.");

var reloj2 = new Stopwatch();
reloj.Start();
string primeraLinea2;
using (var sr = new StreamReader(rutaGeneracion)) { 
    primeraLinea2 = sr.ReadLine();
    reloj.Stop();
}

Console.WriteLine();
Console.WriteLine($"Primera Linea: { primeraLinea2 }");
Console.WriteLine($"Duración del StreamReader: { reloj2.ElapsedMilliseconds / 1000.0 } segundos.");

