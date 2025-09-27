using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{

    [SerializeField]
    private Button startButton;

    public bool _wasStartButtonClicked = false;
    

    public Image CinemaBackground;

    public Image Cinema1;
    public Image Cinema2;
    public Image Cinema3;

    public Image Story1;
    public Image Story2;
    public Image Story3;
    public Image Story4;

    public GameObject animaticfolder;

    public GameObject StarGameFolder;

    //public bool _didStartMenuClosed = false; // end of startscreen
    public bool _didAnimaticEnd = false; //end of animatic

    public AudioManager AudioManager;


    private void Awake()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);

        //RestartButton.onClick.AddListener(OnRestartButtonClicked);

        //BackToMenuButton.onClick.AddListener(OnBackToMenuButtonClicked);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.SceneIndex = 2;

        if (_wasStartButtonClicked)
        {
            Debug.Log("button clicked!");

            StarGameFolder.SetActive(false);
            StartCoroutine(Animatic());
        }

        if(_didAnimaticEnd == true)
        {
            SceneManager.LoadScene(3);
            RestartMenu();
        }

        

    }

    private void RestartMenu()
    {
        _didAnimaticEnd = false;
        StarGameFolder.gameObject.SetActive(true);
    }


    private void OnStartButtonClicked()
    {
        _wasStartButtonClicked = true;
    }

    

    IEnumerator Animatic()
    {
        CinemaBackground.gameObject.SetActive(true);
        Cinema1.gameObject.SetActive(true);
        StarGameFolder.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Cinema2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Cinema3.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        Story1.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        Story2.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        Story3.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        Story4.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);

        
        animaticfolder.gameObject.SetActive(false);
        _didAnimaticEnd = true;

        

    }


}
