using UnityEngine;

public class Sector : MonoBehaviour
{
    [SerializeField] private Material _goodMaterial;
    [SerializeField] private Material _badMaterial;
    [SerializeField] private Material _finishMaterial;
    public enum SectorStatus { Good, Bad, Finish }
    [SerializeField] private SectorStatus _status;
    public SectorStatus Status { get { return _status; } }

    private void Awake()
    {
        SetSectorStatus();
    }
    private void OnValidate()
    {
        SetSectorStatus();
    }
    private void SetSectorStatus()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        switch (_status)
        {
            case SectorStatus.Good:
                sectorRenderer.material = _goodMaterial;
                break;
            case SectorStatus.Bad:
                sectorRenderer.material = _badMaterial;
                break;
            case SectorStatus.Finish:
                sectorRenderer.material = _finishMaterial;
                break;
            default:
                sectorRenderer.material = _goodMaterial;
                break;
        }
    }
}
