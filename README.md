Sistema de Gestión de Citas Médicas (Tarea de la Universidad)

Este es un sistema de gestión de citas médicas desarrollado en C#. Permite a los usuarios agregar personas, crear citas médicas, eliminar citas, confirmar o cancelar visitas, y ver un listado de todas las personas y sus citas existentes.

## Funcionalidades
Agregar Persona: Permite registrar una nueva persona con su nombre, fecha de nacimiento y lugar de nacimiento.

Crear Cita: Permite crear una cita médica para una persona existente. Las citas pueden ser de tres tipos:

Cita de Rutina: Para consultas generales.

Cita de Examen: Para exámenes médicos.

Cita de Operación: Para procedimientos quirúrgicos.

Eliminar Cita: Permite eliminar una cita existente para una persona.

Confirmar o Cancelar Visita: Permite confirmar o cancelar una cita médica.

Ver Todas las Personas: Muestra un listado de todas las personas registradas junto con sus citas.

Ver Citas Existentes: Muestra un listado detallado de todas las citas existentes, incluyendo la fecha, hora, especialidad, médico y estado de confirmación.

Salir: Cierra la aplicación.

## Estructura del Código


El código está organizado en las siguientes clases:

Persona: Representa a una persona con sus datos personales y un expediente médico.

Expediente: Contiene una lista de citas médicas asociadas a una persona.

Cita: Clase abstracta que representa una cita médica. Tiene propiedades como la fecha, hora, especialidad, médico y estado de confirmación.

CitaRutina, CitaExamen, CitaOperacion: Clases que heredan de Cita y representan los diferentes tipos de citas médicas.

Program: Clase principal que contiene el menú interactivo y la lógica para gestionar las personas y citas.


## Requisitos
.NET SDK: Asegúrate de tener instalado el SDK de .NET para ejecutar este proyecto.

Editor de Código: Puedes usar Visual Studio, Visual Studio Code o cualquier otro editor de tu preferencia.

## Ejecución
Clona este repositorio o descarga el código fuente.

Abre una terminal en la carpeta del proyecto.

Ejecuta el siguiente comando para compilar y ejecutar el proyecto:

```bash
dotnet run
```

Sigue las instrucciones en el menú para gestionar personas y citas.


## Ejemplo de Uso

Agregar una Persona:

Selecciona la opción 1 en el menú.

Ingresa el nombre, fecha de nacimiento y lugar de nacimiento.

Crear una Cita:

Selecciona la opción 2 en el menú.

Ingresa el nombre de la persona, la fecha, hora, especialidad, médico y el tipo de cita.

Ver Citas Existentes:

Selecciona la opción 6 en el menú para ver todas las citas registradas.

## Contribuciones
Si deseas contribuir a este proyecto, siéntete libre de hacer un fork y enviar un pull request con tus mejoras.

## Licencia
Este proyecto está bajo la licencia MIT. Consulta el archivo LICENSE para más detalles.

