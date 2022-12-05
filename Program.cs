
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