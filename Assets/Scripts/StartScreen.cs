using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{

    [SerializeField]
    private Button startButton;

    private bool _wasStartButtonClicked = false;

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

    public bool _didStartMenuClosed = false;
    public bool _didAnimaticEnd = false;
    

    private void Awake()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_wasStartButtonClicked)
        {
            Debug.Log("button clicked!");
            _didStartMenuClosed = true;
            StartCoroutine(Animatic());
        }
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
