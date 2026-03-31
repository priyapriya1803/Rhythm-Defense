using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Condition System")]
    public int maxConditions = 12;
    private int currentConditions = 0;
    float targetFill;

    public TMP_Text conditionText;
    public Image fillImage;

    [Header("Environment")]
    public GameObject betterEnv;
    public GameObject goodEnv;
    public GameObject perfectEnv;

    public Material betterSkybox;
    public Material goodSkybox;
    public Material perfectSkybox;

    public Transform playerTf;

    [Header("Environment Mid Points")]
    public Transform betterMid;
    public Transform goodMid;
    public Transform perfectMid;

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public GameObject perfectPanel;
    public GameObject scorePopup;

    int score = 0;
    GameObject currentEnv;
    bool envChanged = false;

    void Start()
    {
        betterEnv.SetActive(false);
        goodEnv.SetActive(false);
        perfectEnv.SetActive(false);

        UpdateUI();
        UpdateEnvironment();
    }

    void Update()
    {
        fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, targetFill, Time.deltaTime * 5f);
        UpdateColor();
    }

    public void AddCondition()
    {
        if (currentConditions < maxConditions)
        {
            currentConditions++;
            score += 10;

            UpdateUI();
            UpdateColor();
            UpdateEnvironment();

            StartCoroutine(ShowScorePopup("+10"));
        }
    }

    public void HitBomb()
    {
        if (currentConditions > 8)
        {
            currentConditions = 8;
        }
        else if (currentConditions > 4)
        {
            currentConditions = 4;
        }
        else
        {
            currentConditions = 0;
        }

        score = 0;

        UpdateUI();
        UpdateColor();
        UpdateEnvironment(); // ✅ fixed duplicate call removed
    }

    void UpdateUI()
    {
        conditionText.text = currentConditions + " / " + maxConditions;
        targetFill = (float)currentConditions / maxConditions;
        scoreText.text = "Score: " + score;
    }

    void UpdateColor()
    {
        if (currentConditions <= 4)
        {
            fillImage.color = Color.red;
        }
        else if (currentConditions <= 8)
        {
            fillImage.color = Color.yellow;
        }
        else
        {
            fillImage.color = Color.green;
        }
    }

    void UpdateEnvironment()
    {
        if (currentConditions <= 4)
        {
            if (currentEnv != betterEnv)
                ApplyEnvironment(betterEnv, betterSkybox);

            if (envChanged && betterMid != null)
            {
                TeleportPlayer(betterMid.position);
                envChanged = false;
            }
        }
        else if (currentConditions <= 8)
        {
            if (currentEnv != goodEnv)
            {
                ApplyEnvironment(goodEnv, goodSkybox);
                StartCoroutine(ShowPerfectPanel());
            }

            if (envChanged && goodMid != null)
            {
                TeleportPlayer(goodMid.position);
                envChanged = false;
            }
        }
        else
        {
            if (currentEnv != perfectEnv)
            {
                ApplyEnvironment(perfectEnv, perfectSkybox);
                StartCoroutine(ShowPerfectPanel());
            }

            if (envChanged && perfectMid != null)
            {
                TeleportPlayer(perfectMid.position);
                envChanged = false;
            }
        }
    }

    void ApplyEnvironment(GameObject env, Material skybox)
    {
        if (env == null) return;

        // Disable all environments
        betterEnv.SetActive(false);
        goodEnv.SetActive(false);
        perfectEnv.SetActive(false);

        Vector3 envPos = env.transform.position;

        // Follow player XZ
        env.transform.position = new Vector3(
            playerTf.position.x,
            envPos.y,
            playerTf.position.z
        );

        env.SetActive(true);
        RenderSettings.skybox = skybox;

        currentEnv = env;
        envChanged = true; // ✅ important
    }

    void TeleportPlayer(Vector3 targetPos)
    {
        // Safe teleport (prevents physics issues)
        CharacterController cc = playerTf.GetComponent<CharacterController>();

        if (cc != null)
        {
            cc.enabled = false;
            playerTf.position = targetPos;
            cc.enabled = true;
        }
        else
        {
            playerTf.position = targetPos;
        }
    }

    IEnumerator ShowPerfectPanel()
    {
        perfectPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        perfectPanel.SetActive(false);
    }

    IEnumerator ShowScorePopup(string message)
    {
        scorePopup.SetActive(true);
        scorePopup.GetComponent<TextMeshProUGUI>().text = message;
        yield return new WaitForSeconds(1f);
        scorePopup.SetActive(false);
    }
}