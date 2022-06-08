# Unity
Template for Unity projects

Uses Unity 2022.1.3f1

## Contents
- .gitignore for Unity, Mac, VSCode & FMOD
- Cinemachine
- Unity InputSystem (replaces legacy Input)
- [2d-extras](https://github.com/Unity-Technologies/2d-extras)
- [EventSystem by Lisandro Crespo](https://github.com/lisandroct/EventSystem) v1.5.5
    - Using this, events `BoolEvent` and `TransformEvent` have been generated.
    - To work with this are my own scripts (in `Assets/Scripts/PaulMasriStone/EventSystem`):
        - `GameEventDetectors` for creating detectors matched to events
        - `GameEventDetector` which exists for parameterless events
        - `BoolDetector` & `TransformDetector` to match `BoolEvent` & `TransformEvent`
- ScriptableObject Variables (adapted from [work presented by Ryan Hipple at Unity 2017](https://github.com/roboryantron/Unite2017))
- My own tools (in `Assets/Scripts/PaulMasriStone`)
    - Generic `ObjectPool` (adapted from [TypeSafeObjectPool by Sam Izzo](https://github.com/samizzo/TypeSafeObjectPool)), from which you can create your own object pool classes. These have a size field (IntReference) and CanGrow (BoolReference), which reference ScriptableObjects. If CanGrow is set, it allows the size to be grown at runtime, permanently changing the maximum allowed size of this type of object pool between runs. Useful during development. Set CanGrow to false to make size readonly for production. This makes use of `IntVariable` and `BoolVariable` so these exist (in the folder `Assets/ScriptableObjects/Code/Variables`).
    - Generic `Saver` which uses interface `IJsonSerializer` (in `Assets/Scripts/PaulMasriStone/Interfaces`), which provides `Save(data)` and `Load()` for any class to serialize & deserialize to JSON. The path is specified in the constructor. If running in the editor, file extension `.json` is used and the data is plain text pretty JSON. Otherwise, the file extension is `.dat`, the data is compact JSON base-64 encoded.
    - `GenericStatic` provides methods DeepCopy(T) and Shuffle(IList<T>), which are self-explanatory.
    - `TimeScalar` with corresponding DeveloperControls InputSystem hooked up in Main scene. This gives you keyboard controls to change game engine speed.
    - `Utility2D` provides method `IsPointWithinCollider2D`
