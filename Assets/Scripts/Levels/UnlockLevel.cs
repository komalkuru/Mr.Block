using UnityEngine;

public class UnlockLevel : MonoBehaviour
{
    public void UnlockCurrentLevel()
    {
        gameObject.SetActive(false);
    }
}
