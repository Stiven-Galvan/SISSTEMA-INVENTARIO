# Nexo · Sistema de inventario

Proyecto académico web preparado para Visual Studio 2026, ASP.NET Core y .NET 10. La interfaz usa HTML, CSS y JavaScript sin dependencias externas. No es un programa Windows Forms: se ejecuta en una ventana del navegador.

## Abrir y ejecutar en Visual Studio 2026

1. Extrae todo el ZIP a una carpeta.
2. En Visual Studio Installer instala la carga de trabajo **Desarrollo de ASP.NET y web** y el SDK de .NET 10.
3. Abre `Nexo.Inventario.sln` (o `Nexo.Inventario.csproj`).
4. Selecciona el perfil `Nexo.Inventario` y presiona Ctrl+F5.
5. El navegador abrirá `http://localhost:5180`. Agrega productos o pulsa **Cargar ejemplo** para usar seis registros ficticios.

Alternativa por terminal con SDK .NET 10: `dotnet run --project Nexo.Inventario.csproj`.

## Funciones

- Agregar nombre, cantidad y valor unitario en pesos colombianos.
- Editar cualquiera de los tres datos.
- Eliminar con confirmación.
- Tabla visible con código, cantidad, valor unitario, valor total y estado.
- Indicadores de referencias, unidades, valor total y stock bajo (0 a 5 unidades).
- Búsqueda por nombre o código, filtros y ordenamiento.
- Exportación CSV del catálogo completo, con separador punto y coma y codificación UTF-8.
- Historial local de los últimos 200 movimientos.
- Validación de campos, cantidades enteras no negativas, precios no negativos y nombres duplicados.
- Guardado automático en localStorage. Recargar la página conserva el catálogo.

## Publicación

Versión web desplegada: https://nexo-inventario-stiven.galvansitiven64.chatgpt.site

El acceso inicial al alojamiento es privado para el propietario. Un docente u otra persona no tendrá acceso automáticamente. Antes de entregar un enlace a terceros debe configurarse la audiencia correspondiente desde las opciones del sitio.

La publicación alojada sirve los mismos archivos de `wwwroot`, copiados en `dist`. El host publicado es estático; el host ASP.NET Core incluido se utiliza para ejecutar y publicar desde Visual Studio. No se afirma haber ejecutado Visual Studio o compilado el host .NET en el entorno de creación: ese entorno no tiene el SDK .NET instalado. La funcionalidad web sí se probó en un navegador real.

### Publicar el host ASP.NET Core desde Visual Studio

Clic derecho en el proyecto → Publicar → Carpeta → seleccionar el perfil `Carpeta` → Publicar.
También puede usarse `dotnet publish Nexo.Inventario.csproj -c Release -o publicacion`.
En un equipo con ASP.NET Core Runtime 10 instalado, ejecutar `dotnet Nexo.Inventario.dll` desde la carpeta de publicación. Para alojarlo en Internet debe utilizarse un servidor compatible con ASP.NET Core y su configuración correspondiente.

## Estructura

- `Nexo.Inventario.sln`: solución de Visual Studio.
- `Nexo.Inventario.csproj`: proyecto web .NET 10.
- `Program.cs`: servidor ASP.NET Core y ruta /health.
- `wwwroot/index.html`: estructura de la interfaz y formularios.
- `wwwroot/styles.css`: diseño adaptable a diferentes tamaños de pantalla.
- `wwwroot/app.js`: CRUD, validaciones, indicadores, historial, CSV y persistencia.
- `Properties/launchSettings.json`: perfil de ejecución.
- `Properties/PublishProfiles/Carpeta.pubxml`: perfil de publicación en carpeta.
- `dist/`: copia de los recursos web utilizada por el alojamiento estático.

## Alcance de los datos

Cada navegador y dirección web tiene un catálogo independiente. Los datos no se sincronizan entre dispositivos ni entre localhost y la versión publicada. Borrar los datos del navegador elimina su inventario; el CSV permite conservar una copia legible, pero no incluye una función de importación. El nombre Administrador es una etiqueta de interfaz, no un sistema de autenticación. Este proyecto es una demostración académica de uso individual, sin base de datos compartida.

## Secuencia reproducible para sustentar el proyecto

1. En un navegador sin datos previos, cargar el ejemplo: 6 productos, 107 unidades y $9.812.000.
2. Agregar `Webcam Full HD`, cantidad `12`, valor unitario `150000`: 7 productos, 119 unidades y $11.612.000.
3. Editar Webcam Full HD a cantidad `20` y valor unitario `145000`: valor del producto $2.900.000; totales 7 productos, 127 unidades y $12.712.000.
4. Recargar: los datos deben permanecer.
5. Eliminar Webcam Full HD y confirmar: regresan 6 productos, 107 unidades y $9.812.000.
6. Buscar `audífonos`: se muestra Audífonos Bluetooth, con 4 unidades y estado Stock bajo.
7. Abrir Movimientos: comprobar registros de creación, actualización y eliminación.
8. Exportar CSV para revisar el catálogo en Excel.
