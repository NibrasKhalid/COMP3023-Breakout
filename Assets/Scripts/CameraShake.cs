using UnityEngine;
using Unity.Cinemachine;

public class CameraShake : MonoBehaviour
{
   public static CameraShake instance;
   public float shake = 1f;

   private CinemachineImpulseSource impulseSource;

   private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Shake()
    {
        if (impulseSource != null)
        {
            impulseSource.GenerateImpulseWithForce(shake);
        }    
    }
}
