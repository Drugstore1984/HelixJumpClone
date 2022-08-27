using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.CurrentPlatform = this;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(GetComponent<PlatformDestruction>() != null)
        gameObject.GetComponent<PlatformDestruction>().DestructPlatform();
    }
}
