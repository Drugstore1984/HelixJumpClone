using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _bounceSpeed;
    Rigidbody _rb;
    public Platform CurrentPlatform;
    [SerializeField] private Game _game;
    private AudioPlayer _audioPlayer;
    private Material _death;
    private bool _isDead = false;
    [Range(0f, 1f)]
    private float _smoothDeath;
    [SerializeField] private float _fadeTime;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _death = gameObject.GetComponent<Renderer>().material;
        _smoothDeath = _death.GetFloat("_Death");
        _game = FindObjectOfType<Game>();
    }
    private void FixedUpdate()
    {
        PlayerShaderDie();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Sector sector = collision.gameObject.GetComponentInChildren<Sector>();
  
        switch (sector.Status)
        {
            case Sector.SectorStatus.Good:
                
                Vector3 normal = collision.GetContact(0).normal.normalized;

                float dot = Vector3.Dot(normal, Vector3.up);
      
                if (dot > 0.8f)
                {
                    _rb.velocity = new Vector3(0, _bounceSpeed, 0);
                    _audioPlayer.Play("Bounce");
                }
                break;
            case Sector.SectorStatus.Bad:
                _game.OnPlayerDied();
                PlayerStop();
                ParticleStop();
                _isDead = true;
                break;
            case Sector.SectorStatus.Finish:

                PlayerStop();
                _game.OnPlayerFinish();
                break;
            default:
                break;
        }
    }
    private void PlayerStop()
    {
        _rb.constraints = RigidbodyConstraints.FreezePositionY;
    }
    private void PlayerShaderDie()
    {
        if (_isDead)
        {
            _smoothDeath -= _fadeTime * Time.deltaTime;
            _death.SetFloat("_Death", _smoothDeath);
        }
    }
    private void ParticleStop()
    {
        gameObject.GetComponentInChildren<ParticleSystem>().gameObject.SetActive(false);
    }
}
