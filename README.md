🏃‍♂️ HealthRunner

🩺 Descripción del Proyecto:

HealthRunner es una aplicación de escritorio desarrollada en C# (.NET Framework y Windows Forms) orientada al monitoreo de la salud física y el rendimiento personal.
Permite registrar actividades diarias como pasos, kilómetros recorridos, calorías quemadas y frecuencia cardíaca.
Según estos valores, el sistema evalúa el rendimiento del usuario, asigna insignias de logro (Oro, Plata, Bronce) y actualiza automáticamente su nivel de progreso (Principiante, Intermedio o Avanzado).

Además, los datos se almacenan de forma estructurada en una base de datos, permitiendo generar estadísticas y mantener el historial de evolución del usuario.


👥 Integrantes y Roles:

Integrante	Rol	Responsabilidades
Nelson Stiven Cataño Hurtado	Desarrollador principal y analista funcional	Encargado del desarrollo completo del código, integración con la base de datos, validación de las reglas de negocio y pruebas funcionales.
Julian Restrepo Quiceno	Diseñador de interfaz y tester	Responsable del diseño de la interfaz, pruebas de usabilidad y validación del comportamiento visual y funcional del sistema.



⚙️ Instrucciones para ejecutar el programa:

Clona o descarga el repositorio desde
https://github.com/Guerrero77777/HealthRunner.git

Abre la solución en Visual Studio.
Asegúrate de que esté seleccionada la configuración de depuración (Debug) y la plataforma que corresponda (por ejemplo x86 o Any CPU).

Verifica que la cadena de conexión en el archivo ConexionDB.cs esté correctamente configurada para tu servidor de base de datos SQL Server (por ejemplo: Data Source=TU_SERVIDOR;Initial Catalog=HealthRunnerDB;Integrated Security=True;TrustServerCertificate=True).

Ejecuta el proyecto (F5).

Aparecerá el formulario de inicio de sesión (FrmInicio).

Si aún no tienes una cuenta, haz clic en “Registrar” para crear un usuario final o en “Administrador” para crear un usuario con perfil de administrador.

Tras iniciar sesión:

Si eres Usuario final, se abrirá el formulario de perfil de usuario (FrmPerfilUsuario). Allí podrás ingresar tus métricas diarias (pasos, kilómetros, calorías, frecuencia cardíaca), pulsar “Actualizar” y observar tu progreso, insignias, nivel y registro en base de datos.

Si eres Administrador, se abrirá el panel de administración (FrmPanelAdmin) donde podrás revisar los usuarios registrados, buscar, editar, eliminar, ver detalles y actualizar la lista.

Ingresa los datos solicitados y presiona el botón correspondiente (por ejemplo “Actualizar”).
Verifica que:

Los campos no estén vacíos.

Los valores sean numéricos válidos.

No excedas los límites de seguridad (más de 20 000 pasos, más de 15 km, más de 1 200 calorías o frecuencia cardíaca mayor a 150) — en ese caso verás un mensaje de advertencia y no se registrará.

Según los valores ingresados, se asignará la insignia correspondiente (Oro, Plata, Bronce o ninguna) y se mostrará un mensaje motivacional o de alerta según las reglas de negocio.

La barra de progreso se actualizará y el nivel cambiará automáticamente: Principiante (< 70 %), Intermedio (≥ 70 % y < 95 %) o Avanzado (≥ 95 %).

Todos los datos serán guardados en la tabla EstadisticasSalud, con los campos: IdUsuario, Pasos, Kilometros, Calorias, FrecuenciaCardiaca, FechaRegistro, ContadorOro, ContadorPlata, ContadorBronce, Nivel.

Puedes cerrar sesión desde el botón correspondiente en cada formulario, lo cual te llevará de vuelta al formulario de inicio de sesión.

