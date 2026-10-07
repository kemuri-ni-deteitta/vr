<div align="center">

# Unity VR Interaction Prototype

### Учебный проект по созданию интерактивной 3D-среды в Unity

Проект демонстрирует базовые механики, применяемые при разработке интерактивных и VR-приложений: работу с 3D-сценой, Unity Physics, пользовательским интерфейсом, событиями кнопок, столкновениями объектов и отображением состояния через TextMesh Pro.

![Unity](https://img.shields.io/badge/Unity-2022.3.9f1-000000?logo=unity&logoColor=white)
![CSharp](https://img.shields.io/badge/C%23-Unity-512BD4?logo=csharp&logoColor=white)
![TextMeshPro](https://img.shields.io/badge/TextMesh-Pro-333333)
![Platform](https://img.shields.io/badge/Platform-3D%20%2F%20VR-555555)

</div>

---

## О проекте

`vr` — учебный Unity-проект, посвящённый изучению основных механизмов построения интерактивной трёхмерной среды.

В проекте объединены несколько независимых механик:

- создание 3D-сцены;
- работа с `GameObject`;
- физическое взаимодействие объектов;
- использование `Rigidbody`;
- использование `Collider`;
- обработка событий столкновения;
- подсчёт количества столкновений;
- вывод состояния через TextMesh Pro;
- создание пользовательского интерфейса;
- работа с `Button`;
- программное включение и отключение элементов UI;
- использование Terrain;
- подготовка структуры для дальнейшего добавления телепортации;
- наличие базовых Unity VR/XR-модулей.

Общий принцип проекта:

```text
Unity Scene
    │
    ├── 3D Environment
    │      ├── Terrain
    │      ├── Sphere
    │      └── Cube
    │
    ├── Physics
    │      ├── Rigidbody
    │      └── Collider
    │
    ├── UI
    │      ├── FirstButton
    │      └── SecondButton
    │
    └── C# Logic
           ├── ButtonControl
           ├── TextMeshProCollisionCounter
           └── ScriptToTeleport
```

---

# Технологический стек

| Технология | Назначение |
|---|---|
| **Unity 2022.3.9f1** | создание и запуск 3D-сцены |
| **C#** | программирование поведения объектов |
| **Unity Physics** | физическая симуляция |
| **Rigidbody** | подключение объектов к физическому движку |
| **Collider** | обнаружение столкновений |
| **Unity UI** | создание пользовательского интерфейса |
| **TextMesh Pro 3.0.6** | отображение текста |
| **Terrain** | создание трёхмерного окружения |
| **Visual Scripting 1.9.0** | дополнительный Unity-инструментарий |
| **Unity XR / VR modules** | базовая поддержка XR со стороны движка |

---

# Версия Unity

Проект создан с использованием:

```text
Unity 2022.3.9f1
```

Версия зафиксирована в:

```text
ProjectSettings/ProjectVersion.txt
```

Для открытия проекта рекомендуется использовать Unity 2022 LTS, предпочтительно:

```text
2022.3.9f1
```

---

# Основная сцена

Главная сцена проекта:

```text
Assets/Scenes/Menu.unity
```

Несмотря на название `Menu`, сцена объединяет как пользовательский интерфейс, так и элементы трёхмерной среды.

В ней присутствуют:

```text
Menu
│
├── Main Camera
├── Directional Light
├── Terrain
│
├── Sphere
├── Cube
│
├── Counter
│
├── Canvas
│   ├── Background
│   ├── FirstButton
│   └── SecondButton
│
└── EventSystem
```

---

# Пользовательский интерфейс

В сцене используется стандартная система:

```text
Unity UI
```

Основной контейнер:

```text
Canvas
```

В нём расположены:

```text
Background
FirstButton
SecondButton
```

Для обработки UI-событий используется:

```text
EventSystem
```

---

# Управление состоянием кнопок

Логика управления кнопками реализована в:

```text
Assets/Background/Script for actiivation and deactivation.cs
```

Основной класс:

```csharp
public class ButtonControl : MonoBehaviour
```

Он содержит ссылки на две кнопки:

```csharp
public Button firstButton;
public Button secondButton;
```

---

## Подписка на события

В методе:

```csharp
Start()
```

для кнопок регистрируются обработчики:

```csharp
firstButton.onClick.AddListener(DisableFirstButton);
secondButton.onClick.AddListener(EnableFirstButton);
```

Таким образом:

```text
FirstButton
     │
     │ click
     ▼
DisableFirstButton()
     │
     ▼
firstButton.interactable = false
```

Вторая кнопка выполняет обратное действие:

```text
SecondButton
     │
     │ click
     ▼
EnableFirstButton()
     │
     ▼
firstButton.interactable = true
```

---

# `interactable`

В Unity UI свойство:

```csharp
Button.interactable
```

определяет возможность взаимодействия пользователя с кнопкой.

Когда:

```csharp
firstButton.interactable = false;
```

кнопка остаётся видимой, но пользователь больше не может нажать её.

Когда:

```csharp
firstButton.interactable = true;
```

возможность взаимодействия восстанавливается.

---

# Полный сценарий работы UI

Сценарий можно представить следующим образом:

```text
Начальное состояние

FirstButton  = enabled
SecondButton = enabled

        │
        ▼

Пользователь нажимает FirstButton

        │
        ▼

DisableFirstButton()

        │
        ▼

FirstButton = disabled

        │
        ▼

Пользователь нажимает SecondButton

        │
        ▼

EnableFirstButton()

        │
        ▼

FirstButton = enabled
```

Таким образом демонстрируется программное управление состоянием UI-элементов через C#.

---

# Текст кнопок

В интерфейсе используются TextMesh Pro UI-компоненты.

Для первой кнопки указан текст:

```text
Click for disable me
```

Для второй:

```text
Click for enable my friend
```

Это визуально показывает назначение элементов интерфейса.

---

# Физическая система

Вторая часть проекта демонстрирует работу физического движка Unity.

Для взаимодействующих объектов используются:

```text
GameObject
    │
    ├── Rigidbody
    └── Collider
```

Когда Collider одного объекта сталкивается с Collider другого, Unity может вызвать:

```csharp
OnCollisionEnter()
```

---

# Cube

В сцене присутствует объект:

```text
Cube
```

Он имеет специальный тег:

```text
OtherObjectTag
```

Тег используется для определения того, должно ли столкновение учитываться пользовательской логикой.

---

# Обработка столкновений

Логика находится в:

```text
Assets/Collision.cs
```

Основной класс:

```csharp
public class TextMeshProCollisionCounter : MonoBehaviour
```

В нём хранится счётчик:

```csharp
private int counter = 0;
```

и ссылка на компонент TextMesh Pro:

```csharp
public TextMeshPro textMeshPro;
```

---

# Алгоритм Collision Counter

Основная последовательность:

```text
3D Object
    │
    ▼
Collision
    │
    ▼
OnCollisionEnter()
    │
    ▼
CompareTag("OtherObjectTag")
    │
    ├── false
    │      │
    │      └── событие игнорируется
    │
    └── true
           │
           ▼
       counter++
           │
           ▼
       UpdateText()
           │
           ▼
      TextMesh Pro
```

---

# `OnCollisionEnter`

Unity автоматически вызывает:

```csharp
private void OnCollisionEnter(Collision collision)
```

когда происходит физическое столкновение.

После этого выполняется:

```csharp
if (collision.gameObject.CompareTag("OtherObjectTag"))
```

То есть учитывается не любое столкновение, а только взаимодействие с объектом, имеющим нужный тег.

---

# Увеличение счётчика

При подходящем столкновении выполняется:

```csharp
counter++;
```

После чего вызывается:

```csharp
UpdateText();
```

Значение выводится:

```csharp
textMeshPro.text = "Count: " + counter;
```

Результат изменяется следующим образом:

```text
Count: 0
   ↓
Count: 1
   ↓
Count: 2
   ↓
Count: 3
```

---

# TextMesh Pro

Для отображения количества столкновений используется объект:

```text
Counter
```

с компонентом:

```text
TextMesh Pro
```

Связь компонентов:

```text
Collision
    │
    ▼
TextMeshProCollisionCounter
    │
    ▼
counter
    │
    ▼
TextMeshPro
    │
    ▼
"Count: N"
```

Это позволяет сразу отображать изменение внутреннего состояния программы в интерфейсе сцены.

---

# Работа с тегами

Вместо проверки имени объекта используется:

```csharp
CompareTag("OtherObjectTag")
```

Такой подход лучше связывает игровую логику с назначением объекта.

Например, один тег может быть назначен нескольким объектам:

```text
Cube A ───┐
Cube B ───┼── OtherObjectTag
Sphere C ─┘
```

После этого один обработчик сможет реагировать на взаимодействие со всеми объектами данной группы.

---

# Terrain

В сцене присутствует объект:

```text
Terrain
```

с собственным:

```text
TerrainCollider
```

Terrain используется в качестве основы виртуального пространства.

Он может выступать:

- поверхностью сцены;
- физическим основанием;
- частью виртуального окружения;
- областью размещения интерактивных объектов.

Данные Terrain находятся в:

```text
Assets/New Terrain.asset
```

---

# Материалы

В проекте присутствуют пользовательские материалы:

```text
Assets/New Material.mat
Assets/New Material 1.mat
```

Они используются для визуального оформления объектов сцены.

Таким образом, внешний вид объекта в Unity отделяется от его физической логики:

```text
GameObject
    │
    ├── Mesh
    ├── Material
    ├── Collider
    ├── Rigidbody
    └── Script
```

---

# Заготовка под телепортацию

В проекте существует файл:

```text
Assets/Background/ScriptToTeleport.cs
```

и класс:

```csharp
public class ScriptToTeleport : MonoBehaviour
```

В текущей версии методы:

```csharp
Start()
```

и:

```csharp
Update()
```

не содержат пользовательской логики.

Поэтому телепортация в текущем состоянии проекта **ещё не реализована**.

Файл можно рассматривать как подготовленную точку расширения проекта.

---

# Возможная логика телепортации

В дальнейшем этот компонент может быть использован для реализации следующего сценария:

```text
User Input
    │
    ▼
Select destination
    │
    ▼
Validate destination
    │
    ▼
Change player position
    │
    ▼
Teleport
```

В полноценном VR-проекте подобная механика обычно реализуется совместно с:

```text
XR Origin
Teleportation Area
Teleportation Provider
XR Ray Interactor
```

---

# VR / XR

В `Packages/manifest.json` присутствуют стандартные Unity-модули:

```text
com.unity.modules.vr
com.unity.modules.xr
```

Таким образом Unity-проект содержит базовые XR-возможности движка.

Однако отдельный пакет:

```text
XR Interaction Toolkit
```

в текущей конфигурации не подключён.

Также в основной сцене не обнаружена полноценная XR-структура вида:

```text
XR Origin
├── Camera Offset
│   └── Main Camera
│
├── Left Controller
└── Right Controller
```

Поэтому текущий проект правильнее характеризовать как:

> интерактивный Unity 3D-прототип и основу для дальнейшей реализации VR-механик.

---

# Архитектура проекта

Основные пользовательские механики можно представить так:

```text
                        Unity
                          │
             ┌────────────┴────────────┐
             │                         │
             ▼                         ▼
            UI                       3D Scene
             │                         │
      ┌──────┴──────┐          ┌──────┴──────┐
      │             │          │             │
 FirstButton   SecondButton   Terrain     Objects
      │             │                        │
      └──────┬──────┘                 Rigidbody
             │                         Collider
             ▼                            │
       ButtonControl                      ▼
             │                         Collision
             │                            │
             ▼                            ▼
      interactable             CollisionCounter
                                          │
                                          ▼
                                      Counter
                                          │
                                          ▼
                                     TextMesh Pro
```

---

# Структура проекта

Основные директории:

```text
vr/
│
├── Assets/
│   ├── Background/
│   │   ├── Script for actiivation and deactivation.cs
│   │   └── ScriptToTeleport.cs
│   │
│   ├── Scenes/
│   │   └── Menu.unity
│   │
│   ├── Collision.cs
│   ├── New Terrain.asset
│   ├── New Material.mat
│   ├── New Material 1.mat
│   └── TextMesh Pro/
│
├── Packages/
│   └── manifest.json
│
├── ProjectSettings/
│   └── ProjectVersion.txt
│
├── Library/
├── Logs/
├── UserSettings/
│
├── Assembly-CSharp.csproj
└── project_for_first_task.sln
```

---

# Основные пользовательские файлы

## `Collision.cs`

Реализует:

```text
Collision
    ↓
Tag check
    ↓
Counter increment
    ↓
Text update
```

Класс:

```csharp
TextMeshProCollisionCounter
```

---

## `Script for actiivation and deactivation.cs`

Реализует управление двумя кнопками.

Класс:

```csharp
ButtonControl
```

Основные методы:

```csharp
DisableFirstButton()
EnableFirstButton()
```

---

## `ScriptToTeleport.cs`

Подготовленная заготовка для механики телепортации.

В текущей версии пользовательская логика отсутствует.

---

## `Menu.unity`

Основная сцена проекта.

Содержит:

- камеру;
- освещение;
- Terrain;
- 3D-объекты;
- Canvas;
- кнопки;
- TextMesh Pro;
- EventSystem;
- физическое взаимодействие.

---

# Событийная модель Unity

Проект демонстрирует два основных типа событий.

## UI Event

```text
Button
   │
   ▼
onClick
   │
   ▼
C# method
   │
   ▼
UI state change
```

Пример:

```csharp
firstButton.onClick.AddListener(DisableFirstButton);
```

---

## Physics Event

```text
Collider
   │
   ▼
Collision
   │
   ▼
OnCollisionEnter
   │
   ▼
C# logic
   │
   ▼
Application state change
```

Таким образом в одном проекте используются сразу две событийные подсистемы Unity:

```text
Unity UI Events
+
Unity Physics Events
```

---

# Запуск проекта

## Требования

Рекомендуется установить:

```text
Unity Hub
Unity 2022.3.9f1
```

---

## Клонирование репозитория

```bash
git clone https://github.com/kemuri-ni-deteitta/vr.git
```

Перейти в директорию:

```bash
cd vr
```

---

# Открытие проекта

В Unity Hub:

```text
Projects
    ↓
Add / Open
    ↓
выбрать папку vr
```

После импорта открыть:

```text
Assets/Scenes/Menu.unity
```

---

# Запуск

В Unity Editor:

```text
Menu Scene
    ↓
Play
```

После запуска можно проверить:

1. взаимодействие с `FirstButton`;
2. блокировку первой кнопки;
3. восстановление кнопки через `SecondButton`;
4. взаимодействие физических объектов;
5. изменение счётчика столкновений.

---

# Реализованные возможности

| Возможность | Состояние |
|---|---|
| Unity 3D-сцена | Реализовано |
| Terrain | Реализовано |
| Пользовательские материалы | Реализовано |
| Unity UI | Реализовано |
| Canvas | Реализовано |
| EventSystem | Реализовано |
| FirstButton / SecondButton | Реализовано |
| Управление `interactable` | Реализовано |
| Rigidbody | Реализовано |
| Colliders | Реализовано |
| Collision events | Реализовано |
| Tag-based collision logic | Реализовано |
| Счётчик столкновений | Реализовано |
| TextMesh Pro output | Реализовано |
| XR / VR Unity modules | Присутствуют |
| Teleport script | Создана заготовка |
| Логика телепортации | Не реализована |
| XR Interaction Toolkit | Не подключён |
| XR Origin | Не настроен |

---

# Что демонстрирует проект

С технической точки зрения проект показывает работу с:

```text
Unity
│
├── GameObject
├── Components
├── MonoBehaviour
├── C# scripts
│
├── Unity UI
│   ├── Canvas
│   ├── Button
│   └── EventSystem
│
├── Physics
│   ├── Rigidbody
│   ├── Collider
│   └── OnCollisionEnter
│
├── Tags
├── Terrain
└── TextMesh Pro
```

Особенно важна событийная архитектура.

Вместо постоянной ручной проверки состояния программа реагирует на события:

```text
Button click
        │
        ▼
     Method
```

или:

```text
Collision
    │
    ▼
OnCollisionEnter
```

---

# Возможное дальнейшее развитие

Проект можно развить в полноценную VR-сцену.

Следующим этапом может стать подключение:

```text
XR Interaction Toolkit
        │
        ▼
XR Origin
        │
        ├── VR Camera
        ├── Left Controller
        └── Right Controller
```

После этого можно добавить:

- перемещение пользователя по VR-сцене;
- телепортацию;
- взаимодействие с объектами;
- захват предметов контроллерами;
- `XR Grab Interactable`;
- `XR Ray Interactor`;
- управление виртуальными кнопками;
- пространственный UI;
- VR-меню;
- систему заданий;
- подсказки пользователю;
- проверку правильности действий.

---

# Рекомендация по Git

В репозитории присутствуют директории:

```text
Library/
Logs/
UserSettings/
```

Большая часть этих файлов генерируется Unity автоматически.

Обычно в Git достаточно хранить:

```text
Assets/
Packages/
ProjectSettings/
```

а директории:

```text
Library/
Temp/
Logs/
Obj/
```

добавлять в `.gitignore`.

Это значительно уменьшает размер Unity-репозитория и количество лишних изменений в Git.

---

# Основная идея проекта

Проект демонстрирует базовую архитектуру интерактивного приложения на Unity:

```text
User
 │
 ├───────────────┐
 │               │
 ▼               ▼
 UI             3D Interaction
 │               │
 ▼               ▼
Button         Collision
 │               │
 ▼               ▼
C# Logic       C# Logic
 │               │
 ▼               ▼
UI State      Counter State
 │               │
 └───────┬───────┘
         │
         ▼
    Visual Feedback
```

Таким образом проект объединяет пользовательский интерфейс, физическую систему Unity и собственную C#-логику в одной интерактивной 3D-сцене.

Он может использоваться как основа для дальнейшего изучения **VR/XR-разработки, взаимодействия пользователя с виртуальной средой и создания учебных VR-приложений**.

---

<div align="center">

### Unity Interactive 3D / VR Prototype

**Unity · C# · UI · Physics · TextMesh Pro · Terrain · XR Foundation**

</div>
