using System.Collections.Generic;

Dictionary<string, double> regalos = new Dictionary<string, double>();

string curso;
int estudiantes;
double regalo;

menu();

void menu()
{
   bool quiereContinuar = true;

   int opcionElegida;
   while (quiereContinuar)
   {
   Console.WriteLine("1. Ingrese los importes de un curso\n2. Ver estadisticas\n3. Salir");
   opcionElegida = int.Parse(Console.ReadLine());
   Console.Clear();
      switch(opcionElegida)
      {
         case 1:
            curso = pedirCurso();
            estudiantes = pedirEstudiantes(curso);
            regalo = ingresarRegalos(estudiantes);
            regalos.Add(curso, regalo);
            break;
         case 2:
            if (regalos.Count == 0)
            {
               Console.WriteLine("Para ver las estadisticas tenes que ingresar al menos un curso.");
               Console.ReadKey();
               Console.Clear();
               break;
            }
            else
            {
               obtenerCursoMaximo(regalos);
               obtenerPromedio(regalos);
               obtenerTotal(regalos);
               obtenerCantCursos(regalos);
               Console.ReadKey();
               Console.Clear();
               break;
            }
            
         case 3:
            quiereContinuar = false;
            break;
         default:
            Console.WriteLine("Ingresa una opcion valida.");
            Console.ReadKey();
            Console.Clear();
            break;
      }
   }
}

string pedirCurso()
{
   Console.WriteLine("Ingresa el curso");
   string curso = Console.ReadLine();

   return curso;
}

int pedirEstudiantes(string curso)
{
   bool estudiantesValido = false;
   int estudiantes= 0;
   do
   {
      Console.WriteLine($"Ingresa la cantidad de estudiantes de {curso}. Los estudiantes no pueden ser 0 o menos.");
      estudiantes = int.Parse(Console.ReadLine());
      if (estudiantes <= 0)
      {
         Console.WriteLine("Los estudiantes no pueden ser 0 o menos.");
      }
      else
      {
         estudiantesValido = true;
      }
   
   } while (!estudiantesValido);
   return estudiantes;
}

double ingresarRegalos(int estudiantes)
{
   double regalos = 0;
   double regalo;
   bool regaloValido;
   for (int i = 0; i < estudiantes; i++)
   {
      regaloValido = false;
      do
      {
         Console.WriteLine($"Alumno {i+1}, ingresa la cantidad de plata que le vas a regalar a Tomás");
         regalo = int.Parse(Console.ReadLine());
         if (regalo <= 0)
         {
            Console.WriteLine("No le podes regalar 0 o menos. Ingresalo nuevamente.");
         }
         else
         {
            regaloValido = true;
         }
      } while (!regaloValido);
      regalos += regalo;
   }
   return regalos;
}

void obtenerCursoMaximo(Dictionary<string, double> dict)
{
   Console.WriteLine("El curso que mas plata puso es " + dict.Keys.Max());
}

void obtenerPromedio(Dictionary<string, double> dict)
{
   Console.WriteLine("El promedio de plata regalado entre todos los cursos es " + dict.Values.Average());
}

void obtenerTotal(Dictionary<string, double> dict)
{
   Console.WriteLine("La recaudacion total de todos los cursos es " + dict.Values.Sum());
}

void obtenerCantCursos(Dictionary<string, double> dict)
{
   Console.WriteLine("La cantidad de cursos que participan del regalo es " + dict.Count());
}