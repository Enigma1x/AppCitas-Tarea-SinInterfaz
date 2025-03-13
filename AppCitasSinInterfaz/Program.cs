using System;
using System.Collections.Generic;

namespace AppCitas
{
    // Clase Persona
    public class Persona
    {
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string LugarNacimiento { get; set; }
        public Expediente Expediente { get; set; }

        public Persona(string nombre, DateTime fechaNacimiento, string lugarNacimiento)
        {
            Nombre = nombre;
            FechaNacimiento = fechaNacimiento;
            LugarNacimiento = lugarNacimiento;
            Expediente = new Expediente();
        }
    }

    // Clase Expediente
    public class Expediente
    {
        public List<Cita> Citas { get; set; }

        public Expediente()
        {
            Citas = new List<Cita>();
        }

        public void AgregarCita(Cita cita)
        {
            Citas.Add(cita);
        }

        public void EliminarCita(Cita cita)
        {
            Citas.Remove(cita);
        }
    }

    // Clase abstracta Cita
    public abstract class Cita
    {
        public DateTime Dia { get; set; }
        public string Hora { get; set; }
        public string Especialidad { get; set; }
        public string Medico { get; set; }
        public bool ConfirmacionVisita { get; set; }

        protected Cita(DateTime dia, string hora, string especialidad, string medico)
        {
            Dia = dia;
            Hora = hora;
            Especialidad = especialidad;
            Medico = medico;
            ConfirmacionVisita = false;
        }

        public void ConfirmarVisita()
        {
            ConfirmacionVisita = true;
        }

        public void CancelarVisita()
        {
            ConfirmacionVisita = false;
        }
    }

    // Clase CitaRutina
    public class CitaRutina : Cita
    {
        public CitaRutina(DateTime dia, string hora, string especialidad, string medico)
            : base(dia, hora, especialidad, medico)
        {
        }
    }

    // Clase CitaExamen
    public class CitaExamen : Cita
    {
        public CitaExamen(DateTime dia, string hora, string especialidad, string medico)
            : base(dia, hora, especialidad, medico)
        {
        }
    }

    // Clase CitaOperacion
    public class CitaOperacion : Cita
    {
        public CitaOperacion(DateTime dia, string hora, string especialidad, string medico)
            : base(dia, hora, especialidad, medico)
        {
        }
    }

    // Clase Program
    class Program
    {
        static void Main(string[] args)
        {
            List<Persona> personas = new List<Persona>();
            while (true)
            {
                Console.WriteLine("Bienvenido al sistema de citas");
                Console.WriteLine("1. Agregar persona ");
                Console.WriteLine("2. Crear Cita ");
                Console.WriteLine("3. Eliminar Cita");
                Console.WriteLine("4. Confirmar Cita o Cancelar Visita");
                Console.WriteLine("5. Ver todas las personas");
                Console.WriteLine("6. Citas Existentes");
                Console.WriteLine("7. Salir");
                Console.WriteLine("Seleccione una opción: ");
                //
                // Convertierte la opción a entero y el sistmea lo almacena en la variable [opcion]
                //  int opcion = Convert.ToInt32(Console.ReadLine());
                //  Intente convertirlo pero da error porque la variable [opcion] es de tipo string
                //  y acabo de aprender que si uso el *ejemplo "1" es string y si uso el ejemplo 1 es int(entero)
                //
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarPersona(personas);
                        break;
                    case "2":
                        CrearCita(personas);
                        break;
                    case "3":
                        EliminarCita(personas);
                        break;
                    case "4":
                        ConfirmarCitaOCancelarVisita(personas);
                        break;
                    case "5":
                        ListaPersonas(personas);
                        break;
                    case "6":
                        TodasLasCitas(personas);
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
        }

        static void AgregarPersona(List<Persona> personas)
        {
            Console.WriteLine("Nombre (Solo el nombre): ");
            string nombre = Console.ReadLine();
            //Console.WriteLine("Fecha de nacimiento (yyyy-mm-dd): ");
            //DateTime fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Fecha de nacimiento (yyyy-mm-dd): ");
            string input = Console.ReadLine();
            DateTime fechaNacimiento;
            while (!DateTime.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out fechaNacimiento))
            {
                Console.WriteLine("Formato de fecha no válido. Por favor, ingrese la fecha en el formato yyyy-mm-dd: ");
                input = Console.ReadLine();
            }


            Console.WriteLine("Lugar de nacimiento: ");
            string lugarNacimiento = Console.ReadLine();

            Persona persona = new Persona(nombre, fechaNacimiento, lugarNacimiento);
            personas.Add(persona);
        }

        static void CrearCita(List<Persona> personas)
        {
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();
            Persona persona = personas.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (persona == null)
            {
                Console.WriteLine("Persona no encontrada");
                return;
            }
            Console.WriteLine("Para que dia quiere agregar la cita? ");
            Console.WriteLine("Dia de la Cita (yyyy-mm-dd): ");
            string input = Console.ReadLine();
            DateTime dia;
            while (!DateTime.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dia))
            {
                Console.WriteLine("Formato de fecha no válido. Por favor, ingrese la fecha en el formato yyyy-mm-dd: ");
                input = Console.ReadLine();
            }

