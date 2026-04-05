using UnityEngine;

public class LaserAim : MonoBehaviour
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private LayerMask hitableLayers;
    [SerializeField] private LineRenderer laserEffect;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(muzzle.position, muzzle.up, 100, hitableLayers);

        Vector3 rayEndPoint;
        if (hit.collider == null)
        {
            rayEndPoint = muzzle.position + muzzle.up * 100;
        }
        else
        {
            rayEndPoint = hit.point;
        }

        Vector3 rayEndPointLocal = muzzle.InverseTransformPoint(rayEndPoint);
        laserEffect.SetPosition(1, rayEndPointLocal);
    }
}
