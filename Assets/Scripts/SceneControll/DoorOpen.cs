using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public static bool isFlag;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        isFlag = false;
    }
    private void FixedUpdate()
    {
        if (isFlag)
        {
            _animator.SetTrigger("ActiveRod");
        }
    }
}
