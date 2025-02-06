using UnityEngine;

public interface IVehicle : IMovable
{
    void TurnLeft();
    void TurnRight();
    void Handbrake();
    void ReleaseHandbrake();
}