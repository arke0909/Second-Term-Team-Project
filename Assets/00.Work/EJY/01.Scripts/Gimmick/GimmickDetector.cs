using UnityEngine;
public enum CheckType
{
    Ray, Overlap
}

public  class GimmickDetector : MonoBehaviour
{
    [SerializeField] private CheckType _checkType;
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _whatIsPlayer;

    public bool CheckPlayer()
    {
        switch(_checkType)
        {
            case CheckType.Overlap:
                Collider2D overlapCheckPlayer = Physics2D.OverlapCircle(transform.position, _range, _whatIsPlayer);
                return overlapCheckPlayer;

            case CheckType.Ray:
                RaycastHit2D rayCheckPlayer = Physics2D.Raycast(transform.position, Vector2.up, _range, _whatIsPlayer);
                return rayCheckPlayer;

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
                Gizmos.DrawWireSphere(transform.position, _range);
                break;
            case CheckType.Ray:
                Gizmos.DrawRay(transform.position, Vector2.up);
                break;
        }
    }
}
