# OHV1 — Once Human Inspired Survival Game
**Style:** Low-poly, Roblox aesthetic | **Perspective:** Top-down | **Setting:** Post-apocalyptic

---

## Project Vision

A top-down survival game inspired by Once Human. Players explore a low-poly post-apocalyptic world, gather resources, craft items, fight mutated enemies, and eventually play together online.

**Core pillars:**
- Explore a dangerous open world
- Gather resources & craft gear
- Fight enemies to survive
- Play with friends (multiplayer — Phase 5+)

---

## Tech Stack

| Tool | Purpose | Notes |
|------|---------|-------|
| Unity 2022 LTS | Game engine | Use LTS for stability |
| C# | Scripting language | You will learn this as you go |
| Universal Render Pipeline (URP) | Rendering | Better visuals, good for low-poly |
| FishNet Networking | Multiplayer | Free, beginner-friendly, Unity-native |
| Unity Asset Store (free tier) | Low-poly assets | Speeds up early dev |
| Git + GitHub | Version control | Never lose your work |

---

## Phased Roadmap

### PHASE 0 — Setup & Fundamentals (Weeks 1–2)
**Goal:** Get Unity running, learn the basics, set up your project correctly.

- [ ] Install Unity 2022 LTS via Unity Hub
- [ ] Create project with **Universal Render Pipeline (URP)** template
- [ ] Set up Git repository (GitHub Desktop is easiest)
- [ ] Complete Unity basics: scenes, GameObjects, components, Inspector
- [ ] Learn C# fundamentals: variables, if/else, functions, Update loop
- [ ] Download free low-poly asset pack from Unity Asset Store

**Resources:**
- Unity Learn: "Unity Essentials" (free, official)
- Brackeys YouTube: "How to make a Video Game" series
- C# basics: "CS for Unity" on Unity Learn

**Milestone:** You can create a scene, add objects, and write a script that prints to the console.

---

### PHASE 1 — Player Foundation (Weeks 3–5)
**Goal:** A character moves around a map. Camera follows. It feels good.

- [ ] Create a low-poly player character (capsule + hat = Roblox style, or import asset)
- [ ] Write a **PlayerMovement.cs** script (WASD top-down movement)
- [ ] Set up a top-down camera that follows the player smoothly
- [ ] Build a simple test map (flat terrain with obstacles)
- [ ] Add player rotation — character faces the mouse cursor
- [ ] Add a basic **Animator** (idle, walk animations)

**Key concepts you will learn:**
- Rigidbody2D vs Rigidbody (we use 3D with top-down camera)
- Transform.Translate vs Rigidbody.MovePosition
- Cinemachine for camera follow (built-in Unity tool)

**Milestone:** You can walk your character around a map and it feels smooth.

---

### PHASE 2 — Survival Stats (Weeks 6–7)
**Goal:** The player can die. Health, hunger, and thirst exist.

- [ ] Create **PlayerStats.cs** — health, hunger, thirst values
- [ ] Stats drain over time (hunger/thirst go down slowly)
- [ ] When hunger/thirst hit zero, health drains
- [ ] When health hits zero, player dies (respawn for now)
- [ ] Build a basic **HUD UI** — health bar, hunger bar, thirst bar
- [ ] Add a day/night cycle (simple directional light rotation)

**Key concepts you will learn:**
- ScriptableObjects (great for storing stat configs)
- Unity UI system (Canvas, Slider, Image)
- Coroutines (for timed stat drain)

**Milestone:** Leave your character standing still long enough and they die.

---

### PHASE 3 — Inventory & Resources (Weeks 8–11)
**Goal:** Pick up items, see them in your inventory, use them.

- [ ] Scatter resource objects on the map (wood, metal, food)
- [ ] Write **ItemPickup.cs** — walk over item to collect it
- [ ] Build **InventorySystem.cs** — a list of items the player holds
- [ ] Create **InventoryUI** — a grid-based inventory panel (press I to open)
- [ ] Add item data with ScriptableObjects (name, icon, type, stats)
- [ ] Consuming food/water restores hunger/thirst stats

**Key concepts you will learn:**
- ScriptableObjects as data containers
- List<T> in C#
- UI drag-and-drop basics

**Milestone:** You can walk around, collect food, open your inventory, eat it, and restore hunger.

