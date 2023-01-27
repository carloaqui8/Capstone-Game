# Capstone-Game
2D Platformer

Breakdown: The creation of this game can be broken down into a few sections. Essentially, all my progress checkpoints require the previous checkpoint to be reached in order to add details to the AI and make the enemies more difficult to defeat. I intend for there to be both ground and aerial enemies, and I aim to make 3 to 5 new enemy scripts each section. Also, boss battles will be at each section, and their AI will only be slightly more complex than the ones in their area.

Timeline (4 Milestones):

	Checkpoint 1: Player, simple enemies, and boss 1
The first order of business is designing the player and its attacks; for now, the player only gets ranged “lemons” and sword slashes in the mouse’s direction. The enemies in this section are only capable of moving and attacking once encountered. The boss of this area is a “stomping” kind whose movement is somewhat predictable.

	Checkpoint 2: Enemies with behavior trees and boss 2
Enemies designed in this section have planned out actions that they can take when the player encounters them. Under certain circumstances, the enemy may run, attack, dodge, or even block. All of these actions are proximity-based, meaning they can only react once they can “see” the stimulus. The boss of this area will be projectile-based, and it will attempt to predict the player’s actions based on the way they’re moving.

	Checkpoint 3: Enemies that “cheat” and boss 3
These are enemies that know what the player inputs right as you input the command as well as the projected path of the attack. This allows them to react and counterattack quicker. They will also have more complex behavior trees. The boss of this section will be a “summoner” that can only be hit by certain attacks depending on their “mode.”

	Checkpoint 4: Platforming, cosmetics, and events.
Here, the platforming sections, menus, and general game features will be designed. The main things I look to add are stages, textures, a main menu, a pause screen, and event checkpoints. At this point, I might make the player gain new weapons with every boss defeated. If I have time, I might add sound effects and background music.
