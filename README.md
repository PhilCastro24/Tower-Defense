# Tower-Defense Game

In this game, players defend their castle from waves of enemies using various game mechanics. Each element in the game contributes to an immersive experience.

## Game Mechanics

### 1. **Player Economy**
   - **Bank System:** Tracks and displays the player’s ***gold balance.*** Gold can be earned by ***defeating enemies*** and is required to ***place towers.*** A negative balance triggers a level restart.
   
### 2. **Enemy System**
   - **Enemy Health:** Manages enemy health. Enemies ***gain extra health*** with each respawn, making the game ***progressively harder.***
   - **Enemy Controller:** Manages enemy movement along paths. If enemies ***reach the end of the path,*** they inflict a ***gold penalty*** on the player.
   
### 3. **Pathfinding System**
   - **Pathfinder:** Calculates the ***shortest route*** for enemies to reach the target. This script uses a ***Breadth-First Search algorithm*** and can ***dynamically recalculate*** paths if certain nodes become blocked.
   - **Grid Manager:** Creates and manages the grid layout for the pathfinding system. This system allows for ***flexibility in blocking*** and ***unblocking nodes*** as game objects (like towers) are placed.

### 4. **Tower Defense System**
   - **Tower Placement:** Towers can be placed on ***specific tiles,*** provided they don't block the enemy path. ***Towers cost gold to place,*** deducted from the player's bank.
   - **Target Locator:** Allows towers to ***detect*** and ***attack enemies*** within a ***specified range.***
   
### 5. **Additional Features**
   - **Coordinate Display:** Displays the grid coordinates and changes colors based on the status of each tile such as (***blocked, explored,*** or ***part of the path***).
   - **Object Pooling:** Manages enemy spawns efficiently by reusing inactive objects, ***reducing performance issues.***

## Key Systems in Action

1. **Enemy Pathing**: The game calculates an ***optimal path*** for ***each enemy,*** dynamically adjusting if the player blocks paths with tower placements.
2. **Economy and Upgrades**: Players must carefully manage their ***gold for tower placements and upgrades,*** as insufficient funds can lead to a failed defense.
3. **Tower AI**: Towers actively ***track and target the closest enemy*** within range, ***ensuring dynamic gameplay*** with adaptive defense.
___

Here´s the link to the Game:
[Play](https://play.unity.com/en/games/42306245-fb60-454f-bf1e-5a079017f6f6/tower-defense)
