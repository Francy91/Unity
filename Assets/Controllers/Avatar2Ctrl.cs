using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Avatar2Ctrl : MonoBehaviour {
    Animator anim;
   // GameObject prefab = Resources.Load<GameObject>("Sphere");
    int hashJump = Animator.StringToHash("jump");
    int hashRun = Animator.StringToHash("run");
    int hashWalk = Animator.StringToHash("walk");
    Vector3 muovi;
    //private List<GameObject> prefabs;
    private Object[] prefabs;
    public float speed;
    GameObject newSphere;
    public Button yourButton;


    // Use this for initialization
    void Start () {
        //newSphere = Instantiate(Resources.Load("Sphere", typeof(GameObject))) as GameObject;
        anim = GetComponent<Animator>();
        Button btn = yourButton.GetComponent<Button>();
        prefabs = Resources.LoadAll("", typeof(GameObject));
        
        Debug.Log("You have start the button!: " + btn.name);
        if (btn.name.Equals("Cube"))
        {
            Debug.Log("IF:You have start the button!: " + btn.name);
            btn.onClick.AddListener(() => TaskOnClick("Cube"));

        }
        else if(btn.name.Equals("Sphere"))
        {
            Debug.Log("ELSE:You have start the button!: " + btn.name);
            btn.onClick.AddListener(() => TaskOnClick("Sphere"));
        }
        //btn.onClick.AddListener(TaskOnClick("Sphere"));
        // Debug.Log("You have start the button!");

        //newSphere.AddComponent(typeof(Rigidbody));
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            anim.SetTrigger(hashJump);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(create(Instantiate(Resources.Load("Sphere", typeof(GameObject))) as GameObject));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
            anim.SetTrigger(hashWalk);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            anim.SetTrigger(hashRun);

    }

    IEnumerator create(GameObject newSphere)
    {
        //newSphere = Instantiate(Resources.Load("Sphere", typeof(GameObject))) as GameObject;
        newSphere.AddComponent(typeof(Rigidbody));
        while (!newSphere.Equals(null))
        {
            float speed = Random.Range(0.7f, 1.3f);
            // s = GameObject.CreatePrimitive((GameObject)Instantiate(prefab));
            //Rigidbody.FindObjectsOfType rb;
            //newSphere.AddComponent(typeof(Rigidbody));
            muovi = new Vector3(0.1f, 0f, 0f);
            
            newSphere.transform.position += muovi * speed * Time.deltaTime;
            Destroy(newSphere, 5);
            yield return null;
            //if (newSphere.Equals(null))
            //    break;
            //break;
            //StartCoroutine(destroy(newSphere,5));
        }
    }

    void TaskOnClick(string name)
    {
        StartCoroutine(create(Instantiate(Resources.Load(name, typeof(GameObject))) as GameObject));
        Debug.Log("You have clicked the button!" + name);
    }

    private void OnGUI()
    {

    int index = 0;
        GUI.Box(new Rect(10, 10, 100, 30 + 2 * 30), "Loader Menu");
        //GUILayout.BeginArea(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 250, 500, 500));
        //Debug.Log("lenght" + prefabs.Length);
        foreach (var p in prefabs)
        {
            //Debug.Log(p.name);
            if (GUI.Button(new Rect(20, 40 + index * 30, 80, 20), p.name))
            {
               // createPrefabs(p.GetType());
                GameObject monster = (GameObject)Instantiate(p);
                StartCoroutine(create(monster));
                // createPrefabs(p.GetTypGe());
            }
            //GUI.Button(new Rect(20, 40 + index * 30, 80, 20), p.name);
            index++;
        }
        
        //GUILayout.Button("Nuovo Partita");
        //GUILayout.Button("Nuovo Partita");
        //GUILayout.Button("Nuovo Partita");
        //GUILayout.EndArea();
    }


}
