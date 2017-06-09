using UnityEngine;
using System.Collections;
using UnityEditor;

 
public class MyMenu : EditorWindow
{
    GameObject SelectedObject;
    float posX = 0;
    float posY = 0;
    float posZ = 0;
    string myString = "";

    [MenuItem("MyMenu/windows")]

    private static void ShowWindow()
    {
        MyMenu windows = EditorWindow.GetWindow(typeof(MyMenu)) as MyMenu;
        Debug.Log("Hello world!");
        windows.initGui();
    }

    void initGui()
    {
        SelectedObject = Selection.activeGameObject;
        posX = SelectedObject.transform.position.x;
        posY = SelectedObject.transform.position.y;
        posZ = SelectedObject.transform.position.z;
    }

    void OnGUI()
    {
        if (SelectedObject != Selection.activeGameObject)
            initGui();
        myString = SelectedObject.name;

        EditorGUILayout.LabelField("Nome oggetto: " + myString);
        GUILayout.BeginVertical("box");
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("xPos: " + SelectedObject.transform.position.x);
        posX = EditorGUILayout.FloatField(posX);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("yPos: " + SelectedObject.transform.position.y);
        posY = EditorGUILayout.FloatField(posY);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("zPos: " + SelectedObject.transform.position.z);
        posZ = EditorGUILayout.FloatField(posZ);

        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        if (GUILayout.Button("sposta"))
        {
            Debug.Log("premuto");
            SelectedObject.transform.position = new Vector3(posX, posY, posZ);
        }
    }
}