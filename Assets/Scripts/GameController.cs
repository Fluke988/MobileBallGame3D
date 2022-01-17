using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    private static GameController _instance = null;
    
    [SerializeField] EGameScreens ActiveScreen;

    [SerializeField] GameObject[] gameScreens;

    //public EDiceTag diceRollColorTag;

    //public int rollDiceCount = 0;

    //public int diceCount = 0;

    //public int breakCount = 0;

    //public UnityAction SpawnBlock;

    //public ELevels Level;     

    //[SerializeField] public Animator animref = null;
    //[SerializeField] public GameObject animRef = null;

    public  List<GameObject> list = new List<GameObject>();
    void Awake()
    {
        
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //AdManager.Instance.ShowBannerAd();
        Init();
    }

    void Init()
    {
        //SoundManager.Instance.PlayBackgroundMusic(EGameMusic.MUSIC_MENU);
        SwitchScreen(ActiveScreen);
        
    }

    public static GameController Instance
    {
        get { return _instance; }
        private set { _instance = value; }
    }

    public void SwitchScreen(EGameScreens val)
    {
        for (int i = 0; i < gameScreens.Length; i++)
        {
            if (i == (int)val)
            {
                gameScreens[i].SetActive(true);
            }
            else
            {
                gameScreens[i].SetActive(false);
            }
        }
    }

    
}


