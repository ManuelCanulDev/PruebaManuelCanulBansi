\# Sistema de Gestión de Exámenes



\## Descripción general



Este proyecto consiste en una aplicación de escritorio que permite administrar registros de \*\*exámenes\*\* mediante las operaciones básicas de:



\- Crear

\- Consultar

\- Actualizar

\- Eliminar



El sistema fue desarrollado para demostrar el funcionamiento de dos formas de acceso a datos:



1\. \*\*Mediante Web API\*\*

2\. \*\*Mediante procedimientos almacenados (Stored Procedures)\*\*



El usuario puede elegir en cualquier momento qué tipo de conexión utilizar.



---



\# Componentes del sistema



El sistema está compuesto por dos partes principales:



\### 1. Web API

Servicio que expone endpoints para administrar los registros de la tabla \*\*tblExamen\*\*.



Permite realizar:



\- Inserción de registros

\- Consulta de registros

\- Actualización de registros

\- Eliminación de registros



\### 2. Aplicación de Escritorio (WinForms)



Interfaz gráfica desde donde el usuario interactúa con el sistema.



Permite gestionar los registros y elegir si se trabaja mediante:



\- Web API

\- Procedimientos almacenados



---



\# Ejecución del sistema



Para utilizar correctamente la aplicación se recomienda seguir el siguiente orden:



\### 1. Ejecutar la Web API



Primero se debe iniciar el proyecto \*\*Web API\*\*, el cual expone los servicios necesarios para el sistema.



Una vez iniciado, el servicio quedará disponible en la dirección local correspondiente.



\### 2. Ejecutar la aplicación de escritorio



Posteriormente se ejecuta el proyecto de \*\*Windows Forms\*\*, que es la interfaz desde la cual el usuario interactúa con el sistema.



---



\# Interfaz del sistema



La aplicación cuenta con los siguientes elementos principales:



\### Campos de captura



\- \*\*Id\*\*  

&nbsp; Identificador único del examen.



\- \*\*Nombre\*\*  

&nbsp; Nombre del examen.



\- \*\*Descripción\*\*  

&nbsp; Descripción del examen.



\### Opciones de conexión



Un checkbox permite elegir el tipo de conexión:



\- Desactivado → uso de \*\*Stored Procedures\*\*

\- Activado → uso de \*\*Web API\*\*



Esto permite validar que el sistema funciona correctamente utilizando ambos métodos de acceso a datos.



\### Tabla de resultados



La parte inferior del sistema contiene una tabla que muestra los registros existentes en la base de datos.



Las filas cuentan con un estilo visual alternado para mejorar la legibilidad.



---



\# Flujo de uso del sistema



\## 1. Consulta de registros



Al iniciar la aplicación se cargan automáticamente los registros existentes.



También es posible presionar el botón \*\*Consultar\*\* para actualizar la lista en cualquier momento.



El resultado se mostrará en la tabla inferior.



---



\## 2. Crear un nuevo registro



Para registrar un nuevo examen se deben seguir los siguientes pasos:



1\. Ingresar el \*\*Id\*\*

2\. Ingresar el \*\*Nombre\*\*

3\. Ingresar la \*\*Descripción\*\*

4\. Presionar el botón \*\*Guardar\*\*



Si el registro se almacena correctamente, el sistema mostrará un mensaje de confirmación y actualizará la tabla de registros.



---



\## 3. Selección de registros



Al hacer \*\*un doble clic\*\* sobre cualquier fila de la tabla se habilita la opción de \*\*Eliminar\*\*.



Esto permite seleccionar el registro que se desea eliminar.



---



\## 4. Edición de registros



Para modificar un registro existente:



1\. Realizar \*\*doble clic\*\* sobre una fila de la tabla.

2\. Los datos se cargarán automáticamente en los campos de captura.

3\. El botón \*\*Guardar\*\* cambiará a modo \*\*Actualizar\*\*.

4\. Modificar los datos deseados.

5\. Presionar \*\*Actualizar\*\*.



El sistema guardará los cambios y recargará la tabla.



---



\## 5. Eliminación de registros



Para eliminar un registro:



1\. Seleccionar una fila con \*\*clic simple\*\*.

2\. Presionar el botón \*\*Eliminar\*\*.



El sistema eliminará el registro seleccionado y actualizará la tabla.



---



\# Validaciones del sistema



El sistema realiza validaciones antes de ejecutar cualquier operación:



\- El \*\*Id\*\* debe ser numérico.

\- El \*\*Nombre\*\* es obligatorio.

\- La \*\*Descripción\*\* es obligatoria.



Si alguna validación no se cumple, el sistema notificará al usuario.



---



\# Características del sistema



\- Interfaz sencilla y fácil de usar.

\- Permite alternar entre dos métodos de acceso a datos.

\- Actualización automática de registros después de cada operación.

\- Edición rápida mediante doble clic en la tabla.

\- Visualización clara de los datos mediante estilos de tabla.



---



\# Resumen de funcionalidades



El sistema permite:



\- Registrar nuevos exámenes

\- Visualizar todos los registros

\- Modificar información existente

\- Eliminar registros

\- Cambiar entre conexión por \*\*Web API\*\* o \*\*Stored Procedures\*\*



---



\# Conclusión



La aplicación demuestra la implementación de un flujo completo de administración de datos mediante dos mecanismos distintos de acceso a base de datos, proporcionando una interfaz clara y funcional para el usuario.