---

### PHASE 4 — Crafting System (Weeks 12–14)
**Goal:** Combine resources to make better gear.

- [ ] Design a simple crafting recipe system (ScriptableObject recipes)
- [ ] Build **CraftingUI** — show available recipes, required items, craft button
- [ ] Craft basic items: bandage, water bottle, basic weapon
- [ ] Items can be equipped from inventory

**Milestone:** You can gather wood + metal and craft a weapon.

---

### PHASE 5 — Combat (Weeks 15–18)
**Goal:** Enemies exist. You can fight them. They fight back.

- [ ] Create a basic enemy prefab (low-poly creature)
- [ ] Write **EnemyAI.cs** — patrol, detect player, chase, attack
- [ ] Player melee attack (swing animation + hitbox)
- [ ] Player ranged attack (gun — instantiate bullet prefab)
- [ ] Enemy drops loot on death (random from a loot table)
- [ ] Enemy health bar above head

**Key concepts you will learn:**
- NavMesh for enemy pathfinding
- Physics.OverlapSphere for attack detection
- State machines (Patrol / Chase / Attack states)

**Milestone:** Enemies patrol, detect you, chase you, and you can kill them for loot.

---

### PHASE 6 — World Building (Weeks 19–22)
**Goal:** The world feels alive and worth exploring.

- [ ] Build a proper map (zones: forest, ruins, wasteland)
- [ ] Add environmental storytelling props (abandoned cars, ruins)
- [ ] Add ambient sounds (wind, distant moans)
- [ ] Spawn system — enemies respawn in zones over time
- [ ] Add points of interest (abandoned buildings to loot)
- [ ] Simple minimap (render texture trick)

**Milestone:** The game feels like a world, not a test scene.

---

### PHASE 7 — Multiplayer (Weeks 23–32)
**Goal:** Two players can play together online.

> **Important:** Everything above must be stable and fun solo before touching this phase. Multiplayer does not fix a broken game — it multiplies its problems.

- [ ] Install **FishNet** from Unity Package Manager
- [ ] Set up a basic server/client connection (local first)
- [ ] Sync player positions across network
- [ ] Sync player animations
- [ ] Sync combat (hits, deaths)
- [ ] Sync inventory changes
- [ ] Sync enemy state
- [ ] Host game via **Edgegap** (free tier) or **Photon Relay**
- [ ] Add a simple lobby (player name, join/create room)

**Key concepts you will learn:**
- NetworkObject, NetworkBehaviour (FishNet)
- Server-authoritative vs client-authoritative design
- RPCs (Remote Procedure Calls)
- Network synchronization

**Milestone:** Two players can connect, walk around, fight enemies, and share the same world.

---

### PHASE 8 — Polish & Release (Weeks 33+)
- [ ] Main menu scene
- [ ] Settings (resolution, volume, keybinds)
- [ ] Sound effects and music
- [ ] Visual effects (hit sparks, pickup glow, death effect)
- [ ] Performance optimization (LOD, occlusion culling)
- [ ] Build and publish to itch.io

---

## Weekly Schedule (2 hrs/day)

| Day | Focus |
|-----|-------|
| Monday | Learn — watch tutorial or read docs for next task |
| Tuesday | Implement — write code, build the feature |
| Wednesday | Implement continued |
| Thursday | Test & fix bugs |
| Friday | Polish what you built, clean up code |
| Saturday | Free — experiment, try something fun |
| Sunday | Review week, plan next week tasks |

---

## Ground Rules

1. **Commit to Git every session.** If you break something, you can go back.
2. **Never start multiplayer early.** It will derail everything.
3. **Ugly but functional beats pretty but broken.** Polish comes last.
4. **One feature at a time.** Finish it. Test it. Then move on.
5. **Copy shamelessly from tutorials.** Understand it, then make it yours.
6. **If stuck for more than 30 min — Google it, YouTube it, then ask.**

---

## Low-Poly Asset Resources (Free)

- [Kenney.nl](https://kenney.nl) — free low-poly everything (characters, tiles, props)
- Unity Asset Store → filter: Free → search "low poly survival"
- Quaternius.com — free low-poly character packs

---

## Current Phase: PHASE 0
**Next action:** Install Unity 2022 LTS and create a URP project.
