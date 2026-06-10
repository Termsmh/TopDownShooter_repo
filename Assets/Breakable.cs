using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField]
    bool MeleeBreakable;
    public void ExploBreak()
    {
        
        Destroy(gameObject);
    }

    public void MeleeBreak()
    {
        if (MeleeBreakable)
        {
            Destroy(gameObject);
        }
    }
}
