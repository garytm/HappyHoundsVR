﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviours : MonoBehaviour {
    WanderScript _wander;
    public CorgiScript _CorgiScript;
    GravityButton gravScript;

    public float timeSinceChange;
    public float timeLimit;
    float limiter = 0;
    float limit;
    public string watsitDoing;

    public int actionNum;
    int animNum;
// Use this for initialization
    void Start () {
        gravScript = GameObject.FindGameObjectWithTag("GravityButton").GetComponent<GravityButton>();
        _CorgiScript = GameObject.FindGameObjectWithTag("Corgi").GetComponent<CorgiScript>();
        _wander = GetComponent<WanderScript>();
        timeLimit = Random.Range(3.5f, 7);
        limit = Random.Range(1, 5);
    }
	
	// Update is called once per frame
	void Update () {
        //print("Grav = " + gravScript.grav);
        timeSinceChange += Time.deltaTime;
        if (timeSinceChange > timeLimit && gravScript.grav)
        {
           timeSinceChange = 0;
           actionNum = Random.Range(1, 3);
        }
        //StartCoroutine(pickAction());
        //print("AN = " + actionNum);
        if (actionNum == 1) // wander 
        {
            
            _CorgiScript.animState = CorgiScript.dogState.Walking;
            _wander.enabled = true;
            _CorgiScript.inMotion = true;
            watsitDoing = "wandering";
        }

        if (actionNum == 2)// RandomAnimation;
        {
            limiter += Time.deltaTime;
            _wander.enabled = false;
            _CorgiScript.inMotion = false;
            _CorgiScript.animState = CorgiScript.dogState.Idle;
            watsitDoing = "Idle Anim";
            if (limiter > limit)
            {
              limiter = 0;
              animNum = Random.Range(1, 3);
            }
            
            _CorgiScript.IdleAnimations(animNum);
        }
	}

    //IEnumerator pickAction()
    //{
    //    yield return new WaitForSeconds(8f);
    //    actionNum = Random.Range(1, 3);
    //}
}
