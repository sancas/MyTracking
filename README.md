# MyTracking
Sistema de tracking de paquetes ASP Net

# Pasos a seguir.
- Cambiar la conexion a la base de datos en el archivo "Web.config".
- Restaurar los paquetes NuGet.
- Ejecutar el proyecto y registrar un nuevo usuario, al registrar un usuario se crearan las bases de datos pertinentes.
- Crear un rol con el nombre "Admin" en la base de datos local dentro de "App_Data", en la tabla "AspNetRoles".
- Copiar el id del usuario creado anteriormente que se encuentra en la tabla "AspNetUsers".
- Asignarle al usuario por medio del los id el rol de "Admin" en la tabla "AspNetUsersRoles".
- Consigue una Key para usar google maps [aqui](https://developers.google.com/maps/documentation/javascript/get-api-key?hl=ES) y cambialo en la vista "Views/Shared/_Layout.cshtml" en donde dice: "key=YOUR_API_KEY".
- Ya podras ingresar y ver los apartados para crear paquetes en el sitio web.
