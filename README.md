# AirSpace

AirSpace is an augmented reality system for air traffic controllers that aims to modernize the aviation industry and improve both flight safety and efficiency.

## Project

AirSpace works by taking flight data that’s typically shown on flat 2D radar displays and overlaying that information in the real world, so controllers can see that information in 3D space.  This is important because on a flat map it is very difficult to visualize how far apart two planes actually are from each other, due to their altitude adding a 3rd dimension. Two planes overlapping might be right on top of each other about to crash, or 100 nautical miles away from each other.

https://devpost.com/software/airspace

## Team

Terrell Ibanez

Fan Marin

Juan Gill

Adam Halawani

Manuel Garzon

Special Thanks to Herbert Ramirez

## Versions

### Unity

2019.2.x

### MLSDK

v0.23.0

### LuminOS

0.98.x

## Instructions After Downloading

1) Using Unity Hub, download Unity 2019.2.x and make sure Lumin support is checked during installation
2) `ADD` the project using Unity Hub
3) Open the project using Unity Hub
4) Under File > Build Settings, make sure the build target is Lumin
5) Under Unity preferences, set the MLSDK path
6) Under project settings > player settings > Lumin tab (Magic Leap logo icon) > publishing settings, set your cert path (and make sure the privkey file is in the same directory. If this is confusing, refer to and read the Magic Leap docs. There’s also a `README` in the privkey folder after unzipping)
7) Make sure USB debugging is enabled between your device and computer (which requires MLDB access) and you’re allowing untrusted sources
8) Open the `AirportTest` Scene from `Assets`>`Scenes`>`AirportTest`
