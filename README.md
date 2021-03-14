# UnityEditorWindow

## Unity Version : 2019.4.12F1

## Details:

### Scene -> EditorWindowScene
- Activate the Unity Editor Window from
  Windows > MyWindow
- Activating the MyWindow EditorWindow will initially throw a lot of error ( Missing Reference )
- The MyWindow panel throws errors due missing reference to Scriptable Object
- Search for ScritableObject named "Objects"
  Asset > Editor > Objects.asset
- In the MyWindow editor Window, assign objects to Scriptable Obj Data Input Area
- The panel would then generate the Objects mentioned in the Scritable object
- Pressing hte validate button, will check if the Object is present inside the scene or not
- If the object is not present inside the current scene, a Dialog box asking permission to generate the object is displayed
- Clicking Yes would generate the object, clicking no would silently pass
- The panel will display a cross if the object is not present inside the scene, and would display a green check if the Object is present inside the scene

### Scene - CustomHands
- Scene contains custom OVRCameraRig
- Left and Right hands are replaced with Red and Blue cube respectively
- The Project was tested on Oculus Quest 2
