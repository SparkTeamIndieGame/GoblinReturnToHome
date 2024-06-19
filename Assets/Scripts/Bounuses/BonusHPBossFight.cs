using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHPBossFight : MonoBehaviour
{
    private PlayerController playerController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out playerController))
        {
            playerController.AddHealth(10);
            Destroy(this.gameObject);
        }
    }
}
