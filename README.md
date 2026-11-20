# Sistema de Gestión de Taller Mecánico

Aplicación web ASP.NET Core MVC (.NET 8) con base de datos MongoDB Atlas.

## Requisitos

- Visual Studio con la carga de trabajo **Desarrollo web y ASP.NET**
- .NET 8 SDK
- Git
- Credenciales de la base de datos del equipo (pídelas a Angel)

## Clonar el repositorio

```bash
git clone https://github.com/angelblaze3/Gestion_taller_mecanico.git
cd Gestion_taller_mecanico
```

Abre `Gestion_taller_mecanico.csproj` en Visual Studio.

## Configurar la conexión a MongoDB

La cadena de conexión **no está en el repositorio**. Cada integrante la guarda en su computadora con User Secrets:

1. Clic derecho en el proyecto > **Administrar secretos de usuario**.
2. Pega esto y cambia los datos por los tuyos:

```json
{
  "MongoDB": {
    "ConnectionString": "mongodb+srv://USUARIO:CONTRASEÑA@cluster0.xxxxx.mongodb.net/?retryWrites=true&w=majority",
    "DatabaseName": "TallerMecanicoDB"
  }
}
```

3. Guarda con **Ctrl+S**.

Si la contraseña tiene símbolos como `@`, `#` o `/`, hay que codificarlos en la URL. Por ejemplo, `@` se escribe `%40`.

Tu IP también debe estar permitida en MongoDB Atlas, en **Network Access**.

## Ejecutar el proyecto

Presiona **F5** en Visual Studio, o desde la terminal:

```bash
dotnet run
```

## Flujo de trabajo

**Nadie hace push directo a `main`.** Todos los cambios entran por Pull Request.

### 1. Actualizar `main`

Antes de empezar cualquier cambio:

```bash
git checkout main
git pull
```

### 2. Crear tu rama

Usa el prefijo `feature/` y un nombre corto que describa el cambio:

```bash
git checkout -b feature/nombre-del-cambio
```

### 3. Trabajar y subir tus cambios

```bash
git status
git add .
git commit -m "Descripción clara del cambio"
git push -u origin feature/nombre-del-cambio
```

Antes de `git add .`, revisa con `git status` que **no aparezcan** `secrets.json`, `appsettings.Development.json`, `bin/` ni `obj/`.

### 4. Abrir un Pull Request

En GitHub aparecerá el botón **Compare & pull request**. Ábrelo, asegúrate de que la base sea `main`, describe qué cambiaste y pide revisión a un compañero.

### 5. Después del merge

Borra la rama en GitHub con **Delete branch** y en tu computadora:

```bash
git checkout main
git pull
git branch -d feature/nombre-del-cambio
```

Para el siguiente cambio, vuelve al paso 1.

## Convenciones

- **Ramas:** `feature/` para funcionalidades nuevas y `fix/` para correcciones.
- **Commits:** mensajes cortos en español que digan qué hacen, por ejemplo `Agrega formulario de alta de clientes`.
- **Un PR por cambio:** no mezclen varios módulos en la misma rama.
- **Secretos:** nunca subas contraseñas ni cadenas de conexión.
- **Conflictos:** si `git pull` o el PR marca conflictos, avisa en el equipo antes de resolverlos en `main`.

## Notas

- `Program.cs` tiene líneas temporales de prueba de conexión (`ProbarConexion`). Se quitan cuando la conexión esté confirmada.
- Los módulos del sistema se definirán cuando el maestro entregue los requerimientos.
