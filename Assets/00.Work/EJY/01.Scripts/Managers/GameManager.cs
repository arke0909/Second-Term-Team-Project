using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Monosingleton<GameManager>
{
    [Header("Å¬¸®¾î È½¼ö")]
    [SerializeField] private int _maxClearCount = 0;

    public int ClearCount { get; private set; } = 0;

    public Player player { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        player = FindObjectOfType<Player>().GetComponent<Player>();

        if (ClearCount >= _maxClearCount)
            Clear();
    }

    public void CountUp()
    {
        ClearCount++;
    }

    public void CountReset()
    {
        ClearCount = 0;
    }

    public void Clear()
    {
        SceneManager.LoadScene("Clear");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
