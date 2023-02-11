using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodMoveButton : MonoBehaviour
{
    [SerializeField] private FishingRod _rod;
    private bool _isLeftHold = false;
    private bool _isRightHold = false;

    public void OnLeftEnter() {
        _isLeftHold = true;
    }

    public void OnRightEnter() {
        _isRightHold = true;
    }

    public void OnLeftExit() {
        _isLeftHold = false;
    }

    public void OnRightExit() {
        _isRightHold = false;
    }

    private void Update() {
        if(_isLeftHold) _rod.MoveHorizontal(false);
        if(_isRightHold) _rod.MoveHorizontal(true);
    }
}
