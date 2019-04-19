using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    // Check to see if we're about to be destroyed.
    private static bool m_ShuttingDown = false;
    private static object m_Lock = new object();

    /// <summary>
    /// Access singleton instance through this propriety.
    /// </summary>
    public static GameManager Instance
    {
        get
        {
            if (m_ShuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(GameManager) +
                    "' already destroyed. Returning null.");
                return null;
            }

            lock (m_Lock)
            {
                if (_instance == null)
                {
                    // Search for existing instance.
                    _instance = (GameManager)FindObjectOfType(typeof(GameManager));

                    // Create new instance if one doesn't already exist.
                    if (_instance == null)
                    {
                        // Need to create a new GameObject to attach the singleton to.
                        var gameManagerObject = new GameObject();
                        _instance = gameManagerObject.AddComponent<GameManager>();
                        gameManagerObject.name = typeof(GameManager).ToString() + " (Singleton)";

                        // Make instance persistent.
                        DontDestroyOnLoad(gameManagerObject);
                    }
                }

                return _instance;
            }
        }
    }


    [SerializeField] CircleStageManager circleManager;
    float circleIdleTimeEnd = 0;
    bool changeCircle = false;

    [SerializeField] List<PlayerController> players;



    public CircleStageManager GetCircleManager
    {
        get
        {
            return circleManager;
        }
    }

    public void changeCircleStage(CircleStage stage)
    {
        circleManager.SetState(stage);
    }
    
    /// <summary>
    /// bigger tahn 0 will set to next stage, smaller than 0 will set to previous stage
    /// 0 stage won't stage.
    /// </summary>
    /// <param name="next"></param>
    public void changeCircleStage(int next)
    {
        if (next > 0)
            circleManager.setNextStage();
        else if(next < 0)
            circleManager.setPreviousStage();
    }

    public void updateCircle()
    {
        if(changeCircle && Time.time > circleIdleTimeEnd)
        {
            changeCircleStage(1);
            changeCircle = false;
        }
    }

    private void Start()
    {
        startCircleIdleState();
    }



    private void Update()
    {
        updateCircle();
    }

    public void startCircleIdleState()
    {
        if(circleManager != null)
        {
            circleIdleTimeEnd = Time.time + circleManager.CurrentState.IdleTime;
            changeCircle = true;
        }
        else
        {
            Debug.Log("GameManager needs circleManager.");
        }
    }


    public void OnPlayerDeath(PlayerController player)
    {
        Debug.Log("Player" + player + " died!");
        player.gameObject.SetActive(false);
    }


    private void OnApplicationQuit()
    {
        m_ShuttingDown = true;
    }


    private void OnDestroy()
    {
        m_ShuttingDown = true;
    }
}
