using UnityEngine;
using UnityEditor;

namespace EditorWindowAssignment
{
    [CustomEditor(typeof(ObjectManager))]
    public class MyWindow : EditorWindow
    {
        string myString = "Hello World";

        public ObjectManager m_scriptableObjData;

        public Texture2D texture;

        Vector3 vec3 = new Vector3(0,0,0);
        GameObject tempobj = null;

        Texture2D m_tick;

        Texture2D m_cross;

        // Add menu named "My Window" to the Window menu
        [MenuItem("Window/My Window")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            MyWindow window = (MyWindow)EditorWindow.GetWindow(typeof(MyWindow));
            window.Show();  
        }


        void OnGUI()
        {
            // Load textures sprites
            m_tick = Resources.Load("tick", typeof(Texture2D)) as Texture2D;
            m_cross = Resources.Load("cross", typeof(Texture2D)) as Texture2D;


            ScriptableObject scriptableObj = this;
            SerializedObject serialObj = new SerializedObject(scriptableObj);
            SerializedProperty serialProp = serialObj.FindProperty("m_scriptableObjData");
    
            EditorGUILayout.PropertyField(serialProp, true);
            serialObj.ApplyModifiedProperties();

            // Generate GUI for objects
            if(m_scriptableObjData != null)
            {
                GenerateGUI(m_scriptableObjData.sharedObjects);
                GenerateGUI(m_scriptableObjData.testingTimelineAndInfractions);
                GenerateGUI(m_scriptableObjData.HazardTimelines);
            }
        }

        void GenerateGUI(GameObject[] list)
        {
            foreach(var obj in list)
            {
                // Begin Layout Row
                GUILayout.BeginHorizontal("box");

                //Generate Label for GameObject Name
                GUILayout.Label(obj.name);

                
                var tempObj = GameObject.Find(obj.name);
                if(tempObj!= null)
                {
                    // GameObject Found
                    GUILayout.Label(m_tick, GUILayout.MaxWidth(20f), GUILayout.MaxHeight(20f));
                }
                else
                {
                    // GameObject Not Found
                    GUILayout.Label(m_cross, GUILayout.MaxWidth(20f), GUILayout.MaxHeight(20f));
                }

                // Generate the Validate Button
                if(GUILayout.Button("Validate"))
                {
                    // GameObject found check 
                    if(tempObj!= null)
                    {
            
                    }
                    else
                    {
                        // Generate the dialog box
                        if(EditorUtility.DisplayDialog("Oops! Not Found!",
                        "Do you want to generate the object in the current scene?", "Yes", "No"))
                        {
                            // Instantiate the game object
                            tempobj = (GameObject)Instantiate(obj, vec3, Quaternion.identity);

                            // TODO:: Figure out a system to spawn this as the child object of the parent.
                            tempobj.name = obj.name;
                            this.Repaint();
                        }
                    }
                }
                // End Layout row
                GUILayout.EndHorizontal();
            }
        }
    }
}
