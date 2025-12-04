using UnityEngine;
using System.Collections;

public class BossEffe : MonoBehaviour
{
    Camera camera;

    void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    IEnumerator BossEffect()
    {
        Time.timeScale = 0;

        while (camera.orthographicSize < 8)
        {
            camera.orthographicSize += Time.unscaledDeltaTime * 3;
            yield return null;
        }
        if (camera.orthographicSize > 8)
            camera.orthographicSize = 8;
        Time.timeScale = 1;
        Destroy(gameObject);
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>()){
            StartCoroutine(BossEffect());
        }
    }

}
