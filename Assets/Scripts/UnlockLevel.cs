using UnityEngine;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{
    public Image imageChild;

    public void UnlockCurrentLevel()
    {
        Destroy(imageChild);
    }
}
