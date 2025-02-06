using System.Reflection.Emit;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour, IVehicle
{
    public float Speed;
    public float turnAngle;
    protected Rigidbody rb;
    public float HorizontalMovement { get; set; }
    public float VerticalMovement { get; set; }
    public int steerKostyl;
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError($"Rigidbody отсутствует на объекте {gameObject.name}. Убедитесь, что он добавлен.");
        }
        else
        {
            Debug.Log($"Rigidbody найден: {rb.name}");
        }
    }

    public virtual void GoForward()
    {
        rb.AddForce(rb.velocity / 2 + transform.forward * Speed, ForceMode.Acceleration);
    }


    public virtual void GoBackward()
    {
        rb.AddForce(rb.velocity / 2 + -1 * Speed * transform.forward, ForceMode.Acceleration);
    }

    public virtual void Stop()
    {
        rb.AddForce(rb.velocity - transform.forward * Time.deltaTime, ForceMode.Acceleration);
    }

    public abstract void TurnLeft();
    public abstract void TurnRight();
    public abstract void Handbrake();
    public abstract void ReleaseHandbrake();

} 