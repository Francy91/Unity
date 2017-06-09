using UnityEngine;
using UnityEditor;
using System.Collections;

public class AnimazioneCtrl : MonoBehaviour {
    Animator anim;
    //codifichiamo il nome dello stato a cui passare quando si preme 
    // il tasto di salto(lo spazio)
    int hashJump = Animator.StringToHash("jump");
    int hashRun = Animator.StringToHash("run");
    int hashWalk = Animator.StringToHash("walk"); 
    //int hashStateCurrent = Animator.StringToHash("Base Layer.run"); //hash_nome_stato_corre
    float s = 0;
    private bool desc;
    // Use this for initialization
    void Start () { 
        //punterà agli stati
        anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
        
        float movimento = Input.GetAxis("Vertical");
        AnimatorStateInfo infoCurrentState = anim.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKeyDown(KeyCode.Space) )
            anim.SetTrigger(hashJump);
        if (Input.GetKeyDown(KeyCode.UpArrow))
            anim.SetTrigger(hashWalk);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            anim.SetTrigger(hashRun);
          if (!desc)
              s += (float) 0.001;
          else
              s -= (float) 0.001;
        if (s > 2)
            desc = true;
        else
            if (s < 0)
                desc = false;
       anim.SetFloat("speed", s);
    }
}
