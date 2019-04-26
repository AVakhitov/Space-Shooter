using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player  : MonoBehaviour
{
    public float speed = 5.0f;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;

    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;
    public bool canTripleShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,0);
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        // Player shoot laser on press space Key

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
           


            
            Shoot();
            
         }

        

    }

    private void Shoot()
    {

        if (Time.time > _canFire)
        {






            if (canTripleShoot == true)
            {
                Instantiate(_laserPrefab, transform.position, Quaternion.identity);

            }

            else
            {
                // spawn my laser
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);


            }

            _canFire = Time.time + _fireRate;
        }

        

    }

    private void Movement()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");

        float VerticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * speed * VerticalInput * Time.deltaTime);

        transform.Translate(Vector3.right * speed * HorizontalInput * Time.deltaTime);

        // if player on the y is greater than 0
        // set player position to 0

        if (transform.position.y > 0)
        {

            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        else if (transform.position.y < -4.2f)
        {


            transform.position = new Vector3(transform.position.x, -4.2f, 0);

        }
        // if player on the x is greater than 13.5
        // set player to  -13.5

        if (transform.position.x > 13.5f)
        {

            transform.position = new Vector3(-13.5f, transform.position.y, 0);


        }

        else if (transform.position.x < -13.5f)
        {
            transform.position = new Vector3(13.5f, transform.position.y, 0);



        }
    }
}
