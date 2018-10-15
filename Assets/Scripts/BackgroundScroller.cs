using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    void OnBecameInvisible()
    {
        transform.position = new Vector3(transform.position.x + 219, 10, 0);
    }
}
