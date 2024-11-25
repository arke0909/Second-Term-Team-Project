using UnityEngine;
public enum CheckType
{
    Ray, Overlap, None
}

public  class GimmickDetector : MonoBehaviour
{
    [SerializeField] private CheckType _checkType;
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private Vector2 _center = default;

    public bool CheckPlayer()
    {
        switch(_checkType)
        {
            case CheckType.Overlap:
                Collider2D overlapCheckPlayer = Physics2D.OverlapCircle(_center, _range, _whatIsPlayer);
                return overlapCheckPlayer;

            case CheckType.Ray:
                RaycastHit2D rayCheckPlayer = Physics2D.Raycast(_center, Vector2.up, _range, _whatIsPlayer); 
                return rayCheckPlayer;

            case CheckType.None:
                return true;
            default:
                return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        switch (_checkType)
        {
            case CheckType.Overlap:
                Gizmos.DrawWireSphere(_center, _range);
                break;
            case CheckType.Ray:
                Gizmos.DrawRay(_center, new Vector2(0, _range));
                break;
        }
    }
}
