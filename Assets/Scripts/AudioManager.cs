using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;

    public AudioClip MenuTheme, StoryTheme, GameTheme, GameOverTheme;
    public AudioClip FishCollectSound;
    public AudioClip GameOverSound;
    public AudioClip ButtonSound;

    public AudioSource sfxSource;

    //public StartScreen ScreenInfo;
    //public CatControl CatControl;

    public int SceneIndex = 2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayMusic(MenuTheme);
    }

    // Update is called once per frame
    void Update()
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SceneIndex == 2)
        {
            PlayMusic(MenuTheme);
        }

        if (SceneIndex==1)
        {
            PlayMusic(StoryTheme);
        }

        if (SceneIndex == 3)
        {
            PlayMusic(GameTheme);
        }

        //if(CatControl.wasFishCollected == true)
        //{
        //    PlaySFX(FishCollectSound);
        //}

        //if(CatControl.isGameOver == true)
        //{
        //    PlaySFX(GameOverSound);
        //}
        //if(ScreenInfo._wasStartButtonClicked == true)
        //{
        //    PlaySFX(ButtonSound);
        //}

    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip != clip)
        {
            musicSource.Stop();
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
}
