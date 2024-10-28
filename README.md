# Api Manga Store

## Requisitos
- **.NET SDK**: v8.0.403
- **SqlServer**

## Instalaci�n

1. Clonar el repositorio
    - via Http
    ```bash
    git clone https://github.com/Bfiq/API_MangaStore.git
    ```

    - via SSH
    ```bash
    git clone git@github.com:Bfiq/API_MangaStore.git
    ```

2. Navegar a la carpeta del proyecto y restaurar las dependencias
```bash
dotnet restore
```

3. Crear el archivo `appSttings.json` y agregar la cadena de conexi�n a la base de datos
```bash
"ConnectionStrings" : {
    "mangaBd": "Cadena de conexi�n a la base de datos"
}
```

4. Aplicar Migraciones
```bash
dotnet ef database update
```

5. Ejecucu�n del proyectos
```bash
dotnet run
```

## Estructura de los proyectos
- `/Controllers`: Contiene los controladores de la API.
- `/DTOs`: Define los Data Transfer Objects (DTOs) usados para transferir datos entre la API y los clientes.
- `/Exceptions`: Define el manejo de errores personalizados.
- `/Migrations`: Contiene los archivos de migraci�n de la base de datos generados por Entity Framework.
- `/Models`: Define las entidades de la base de datos.
- `/Repositories`: Incluye las clases de acceso a datos.
- `/Services`: Contiene la l�gica de negocio.
- `DatabaseContext.cs`: Clase de contexto de la base de datos que configura las conexiones y relaciones entre entidades utilizando Entity Framework.
- `Program.cs`: Punto de entrada de la aplicaci�n, donde se configuran los servicios e inicia el servidor de la API.

## Proximas Mejoras
- Implementaci�n de JWT para autenticaci�n.
- Integraci�n del servicio de pagos.