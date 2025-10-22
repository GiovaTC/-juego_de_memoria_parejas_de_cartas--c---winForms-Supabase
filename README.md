# 🧠 Juego de Memoria (Parejas de Cartas) — C# WinForms + Supabase

<img width="1024" height="1024" alt="image" src="https://github.com/user-attachments/assets/4b7df149-8090-4913-86ba-e303c4ff2cb8" />

## 🎯 Descripción

Este proyecto implementa un **Juego de Memoria (Parejas de Cartas)** desarrollado en **Visual Studio 2022 (C# WinForms)**, que guarda los resultados de las partidas (jugador, intentos, tiempo y fecha) en una base de datos **Supabase** (PostgreSQL en la nube).

Ideal para aprender:
- Programación con **Windows Forms (WinForms)**  
- Manejo de **listas y eventos en C#**  
- Consumo de **API REST Supabase**  
- Registro y consulta de datos en la nube  

---

## ⚙️ Tecnologías utilizadas

- Visual Studio 2022  
- .NET 6 (C# WinForms)  
- Supabase (PostgreSQL + REST API)  
- JSON + HttpClient  

---

## 🧩 Características

✅ Interfaz gráfica tipo tablero (4x4)  
✅ Cronómetro y contador de intentos  
✅ Registro de jugador y puntaje  
✅ Guarda resultados en Supabase  
✅ Visualización global de resultados  
✅ (Opcional) modo multijugador local  

---

## 🗂️ Estructura del proyecto

```
MemoryGame_Supabase/
├─ Form1.cs
├─ FormResultados.cs
├─ SupabaseService.cs
├─ Program.cs
└─ App.config
```

---

## 🖥️ Interfaz visual

```
-------------------------------------------------
| Jugador: [_________]  Tiempo: 00:00  Intentos: 0 |
-------------------------------------------------
| [A] [B] [A] [B] |
| [C] [D] [C] [D] |
| [E] [F] [E] [F] |
| [G] [H] [G] [H] |
-------------------------------------------------
| [Guardar Puntaje] [Reiniciar] [Ver Resultados]  |
-------------------------------------------------
```

---

## 🧠 Código principal del juego — `Form1.cs`

```csharp
// Código completo incluido anteriormente
```

---

## ☁️ Conexión con Supabase — `SupabaseService.cs`

```csharp
// Código completo incluido anteriormente
```

---

## 🧾 Guardar puntaje — botón `Guardar Puntaje`

```csharp
// Código completo incluido anteriormente
```

---

## 🏆 Mostrar tabla global — `FormResultados.cs`

```csharp
// Código completo incluido anteriormente
```

---

## 🧱 Script SQL — Tabla `resultados`

```sql
CREATE TABLE resultados (
  id serial PRIMARY KEY,
  jugador varchar(50),
  intentos int,
  tiempo varchar(10),
  fecha timestamptz default now()
);
```

---

## 🚀 Instrucciones de instalación

1. Clonar o descargar este repositorio.  
2. Abrir **Visual Studio 2022** → *Abrir proyecto existente*.  
3. Configurar:
   - `.NET 6`
   - **Supabase URL y API Key** en `SupabaseService.cs`
4. Crear la tabla `resultados` en tu proyecto Supabase.
5. Ejecutar el proyecto y probar el juego.  
6. Ver puntajes globales desde el formulario de resultados.

---

## 🌐 Enlaces útiles

- [Supabase Dashboard](https://app.supabase.com)  
- [Documentación Supabase REST API](https://supabase.com/docs/guides/api)  
- [Descargar Visual Studio 2022](https://visualstudio.microsoft.com/es/downloads/)  

---

## 👨‍💻 Autor

**Giovanny Alejandro Tapiero Cataño (GiovaTC)**  
Proyecto educativo desarrollado con ❤️ para prácticas de integración .NET + nube.

---

## 📄 Licencia

MIT License — Libre para usar y modificar con fines educativos.
