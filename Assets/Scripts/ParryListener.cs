using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryListener : MonoBehaviour {

    public ParryableWeapon weapon;

	void Start () {
	    weapon.OnParried.AddListener(OnParried);
	}

    public void OnParried(){
        Debug.Log("Weapon parried!");
    }

    public void StartParryListen(){
        weapon.StartParryListen();
    }

    public void StopParryListen(){
        weapon.StopParryListen();
    }
}
