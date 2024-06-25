using UnityEngine;

public class RodActive : MonoBehaviour
{
    [SerializeField] protected GameObject _helperUI;
    [SerializeField] protected Animator _animator;
    protected bool _active;
    protected bool _wasUsed = false;

   public void ChangeRodState()
    {
        DoorOpen.isFlag = true;
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (_wasUsed == false)
        {
            _helperUI.SetActive(true);
            _active = true;
        }
    }
    public virtual void OnTriggerExit(Collider other)
    {
        _helperUI.SetActive(false);
        _active = false;   
    }

    public void SoundActive()
    {
        AudioSystem.insance._door.Play();
    }
    public virtual void Update()
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
