# Car Lock System V

Car Lock System for GTA 5 Single Player

## Introduction

This is a simple mod for GTA 5 which allows the player to lock and unlock cars that belong to them within the game.

The goal with this system is also to allow persistence of cars, meaning that once the player leaves the area and returns to it, they would still be able to find their cars there.

## Installation

Before installing the mod, you must have installed:

* [ScriptHook V](http://www.dev-c.com/gtav/scripthookv/)
* [Script Hook V .NET](https://github.com/crosire/scripthookvdotnet/releases) - I recommend installing the latest version

In order to install this script, just copy and paste the files provided into the `scripts` folder at the root of your game (where your game is installed).

If you don't have the scripts folder in your game folder, then create it.

## Project Goals

* [X] Basic Locking Mechanisms
* [ ] Supporting Multiple Vehicles
  * [ ] Add Database of Vehicles Owned By Player
  * [ ] Add Vehicles to Database
  * [ ] Support Locking of Multiple Vehicles at Once
* [ ] Integration with other mods (to load previously owned vehicles to the database)
  * [ ] Single Player Apartment (SPA)
  * [ ] Safehouse Reloaded
  * [ ] Single Player Garage (SPG)
  * [ ] Single Player Garage Reloaded (SPGR)
  * Any more mods that manage vehicles and garages will be added here
* [ ] Add persistence of currently owned vehicles when not in garage

## Known Bugs

Currently there are no known bugs. But feel free to let me know on the issues. Please add the bug tag into the issue so I know for sure it's a bug and look into it.

## License

This project has an MIT License, which means that you can distribute and modify this software as you like, as long as you provide the license alongside the software. Furthermore, some libraries used here might have different licenses and will be licensed separately from this project. Any library that this software uses is dully referenced and shall be used as-is (not altered).

## Thanks

This section is where I thank everyone that made this project possible, either because my work sits on top of theirs or because the work they have done was helpful to what I tried to achieve through research:

* [Alexander Blade](http://www.dev-c.com/) - ScriptHook V and NativeDB
* [crosire](https://github.com/crosire) and others - ScriptHook V .NET
* [I'm Not MentaL a.k.a qiangqiang101](https://github.com/qiangqiang101) - Single Player Apartment (SPA) and other great mods - they were a great base for research