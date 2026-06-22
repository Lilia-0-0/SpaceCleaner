using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject trashPrefab;
    public GameObject crystalPrefab;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI statusText;

    private int score = 0;
    private float timeLeft = 30f;
    private bool isGameActive = true;

    void Start()
    {

        InvokeRepeating("SpawnObject", 0f, 1.5f);
    }

    void Update()
    {
        if (!isGameActive) return;


        timeLeft -= Time.deltaTime;
        timerText.text = Mathf.Ceil(timeLeft).ToString();

        if (timeLeft <= 0)
        {
            isGameActive = false;
            statusText.text = "Игра окончена! Счет: " + score;

            CancelInvoke();
        }
    }

    void SpawnObject()
    {
        if (!isGameActive) return;


        float chance = Random.value;
        GameObject objToSpawn;
        if (chance < 0.7f)
            objToSpawn = trashPrefab;
        else
            objToSpawn = crystalPrefab;


        Vector3 spawnPos = new Vector3(Random.Range(-9f, 9f), Random.Range(-5f, 5f), 0);
        Instantiate(objToSpawn, spawnPos, Quaternion.identity);
    }

    public void HandleClick(bool isTrash, int value)
    {
        if (!isGameActive) return;

        if (isTrash)
        {
            score += value;
            statusText.text = "Уничтожен мусор! +" + value;
        }
        else
        {
            score -= value;
            statusText.text = "Ой! Это кристалл! -" + value;
        }
        scoreText.text = score.ToString();
    }
}