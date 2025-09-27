using NUnit;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatControl : MonoBehaviour
{

    //ad to extend

    [SerializeField]
    private GameObject CatBody;
    [SerializeField]
    private GameObject CatHead;
    [SerializeField]
    private GameObject CatWhole;

    private float _wholeCatYPos;

    [SerializeField]
    private GameObject PosForHead;
    [SerializeField]
    private GameObject ParentForHead;

    public float _stretchRate = 100f;
    private float _verticalStretch;

    private float _headPos;
    public float _YPos = 0.5f;

    private float _horizontalStretch;

    private float _XLimit = 1400;
    private float _YLimit = 850;

    private float _XLimit2 = 15000;
    private float _YLimit2 = 15000;

    [SerializeField]
    private float _originalYPos = 0f;
    [SerializeField]
    private float _jumpDestinationPos = 30f;

    private float _timer;
    [SerializeField]
    private float _jumpTime = 20f;

    private Vector3 _catOriginalPos;
    private Vector3 _catJumpPos;

    private float timeElapsed;
    private float lerpDuration = 1f;

    private bool _spacePressed = false;
    private bool _isCatJumping = false;
    public float hangTime = 0.2f;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _wholeCatYPos = CatWhole.transform.position.y; // cat pos set as Cat's position

        _verticalStretch = CatBody.transform.localScale.y;
        _headPos = CatHead.transform.position.y;

        ParentForHead.transform.position = PosForHead.transform.position;
        CatHead.transform.SetParent(ParentForHead.transform);

        _horizontalStretch = CatBody.transform.localScale.x;
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
            _verticalStretch += _stretchRate;
            if (CatBody.transform.localScale.y >= _YLimit2)
            {
                _verticalStretch = _YLimit2;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            _verticalStretch -= _stretchRate;

            if (CatBody.transform.localScale.y <= _YLimit)
            {
                _verticalStretch = _YLimit;
            }
        }

        //horizontal stretch
        if(Input.GetKey(KeyCode.D))
        {
            _horizontalStretch += _stretchRate;
            if (CatBody.transform.localScale.x >= _XLimit2)
            {
                _horizontalStretch = _XLimit2;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            _horizontalStretch -= _stretchRate;

            if (CatBody.transform.localScale.x <= _XLimit)
            {
                _horizontalStretch = _XLimit;

            }
        }
    }

}

        

    
   


