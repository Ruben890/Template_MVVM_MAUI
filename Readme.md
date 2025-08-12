# Documentacion:

## LynxMaui

  **LynxMaui** es una aplicación móvil desarrollada con [**.NET MAUI**](https://learn.microsoft.com/en-us/dotnet/maui/), que sigue principios de arquitectura limpia, promoviendo el desacoplamiento de la interfaz de usuario, así como la reutilización de componentes visuales y lógicos.
  
---

## Estructura del Proyecto

```plaintext
LynxMaui/
│
├── Lynx.UI/                # Proyecto principal MAUI (UI y navegación)
│   ├── Views/              # Páginas específicas (Home, Auth, etc.)
│   ├── ViewModels/         # ViewModels por módulo
│   ├── Resources/          # Fuentes, estilos y recursos locales
│   └── App.xaml            # Punto de entrada y configuración principal
│
├── Lynx.Components/        # Biblioteca MAUI para componentes UI reutilizables
│   ├── Components/         # Controles personalizados (botones, tarjetas, inputs)
│   ├── Themes/             # Temas globales (colores, estilos, modo oscuro/claro)
│   ├── Behaviors/          # Validaciones, efectos e interacciones personalizadas
│   └── Resources/          # Imágenes, iconos y otros recursos compartidos
│
├── Lynx.Application/       # Capa de aplicación (servicios,  base)
│   ├── Config/             # Configuraciones específicas de la aplicación
│   ├── Interfaces/         # Interfaces Repositorios y servicios comunes
│   ├── Services/           # Servicios como NavigationService, DialogService, etc.
│   └── Mappers/            # Mapeo de objetos (AutoMapper o manual)
│
├── Lynx.Domain/            # Lógica de negocio pura
│   ├── Entities/           # Entidades del dominio (Usuario, Ruta, etc.)
│   └── Validators/         # Validaciones específicas del dominio
│
├── Lynx.Infrastructure/    # Implementaciones técnicas (acceso a datos, APIs)
│   ├── Data/               # EF Core, SQLite, clientes REST
│   ├── Services/           # Integraciones externas (APIs, email, archivos)
│   └── Config/             # Constantes y configuraciones de entorno
│
├── Lynx.Shared/            # Código compartido entre capas
│   ├── Models/             # Modelos comunes
│   ├── Enums/              # Enumeraciones globales
│   ├── Constants/          # Constantes generales
│   ├── Extensions/         # Métodos de extensión
│   └── Utils/              # Utilidades y helpers
```

---

## Requisitos

* .NET 8 SDK
* MAUI workload instalado (`dotnet workload install maui`)
* Visual Studio 2022 o 2025 con soporte para MAUI

---

## Ejecución

Desde la terminal:

```bash
dotnet build Lynx.UI
dotnet run --project Lynx.UI
```

O abre el proyecto `Lynx.UI` en Visual Studio y ejecuta en un emulador Android o simulador iOS.

---

## Estilos Globales

Los diccionarios de recursos se encuentran en `Lynx.Components/Themes/` y se agregan en `App.xaml.cs` así:

```csharp
Resources.MergedDictionaries.Add(new Colors());
Resources.MergedDictionaries.Add(new Styles());
```

---

## Convenciones y Principios

- Arquitectura basada en **MVVM** (Model-View-ViewModel)
- Inyección de dependencias configurada en `MauiProgram.cs`
- Separación clara entre **UI**, **Infrastrutura** y **dominio**
- Reutilización de UI mediante la librería `Lynx.Components`
- Código compartido y utilidades centralizadas en `Lynx.Shared`

---
