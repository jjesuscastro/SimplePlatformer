# Simple Unity Platformer

A classic 2D platformer built in Unity. This project focuses on the core fundamentals of platforming gameplay, utilizing Unity's built-in 2D tools and high-quality community assets.

## 🕹 Gameplay & Controls

Navigate through levels, jump across platforms, and interact with the environment.

| Action | Key |
| :--- | :--- |
| **Move Left / Right** | `A` / `D` |
| **Jump** | `W` or `Space` |
| **Interact** | `Z` |

---

## 🛠 How it was Built

### Level Design (Tilemap)
The world is constructed using Unity's **Tilemap** system and the **Tile Palette**. This allowed for rapid level prototyping and efficient collision handling by using a single `Tilemap Collider 2D` combined with a `Composite Collider 2D`.

### Visual Assets
All environment and character art were sourced from the **Unity Asset Store**. The project demonstrates how to integrate third-party sprites, slice them into sheets, and implement them within a 2D workflow.

### Physics-Based Movement
The player controller utilizes `Rigidbody2D` for movement and jumping, ensuring the character interacts naturally with slopes, platforms, and gravity.

---

## 🚀 Getting Started

1. **Download/Clone** the repository.
2. Open the project folder in **Unity Hub** (Recommended version: 2021.3 LTS or newer).
3. Open `Assets/Scenes/SampleScene.unity`.
4. Press **Play** to start the game!

---

## ✨ Features

* **Tile-Based Levels:** Seamless environments created with Tile Palettes.
* **Interactable Objects:** Use the `Z` key to trigger switches, talk to NPCs, or open doors.
* **Smooth 2D Controls:** Responsive movement and jumping physics.
* **Asset Store Integration:** Showcases effective use of premade 2D art assets.

---

## 📂 Project Highlights

* **Prefabs:** Easily reusable player and environmental objects.
* **Scripts:** Simple, documented C# scripts for player movement and interaction logic.
* **Palettes:** Included Tile Palette assets for easy world expansion.
