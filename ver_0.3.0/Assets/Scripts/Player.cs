using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : APlayer
{
    [Header("»нструменты –азработчика")]
    [SerializeField] private bool _infiniteFuel;

    [Header("ѕараметры “анка")]
    [SerializeField] private float _currentSpeed = 0;
    public float _currentFuel = 0; // эти две строчки внесены, что бы понимать разницу между максимальным значением Fuel и Health
    public float _currentHealth = 0; // и возможность вносить изменени€ в параматры существующих танков
    [SerializeField] private float _fuelRate = 1;
    [SerializeField] private float _speedOfRotation = 15;
    [SerializeField] private float _minAngle = 10f; 
    [SerializeField] private float _maxAngle = 170f;

    private void Start()
    {
        FuelOfPlayer = 100;
        Health = 300;
        Speed = 2;
        _currentHealth = Health;
        _currentFuel = FuelOfPlayer;

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentHealth -= 20;
        }


        PlayerMove();
        RotationWeapon();
    }
    public override void PlayerMove() 
    {
        if (FuelOfPlayer >= 0 || _infiniteFuel )
        {
            float x = Input.GetAxisRaw("Horizontal");
            
            _currentSpeed = Mathf.Lerp(_currentSpeed, x * Speed, Time.fixedDeltaTime / 2); 
            // ссылки на разные функции по типу Lerp https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/
            if (x == 0 && Mathf.Abs(_currentSpeed) < 0.1f) // о боги € писал это условие 3 часа
            { 
                _currentSpeed = 0; 
            }

            GetComponent<Rigidbody2D>().velocity = new Vector2(_currentSpeed, GetComponent<Rigidbody2D>().velocity.y);
            FuelOfPlayer -= _fuelRate * Time.deltaTime; // ¬рем€ дл€ плавного расхода топлива
        }
    }
    public override void PlayerShot()
    {


    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {



    }
    public override void RotationWeapon()
    {
        float input = Input.GetAxis("Vertical");
        // –ассчитываем новый угол с ограничением
        float newAngle = Mathf.Clamp(
            Cannon.transform.localEulerAngles.z + input * _speedOfRotation * Time.fixedDeltaTime,
            _minAngle,
            _maxAngle
        );
        Cannon.transform.localEulerAngles = new Vector3(Cannon.transform.localEulerAngles.x, Cannon.transform.localEulerAngles.y, newAngle);
    }

}
