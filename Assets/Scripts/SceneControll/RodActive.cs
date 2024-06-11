using UnityEngine;

public class RodActive : MonoBehaviour
{
    [SerializeField] private GameObject _helperUI;
    [SerializeField] private Animator _animator;
    private bool _active;
    private bool _wasUsed = false;
   public void ChangeRodState()
    {
        DoorOpen.isFlag = true;
    }
    public void OnTriggerEnter(Collider other)
    {
        print("gopa");
        if (_wasUsed == false)
        {
            _helperUI.SetActive(true);
            _active = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        
        
        _helperUI.SetActive(false);
        _active = false;
        
        
    }

    public void SoundActive()
    {
        AudioSystem.insance._door.Play();
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.E) && _active)
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
