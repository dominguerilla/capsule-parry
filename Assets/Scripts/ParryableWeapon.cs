using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParryableWeapon : MonoBehaviour {
    public UnityEvent OnParried;
    public Transform weaponStart, weaponEnd;

    [SerializeField]
    float capsuleRadius = 0.25f;

    bool isParryable; // true during the parry window of the animation
    bool wasParried; // true if this weapon was parried in this frame
    Vector3 lastPosition;

	void Start () {
		OnParried = new UnityEvent();
	}
	
    // start listening for a parry.
    // weapons can be parried only once per 'listen'.
    // be sure to call StopParryListen() to reset the parry counter.
    public void StartParryListen(){
        isParryable = true;
        lastPosition = this.transform.position;
    }

    public void StopParryListen(){
        isParryable = false;
        wasParried = false;
    }

    private void Update() {
        if(isParryable){
            CheckForParry();
        }
    }

    private void FixedUpdate() {
        lastPosition = this.transform.position;
    }

    void CheckForParry(){
        int layerMask = LayerMask.GetMask("Parryable");
        float distance = Vector3.Distance(this.transform.position, lastPosition);
        Vector3 direction = this.transform.position - lastPosition;
        RaycastHit hit;

        // for debug purposes
        Vector3 midpoint = (weaponStart.position + weaponEnd.position) / 2;
        Debug.DrawRay(midpoint, -direction, Color.red);

        if (Physics.CapsuleCast(weaponStart.position, weaponEnd.position, capsuleRadius, -direction, out hit,distance, layerMask, QueryTriggerInteraction.Collide)){
            if(!wasParried){
                OnParried.Invoke();
                wasParried = true;
            }
        }

    }
}
