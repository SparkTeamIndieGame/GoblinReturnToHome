using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodActiveBossFight : RodActive
{
    [SerializeField] private GameObject _panelBlock;

    public override void OnTriggerEnter(Collider other)
    {
        if (_wasUsed == false)
        {
            if(!NeedCountEnemy.ContinueGame)
            {
                _panelBlock.SetActive(true);
            }

            else
            {
                _helperUI.SetActive(true);
                _active = true;
            }
        }

    }

    public override void OnTriggerExit(Collider other)
    {
        if (_wasUsed == false)
        {
            if (!NeedCountEnemy.ContinueGame)
            {
                _panelBlock.SetActive(false);
            }

            else
            {
                _helperUI.SetActive(false);
                _active = false;
            }
        }


    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _active)
        {
            _animator.SetTrigger("ChangeRodState");
            _wasUsed = true;
            if (_helperUI.gameObject.activeSelf == true)
            {
                _helperUI.SetActive(false);
            }
        }
    }
}
