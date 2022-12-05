
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
var rutas = Directory.EnumerateDirectories(rutaPadre, "*", SearchOption.AllDirectories);
//var rutas = Directory.EnumerateFiles(rutaPadre, "*.json", SearchOption.AllDirectories);

foreach (var ruta in rutas) {
    Console.WriteLine($"Ruta: { ruta }");
}
