//using System.Collections;
//using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
//public class PlayerAttackController : MonoBehaviour
//{
//    [SerializeField] private FixedJoystick _attackJoystick;  // Attack Joystick
//    [SerializeField] private Transform _firePoint;           // Where the bullets will fire from (on the player)
//    [SerializeField] private GameObject _bulletPrefab;       // The bullet prefab to be fired
//    [SerializeField] private float _bulletSpeed = 20f;       // Speed of the bullet
//    [SerializeField] private float _fireRate = 0.5f;         // Fire rate (time between shots)
//    [SerializeField] private float _rotationSpeed = 10f;     // Speed of player rotation towards attack direction

//    private bool _isFiring = false;                          // Whether the player is currently firing
//    private float _nextFireTime = 0f;                        // Time until the next shot can be fired

//    private Vector3 _lastAttackDirection = Vector3.forward;  // Store the last valid attack direction

//    private void Update()
//    {
//        HandleAttackInput();
//    }

//    private void HandleAttackInput()
//    {
//        // Check if attack joystick is moved (attack direction is not neutral)
//        if (Mathf.Abs(_attackJoystick.Horizontal) > 0.1f || Mathf.Abs(_attackJoystick.Vertical) > 0.1f)
//        {
//            // Calculate the direction of attack based on joystick input
//            Vector3 attackDirection = new Vector3(_attackJoystick.Horizontal, 0, _attackJoystick.Vertical);
//            _lastAttackDirection = attackDirection;  // Update the last valid attack direction

//            Quaternion targetRotation = Quaternion.LookRotation(attackDirection);

//            // Smoothly rotate player towards attack direction
//            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

//            // Start firing automatically if the fire rate allows it
//            if (!_isFiring)
//            {
//                StartCoroutine(AutoFire());
//            }
//        }
//        else
//        {
//            // Stop firing if joystick is not moved
//            _isFiring = false;

//            // Keep the player facing the last direction when joystick is not moved
//            if (_lastAttackDirection != Vector3.zero)
//            {
//                Quaternion targetRotation = Quaternion.LookRotation(_lastAttackDirection);
//                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
//            }
//        }
//    }

//    private IEnumerator AutoFire()
//    {
//        _isFiring = true;

//        while (_isFiring)
//        {
//            if (Time.time >= _nextFireTime)
//            {
//                Fire();
//                _nextFireTime = Time.time + _fireRate;
//            }

//            yield return null; // Wait for the next frame to check firing condition again
//        }
//    }

//    private void Fire()
//    {
//        // Fire only if the Gun is equipped
//        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
//        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
//        bulletRb.velocity = _firePoint.forward * _bulletSpeed;

//        Destroy(bullet, 5f); // Destroy the bullet after 5 seconds to prevent clutter
//    }
//}


using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private FixedJoystick _attackJoystick;  // Attack Joystick
    [SerializeField] private Transform _firePoint;           // Where the bullets will fire from (on the player)
    [SerializeField] private GameObject _bulletPrefab;       // The bullet prefab to be fired
    [SerializeField] private float _bulletSpeed = 20f;       // Speed of the bullet
    [SerializeField] private float _fireRate = 0.5f;         // Fire rate (time between shots)
    [SerializeField] private float _rotationSpeed = 10f;     // Speed of player rotation towards attack direction
    [SerializeField] private AudioClip _fireSound;           // Sound to play when firing
    [SerializeField] private AudioSource _audioSource;       // AudioSource to play the sound

    private bool _isFiring = false;                          // Whether the player is currently firing
    private float _nextFireTime = 0f;                        // Time until the next shot can be fired

    private Vector3 _lastAttackDirection = Vector3.forward;  // Store the last valid attack direction

    private void Start()
    {
        // If no AudioSource is assigned, attempt to get one from the same GameObject
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        HandleAttackInput();
    }

    private void HandleAttackInput()
    {
        // Check if attack joystick is moved (attack direction is not neutral)
        if (Mathf.Abs(_attackJoystick.Horizontal) > 0.1f || Mathf.Abs(_attackJoystick.Vertical) > 0.1f)
        {
            // Calculate the direction of attack based on joystick input
            Vector3 attackDirection = new Vector3(_attackJoystick.Horizontal, 0, _attackJoystick.Vertical);
            _lastAttackDirection = attackDirection;  // Update the last valid attack direction

            Quaternion targetRotation = Quaternion.LookRotation(attackDirection);

            // Smoothly rotate player towards attack direction
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            // Start firing automatically if the fire rate allows it
            if (!_isFiring)
            {
                StartCoroutine(AutoFire());
            }
        }
        else
        {
            // Stop firing if joystick is not moved
            _isFiring = false;

            // Keep the player facing the last direction when joystick is not moved
            if (_lastAttackDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_lastAttackDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }
        }
    }

    private IEnumerator AutoFire()
    {
        _isFiring = true;

        while (_isFiring)
        {
            if (Time.time >= _nextFireTime)
            {
                Fire();
                _nextFireTime = Time.time + _fireRate;
            }

            yield return null; // Wait for the next frame to check firing condition again
        }
    }

    private void Fire()
    {
        // Fire only if the Gun is equipped
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = _firePoint.forward * _bulletSpeed;

        // Play the fire sound
        if (_fireSound != null && _audioSource != null)
        {
            _audioSource.PlayOneShot(_fireSound);
        }

        Destroy(bullet, 5f); // Destroy the bullet after 5 seconds to prevent clutter
    }
}
