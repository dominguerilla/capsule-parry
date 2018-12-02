# Capsule Cast Parrying

This ParryableWeapon script allows for animation-specific selective collision detection. It is meant to be used in animated attacks using weapons, and will detect if the attack has been 'parried'. It simulates continuous collision detection for triggers.

![Frame 1](https://raw.githubusercontent.com/dominguerilla/capsule-parry/master/Images/frame1.PNG)
![Frame 2](https://raw.githubusercontent.com/dominguerilla/capsule-parry/master/Images/frame2.PNG)

## Setting up the scene
1. In your weapon, add a ParryableWeapon component. Ensure it has a collider.
    * The original use case was to see if an enemy NPC's attack collided with a player's weapon. In my case, the NPC's sword had a kinematic rigidbody trigger collider, while the player's weapon had a kinematic rigidbody collider (as I was planning to use this in VR).

2. Set the Weapon Start and Weapon End of the ParryableWeapon.
    * These should be the extremities of the parryable surface of the weapon.

3. Set your weapon gameobject layer to 'Parryable'. If you don't have that layer, create it.
    * Anything else that your weapon can be parried by also needs to be on the Parryable layer.

4. Subscribe any listeners to the OnParried() UnityEvent of the ParryableWeapon.
    * This event is invoked if the component detects a collision with a Parryable-layer object between two frames of the attack animation.

## Setting up the animation
1. In the attack animation, choose one keyframe to be the start of the parry window.
    * Add StartParryListen() as an event.

2. Choose one keyframe to be the end of the parry window.
    * Add StopParryListen() as an event.


