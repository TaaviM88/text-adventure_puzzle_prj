using UnityEngine;

public class LevenTransition : MonoBehaviour
{
    public void OnFadeComplete()
    {
        GameManager.Instance.LoadNextScene();
    }
}
