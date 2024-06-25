using UnityEngine;

public class StoneBig : MonoBehaviour
{
    private float speed, rotationSpeed;
    private Transform destroyPoint;

    public void Construct(float speed, float rotationSpeed, Transform destroyPoint)
    {
        this.speed = speed;
        this.rotationSpeed = rotationSpeed;
        this.destroyPoint = destroyPoint;
    }

    private void FixedUpdate()
    {
        Rotation();

        if (transform.position.x > destroyPoint.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, destroyPoint.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    private void Rotation()
    {
        transform.Rotate(new Vector3(0, 0, 1 * rotationSpeed));
    }

}
