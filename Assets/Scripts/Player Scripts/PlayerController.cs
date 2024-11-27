//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
//public class PlayerController : MonoBehaviour
//{
//    [SerializeField] private Rigidbody _rigidbody;
//    [SerializeField] private FixedJoystick _joystick;
//    [SerializeField] private Animator _animator;

//    [SerializeField] private float _moveSpeed;

//    private void FixedUpdate()
//    {
//        // Move the player based on joystick input, but don't rotate the player here
//        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

//        // Trigger running animation when joystick is moved
//        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
//        {
//           // _animator.SetBool("isRunning", true);
//        }
//        else
//        {
//           // _animator.SetBool("isRunning", false);
//        }
//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
//public class PlayerController : MonoBehaviour
//{
//    [SerializeField] private Rigidbody _rigidbody;
//    [SerializeField] private FixedJoystick _joystick;
//    [SerializeField] private Animator _animator;

//    [SerializeField] private float _moveSpeed;

//    private void FixedUpdate()
//    {
//        // Move the player based on joystick input
//        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

//        // Update the "CharacterAnimation" integer parameter based on joystick movement
//        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
//        {
//            // Joystick is moving, set to walking animation (1)
//            _animator.SetInteger("CharacterAnimations", 1);
//        }
//        else
//        {
//            // Joystick is not moving, set to idle animation (0)
//            _animator.SetInteger("CharacterAnimations", 0);
//        }
//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
//public class PlayerController : MonoBehaviour
//{
//    [SerializeField] private Rigidbody _rigidbody;
//    [SerializeField] private FixedJoystick _joystick;
//    [SerializeField] private Animator _animator;

//    [SerializeField] private float _moveSpeed;

//    private void FixedUpdate()
//    {
//        // Move the player based on joystick input
//        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

//        // Update the "CharacterAnimation" integer parameter based on joystick movement
//        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
//        {
//            // Joystick is moving, set to walking animation (1)
//            _animator.SetInteger("CharacterAnimations", 1);
//        }
//        else
//        {
//            // Joystick is not moving, set to idle animation (0)
//            _animator.SetInteger("CharacterAnimations", 0);
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _moveSpeed;

    private void FixedUpdate()
    {
        // Move the player based on joystick input
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

        // Update the "CharacterAnimation" integer parameter based on joystick movement
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            // Joystick is moving, set to walking animation (1)
            _animator.SetInteger("CharacterAnimations", 1);
        }
        else
        {
            // Joystick is not moving, set to idle animation (0)
            _animator.SetInteger("CharacterAnimations", 0);
        }
    }
}





