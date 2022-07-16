using UnityEngine;

public class UnlockLevel : MonoBehaviour
{
    [SerializeField] private GameObject lockedObject;
    public void UnlockCurrentLevel()
    {
        Destroy(lockedObject);
    }
}
