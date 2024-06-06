using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public static bool isFlag = false;
    [SerializeField] private Animator _animator;

    private void FixedUpdate()
    {
        if (isFlag)
        {
            _animator.SetTrigger("ActiveRod");
        }
    }
}
