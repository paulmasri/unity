# Unity
Template for Unity projects

Uses Unity 2020.1.6f1

## Contents
- .gitignore for Unity, Mac, VSCode & FMOD
- Cinemachine
- Unity InputSystem (replaces legacy Input)
- [2d-extras](https://github.com/Unity-Technologies/2d-extras)
- [EventSystem by Lisandro Crespo](https://github.com/lisandroct/EventSystem)
- ScriptableObject Variables (adapted from [work presented by Ryan Hipple at Unity 2017](https://github.com/roboryantron/Unite2017))
- My own tools:
    - Generic ObjectPool (adapted from [TypeSafeObjectPool by Sam Izzo](https://github.com/samizzo/TypeSafeObjectPool)), from which you can create your own object pool classes. These have a size field (IntReference) and CanGrow (BoolReference), which reference ScriptableObjects. If CanGrow is set, it allows the size to be grown at runtime, permanently changing the maximum allowed size of this type of object pool between runs. Useful during development. Set CanGrow to false to make size readonly for production.
    - TimeScalar with corresponding DeveloperControls InputSystem hooked up in Main scene. This gives you keyboard controls to change game engine speed.
    - Utility2D 
