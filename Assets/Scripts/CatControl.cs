using NUnit;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatControl : MonoBehaviour
{
    List<Collider> TriggerList = new List<Collider>();
    //ad to extend
    public TextMeshProUGUI ScoreTMP;
    public int Score;
    public float CurrentSpeed = 0.5f;

    [SerializeField]
    private GameObject CatBody;
    [SerializeField]
    private GameObject CatHead;
    [SerializeField]
    private GameObject CatWhole;

    [SerializeField]
    private GameObject PosForHead;
    [SerializeField]
    private GameObject ParentForHead;

    private readonly float _stretchRate = 100f;
    private float _verticalStretch;

    private float _horizontalStretch;

    private readonly float _XLimit = 1400;
    private readonly float _YLimit = 850;

    private readonly float _XLimit2 = 15000;
    private readonly float _YLimit2 = 15000;

    //[SerializeField]
    private readonly float _jumpDestinationPos = 13f;

    private Vector3 _catOriginalPos;
    private Vector3 _catJumpPos;

    private float timeElapsed;
    private readonly float lerpDuration = 1f;

    private bool _isCatJumping = false;
    public float hangTime = 2f;

    private bool prepareForChange = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _verticalStretch = CatBody.transform.localScale.y;

        ParentForHead.transform.position = PosForHead.transform.position;
        CatHead.transform.SetParent(ParentForHead.transform);

        _horizontalStretch = CatBody.transform.localScale.x;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //jump destinations

        //original Y0 Pos
        _catOriginalPos = new Vector3(CatWhole.transform.position.x,
            0, CatWhole.transform.position.z);

        //jump destination of Y
        _catJumpPos = new Vector3(CatWhole.transform.position.x,
            _jumpDestinationPos, CatWhole.transform.position.z);



        //Scale for chonk size change
        CatBody.transform.localScale = new Vector3(_horizontalStretch,
                 _verticalStretch, CatBody.transform.localScale.z);

        //Pos for ears and face
        ParentForHead.transform.position = PosForHead.transform.position;

        //YPos for jumping
        //CatWhole.transform.position = _catOriginalPos;

        StretchCat();
        //CatJump();

        timeElapsed += Time.deltaTime;
        float precComplete = timeElapsed / lerpDuration;

        //CatWhole.transform.position = Vector3.Lerp(_catOriginalPos, _catJumpPos, timeElapsed / lerpDuration);

        if (!_isCatJumping && Input.GetKeyDown(KeyCode.Space))
        {
            _isCatJumping = true;
            timeElapsed = 0f;    // reset timer for the jump
        }

        // perform jump each frame while active
        if (_isCatJumping)
        {
            JumpingCat();
        }

        ScoreTMP.text = Score.ToString();

        //if (Score == 0)
        //{
        //    hangTime = 2f;
        //}

        //Debug.Log(CurrentSpeed);

        CurrentSpeed = 0.05f + (0.01f*Score);
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.gameObject.GetComponent<ObstacleMove>().Speed = CurrentSpeed;
        }

        hangTime = 2f - (0.01f * Score);
    }

    private void JumpingCat()
    {
        //_isCatJumping = true;

        //if (_spacePressed == true)
        //{
        //    CatWhole.transform.position = Vector3.Lerp(_catOriginalPos, _catJumpPos, timeElapsed / lerpDuration);
        //}
        //timeElapsed = 0;

        //_timer += Time.deltaTime;
        //if(_timer >= 5)
        //{
        //    CatWhole.transform.position = Vector3.Lerp(_catJumpPos, _catOriginalPos, timeElapsed / lerpDuration);
        //}


        timeElapsed += Time.deltaTime;

        // Phase 1: ascend
        if (timeElapsed <= lerpDuration)
        {
            float t = Mathf.Clamp01(timeElapsed / lerpDuration);
            CatWhole.transform.position = Vector3.Lerp(_catOriginalPos, _catJumpPos, t);
            return;
        }

        // Phase 2: hang at top
        if (timeElapsed <= lerpDuration + hangTime)
        {
            CatWhole.transform.position = _catJumpPos;
            return;
        }

        // Phase 3: descend
        float descendElapsed = timeElapsed - (lerpDuration + hangTime);
        if (descendElapsed <= lerpDuration)
        {
            float t2 = Mathf.Clamp01(descendElapsed / lerpDuration);
            CatWhole.transform.position = Vector3.Lerp(_catJumpPos, _catOriginalPos, t2);
            return;
        }

        // done
        CatWhole.transform.position = _catOriginalPos;
        _isCatJumping = false;

    }

    private void StretchCat()
    {
        //vertical stretch
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            _verticalStretch += _stretchRate * 8;
            if (CatBody.transform.localScale.y >= _YLimit2)
            {
                _verticalStretch = _YLimit2;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            _verticalStretch -= _stretchRate*8;

            if (CatBody.transform.localScale.y <= _YLimit)
            {
                _verticalStretch = _YLimit;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            _verticalStretch += _stretchRate/2;
            if (CatBody.transform.localScale.y >= _YLimit2)
            {
                _verticalStretch = _YLimit2;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            _verticalStretch -= _stretchRate/2;

            if (CatBody.transform.localScale.y <= _YLimit)
            {
                _verticalStretch = _YLimit;
            }
        }

        //horizontal stretch
        if (Input.GetKey(KeyCode.D))
        {
            _horizontalStretch += _stretchRate/2;
            if (CatBody.transform.localScale.x >= _XLimit2)
            {
                _horizontalStretch = _XLimit2;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            _horizontalStretch -= _stretchRate/2;

            if (CatBody.transform.localScale.x <= _XLimit)
            {
                _horizontalStretch = _XLimit;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Fish")
        {
            Score++;
            GameObject.Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("game over!");
            Score = 0;
        }
    }
}

        

    
   


