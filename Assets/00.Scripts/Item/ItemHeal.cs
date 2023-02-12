using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeal : Item
{
    public override void OnTrigger()
    {
        GameManager.instance.RodDurability += GameManager.instance.MaxRodDurability * 0.15f;
        if (GameManager.instance.RodDurability >= GameManager.instance.MaxRodDurability)
            GameManager.instance.RodDurability = GameManager.instance.MaxRodDurability;
        SoundManager.instance.PlayAudio("healed");
    }
}
