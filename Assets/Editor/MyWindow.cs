﻿using UnityEngine;
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

        Texture2D tick;

        Texture2D cross;

        Texture2D image;


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
            tick = Resources.Load("tick", typeof(Texture2D)) as Texture2D;
            cross = Resources.Load("cross", typeof(Texture2D)) as Texture2D;

            ScriptableObject scriptableObj = this;
            SerializedObject serialObj = new SerializedObject(scriptableObj);
            SerializedProperty serialProp = serialObj.FindProperty("m_scriptableObjData");

        
    
            EditorGUILayout.PropertyField(serialProp, true);
            serialObj.ApplyModifiedProperties();

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
                image  = null;
                GUILayout.BeginHorizontal("box");
                GUILayout.Label(obj.name);
                var tempObj = GameObject.Find(obj.name);
                if(tempObj!= null)
                {
                    GUILayout.Label(tick, GUILayout.MaxWidth(20f), GUILayout.MaxHeight(20f));
                }
                else
                {
                    GUILayout.Label(cross, GUILayout.MaxWidth(20f), GUILayout.MaxHeight(20f));
                }
                if(GUILayout.Button("Validate"))
                {
                    
                    if(tempObj!= null)
                    {
            
                    }
                    else
                    {
                        if(EditorUtility.DisplayDialog("Oops! Not Found!",
                        "Do you want to generate the object in the current scene?", "Yes", "No"))
                        {
                            tempobj = (GameObject)Instantiate(obj, vec3, Quaternion.identity);

                            // TODO:: Figure out a system to spawn this as the child object of the parent.
                            tempobj.name = obj.name;
                            this.Repaint();
                        }
                    }
                }
                GUILayout.EndHorizontal();
            }
        }
    }
}
