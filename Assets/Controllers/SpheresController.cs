using UnityEngine;
using System.Collections;
public class SpheresController: MonoBehaviour {
    GameObject s;
	// Use this for initialization
	void Start () {
        StartCoroutine(create(3));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator create(float time)
    {
        while (true)
        {
            s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //Rigidbody.FindObjectsOfType rb;
            s.AddComponent(typeof(Rigidbody));
            s.transform.position.Set((float)Random.Range((int)-10, (int)10), (float)5, (float)0);
            yield return new WaitForSeconds(time);
        }
    }
}
