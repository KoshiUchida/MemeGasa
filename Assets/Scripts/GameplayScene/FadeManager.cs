using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;

    private void Start()
    {
        fadeImage.color = new Color(0, 0, 0, 0);
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void FadeOutAndRespawn()
    {
        StartCoroutine(FadeCoroutine());
    }

    private IEnumerator FadeCoroutine()
    {
        // フェードアウト
        yield return StartCoroutine(Fade(0f, 1f));

        //オブジェクトリセット
        RespawnManager.Instance.ResetAll();

        // プレイヤー復活
        RespawnManager.Instance.RespawnPlayer();
        RespawnManager.Instance.player.GetComponent<DeadManager>().Revive();

        // フェードイン
        yield return StartCoroutine(Fade(1f, 0f));
    }

    private IEnumerator Fade(float start, float end)
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(start, end, t / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}

