using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInvulnerable : Item
{
    public override void OnTrigger()
    {
        FishingManager.instance.invulnerableTimer = 5;
        SoundManager.instance.PlayAudio("creativemod");
    }
}
