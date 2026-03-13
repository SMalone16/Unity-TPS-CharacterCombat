# Third Person Parkour and Freeflow Combat
Third-person character controller for Unity featuring combat and parkour. It uses a Hierarchical State Machine.

## Unity Project Bootstrap
This repository now includes a Unity project scaffold configured for **Unity 2022.3.21f1 (LTS)**.

### Included project files
- `ProjectSettings/`
- `Packages/manifest.json`
- `Packages/packages-lock.json`
- Bootstrap scene: `Assets/Scenes/Prototype.unity`
- Player prefab used by the bootstrap scene: `Assets/Prefabs/Player.prefab`
- Imported state machine scripts: `Assets/Scripts/Character/StateMachine/`

### Setup and run steps
1. Open **Unity Hub** and click **Open**.
2. Select this repository folder (`Unity-TPS-CharacterCombat`).
3. In Unity Hub, ensure the project opens with **Unity 2022.3.21f1**.
4. After import completes, open `Assets/Scenes/Prototype.unity`.
5. Press **Play** to run the bootstrap scene.

> Note: The `Player` prefab is pre-placed in `Prototype.unity` and includes `CharacterController` + `PlayerStateMachine`.

### Movement
- Walk & Running
- Jumping
- Air Boost (Double Jump)
- Dashing
- Climbing up walls
- Wallrun
- Sliding down ramps
<img src="https://github.com/MrAlvaroRamirez/ThirdPersonActionHSM/blob/main/gifs/dash.gif" width="60%"/>
<img src="https://github.com/MrAlvaroRamirez/ThirdPersonActionHSM/blob/main/gifs/parkour1.gif" width="60%"/>
<img src="https://github.com/MrAlvaroRamirez/ThirdPersonActionHSM/blob/main/gifs/parkour2.gif" width="60%"/>

### Combat
- Freeflow system (inspired by games like Insomniac's Spiderman and Batman: Arkham City)
- TargetGroup camera
- Visual feedback
- Basic enemy AI/Manager (surround the player and wait for a chance to attack)
<img src="https://github.com/MrAlvaroRamirez/ThirdPersonActionHSM/blob/main/gifs/combat.gif" width="60%"/>
