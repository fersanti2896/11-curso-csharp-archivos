
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