            Console.WriteLine("Hora de la Cita (hh:mm): ");
            string hora = Console.ReadLine();
            Console.WriteLine("Especialidad: ");
            string especialidad = Console.ReadLine();
            Console.WriteLine("Médico: ");
            string medico = Console.ReadLine();
            Console.WriteLine("Tipo de Cita (1. Rutina, 2. Examen, 3. Operación): ");
            //
            //convertimos el resultado de la opción a entero y lo almacenamos en la variable [tipoCita]
            //
            int tipoCita = Convert.ToInt32(Console.ReadLine());

            Cita cita;
            switch (tipoCita)
            {
                case 1:
                    cita = new CitaRutina(dia, hora, especialidad, medico);
                    break;
                case 2:
                    cita = new CitaExamen(dia, hora, especialidad, medico);
                    break;
                case 3:
                    cita = new CitaOperacion(dia, hora, especialidad, medico);
                    break;
                default:
                    Console.WriteLine("Tipo de cita no válido");
                    return;
            }

            persona.Expediente.AgregarCita(cita);
            Console.WriteLine("Cita creada exitosamente");
        }

        static void EliminarCita(List<Persona> personas)
        {
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();
            Persona persona = personas.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (persona == null)
            {
                Console.WriteLine("Persona no encontrada");
                return;
            }
            Console.WriteLine("Dia de la Cita (yyyy-mm-dd): ");
            string input = Console.ReadLine();
            DateTime dia;
            while (!DateTime.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dia))
            {
                Console.WriteLine("Formato de fecha no válido. Por favor, ingrese la fecha en el formato yyyy-mm-dd: ");
                input = Console.ReadLine();
            }
            Cita cita = persona.Expediente.Citas.Find(c => c.Dia == dia);
            if (cita == null)
            {
                Console.WriteLine("Cita no encontrada");
                return;
            }
            persona.Expediente.EliminarCita(cita);
            Console.WriteLine("Cita eliminada exitosamente");
        }

        static void ListaPersonas(List<Persona> personas)
        {
            Console.WriteLine($"Personas Existentes: {personas.Count}");
            foreach (Persona persona in personas)
            {
                Console.WriteLine($"Nombre: {persona.Nombre}");
                Console.WriteLine($"Fecha de Nacimiento: {persona.FechaNacimiento}");
                Console.WriteLine($"Lugar de Nacimiento: {persona.LugarNacimiento}");
                Console.WriteLine("Citas: ");
                foreach (Cita cita in persona.Expediente.Citas)
                {
                    Console.WriteLine($"  Dia: {cita.Dia}");
                    Console.WriteLine($"  Especialidad: {cita.Especialidad}");
                    Console.WriteLine($"  Confirmación de Visita: {cita.ConfirmacionVisita}");
                }
            }
        }

        static void TodasLasCitas(List<Persona> personas)
        {
            Console.WriteLine("Citas Existentes: ");
            foreach (Persona persona in personas)
            {
                Console.WriteLine($"Nombre: {persona.Nombre}");
                Console.WriteLine("Citas: ");
                foreach (Cita cita in persona.Expediente.Citas)
                {
                    Console.WriteLine($"  Dia: {cita.Dia}");
                    Console.WriteLine($"  Hora: {cita.Hora}");
                    Console.WriteLine($"  Especialidad: {cita.Especialidad}");
                    Console.WriteLine($"  Médico: {cita.Medico}");
                    Console.WriteLine($"  Confirmación de Visita: {cita.ConfirmacionVisita}");
                }
            }
        }

        static void ConfirmarCitaOCancelarVisita(List<Persona> personas)
        {
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();
            Persona persona = personas.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (persona == null)
            {
                Console.WriteLine("Persona no encontrada");
                return;
            }
            Console.WriteLine("Dia de la Cita (yyyy-mm-dd): ");
            string input = Console.ReadLine();
            DateTime dia;
            while (!DateTime.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dia))
            {
                Console.WriteLine("Formato de fecha no válido. Por favor, ingrese la fecha en el formato yyyy-mm-dd: ");
                input = Console.ReadLine();
            }
            Cita cita = persona.Expediente.Citas.Find(c => c.Dia == dia);
            if (cita == null)
            {
                Console.WriteLine("Cita no encontrada");
                return;
            }
            Console.WriteLine("Confirmar (1) o Cancelar Visita (2) ");
            string confirmacion = Console.ReadLine();
            if (confirmacion == "1")
            {
                cita.ConfirmarVisita();
                Console.WriteLine("Cita confirmada exitosamente");
            }
            else if (confirmacion == "2")
            {
                cita.CancelarVisita();
                Console.WriteLine("Cita cancelada exitosamente");
            }
            else
            {
                Console.WriteLine("Opción no válida");
            }
        }
    }
}
