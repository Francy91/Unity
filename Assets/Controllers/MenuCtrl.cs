using UnityEngine;
using System.Collections;

public class MenuCtrl : MonoBehaviour {
    public GUIStyle buttonStyle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 250, 500, 500));
        GUILayout.Button("Nuovo Partita");
        GUILayout.Button("Nuovo Partita");
        GUILayout.Button("Nuovo Partita");
        GUILayout.EndArea();
    }
}
