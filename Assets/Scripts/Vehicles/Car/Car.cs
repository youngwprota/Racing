using UnityEngine;

public class Car : Vehicle
{
    [SerializeField] private PhysicMaterial defaultMaterial;
    [SerializeField] private PhysicMaterial handbrakeMaterial;
    public override void TurnLeft()
    {
        transform.Rotate(0, -turnAngle * Time.deltaTime, 0);
    }

    public override void TurnRight()
    {
        transform.Rotate(0, turnAngle * Time.deltaTime, 0);
    }

    public override void Handbrake()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider col in colliders)
        {
            col.material = handbrakeMaterial;
        }
    }

    public override void ReleaseHandbrake()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider col in colliders)
        {
            col.material = defaultMaterial;
        }
    }
}