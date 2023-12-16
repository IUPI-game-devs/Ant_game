# Ant_game

## Description

The game consists of a player controling an ant and gather food for the colony before it starves. Fight dangerous enemies.

## Documentation

### World Map:

The map was made with 3d object, terrain. The dimentions of the map is 256 x 256. We used this illustration to make the biomes of the map.

![map_diagam](Images/map_diagram.png) ![](Images/map.png)

We used the terrain tools to make the map look more natural. We used the following textures:

<img src="Assets/Textures/brown-clay-textured-background-earth-tone-diy-creative-art-minimal-style.jpg" height="200"/>
<img src="Assets/Textures/11059458_47056.jpg" width="200"/>
<img src="Assets/Textures/cgshare-book-grass-003.jpg" width="200"/>

We didn't want to use textures that were too realistic because we wanted to keep the game in a low poly style. We added some assest to make the map more interesting and to make it look more natural. We added rocks, leafs, water and other things.

We also added a tunnel system to the map. This was to simulate the ant colony. We made use of th probuilder tool to make the tunnels. With the cone we were able to make the tunnel entrances and connections to the eliptical chambers. These chambers were made with the sphere tool and set the normals to the inside. We also placed some lights inside of the tunnels to make it look more interesting. We chose an amber lights to make it look like natural glowing fungus or something similar to give light to the tunnels.

![](Images/tunnels.png)

Most of the work was done with the help of the code writen in class, like the player script and the new input system.

### HUD:

The creation of the HUD was done with the use of some helpful material form YouTube. Here we created two distinct health related bars of health. One health bar was for the Players health:
![](Assets/Health/Empty.png)

This is a simple png image where the background is transparent. 

For the queen we used the same image but with the queens logo on top,

<img src= "Assets/Health/Queen.png" width="200"/>

The HUD was made using the UI elements from Unity and some creativity. We created a an Image UI element and the sprite we chose for that image was the emply health bar. We added another element to that HUD element that was just a simple block color. We chose to color it red to represent the players health. Then for the creation of the queen/colonies health we chose the color blue to differentiate.


<img src="Images/hud.png" alt="Image of the HUD" width="200"/>

We also made some code for the health bar to update. For the player if the player has damage then the 

## New aditions
- The ability of the camera following the player. This was done with an asset called "cinemachines".
- The player follows the mouse,. wherever the mouse is, thats the "forward" of the player.
- A giant map for tons of exploration.
- A simple HUD to show health and hunger.
