using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDouble : Item
{
    public override void OnTrigger()
    {
        FishingManager.instance.doubleScoreTimer = 7;
        SoundManager.instance.PlayAudio("doublepoint");
    }
}
