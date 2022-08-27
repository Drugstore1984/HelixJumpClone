using UnityEngine;

public class PlatformDestruction : MonoBehaviour
{
    [SerializeField] private GameObject[] _sectors;
    private AudioPlayer _audioPlayer;
    private ParticleSystem _particleSystem;
    private void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _particleSystem = GetComponent<ParticleSystem>();
    }
    public void DestructPlatform()
    {
        foreach (GameObject sector in _sectors)
        {
            sector.GetComponent<MeshCollider>().enabled = false;
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        BoxCollider collider = rb.GetComponent<BoxCollider>();
        _particleSystem.Play();
        collider.enabled = false;
        rb.isKinematic = false;
        _audioPlayer.Play("Break");
        Invoke("Destroy", 3f);
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
