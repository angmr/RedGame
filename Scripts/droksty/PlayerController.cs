<<<<<<< Updated upstream
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     public Transform playerCamera;
//     public float mouseSensitivity = 3.0f;
//     private float cameraPitch = 0.0f;
//     private float maxPitchAngle = 90.0f;

//     public CharacterController controller; // Το reference για το Character Controller component 
//     public float walkSpeed = 6.0f; // Ταχύτητα περπατήματος. To public επιτρέπει: α) finetuning μέσα από τον inspector της Unity β) επικοινωνία με άλλα class, αν χρειαστεί.
//     public float runSpeed = 15.0f; // Ταχύτητα τρεξίματος. To public επιτρέπει: α) finetuning μέσα από τον inspector της Unity β) επικοινωνία με άλλα class, αν χρειαστεί.


//     private Vector3 verticalPos; // Διάνυσμα που χρησιμοποιώ για να εφαρμόσω δυνάμεις στο Character Controller στον κάθετο άξονα y.
//     [SerializeField] private float gravityForce = 11.0f; // Ισχύς "βαρύτητας"
//     [SerializeField] private float jumpForce = 4.5f; // Ισχύς άλματος
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// 
public class PlayerController : MonoBehaviour
{
    public Transform playerCamera;
    public float mouseSensitivity = 3.0f;
    private float cameraPitch = 0.0f;
    private float maxPitchAngle = 90.0f;

    public CharacterController controller; // Το reference για το Character Controller component 
    public float walkSpeed = 6.0f; // To public επιτρέπει: α) finetuning μέσα από τον inspector της Unity β) επικοινωνία με άλλα class, αν χρειαστεί.
    public float runSpeed = 15.0f; // To public επιτρέπει: α) finetuning μέσα από τον inspector της Unity β) επικοινωνία με άλλα class, αν χρειαστεί.


    private Vector3 verticalPos; // Διάνυσμα που χρησιμοποιώ για να εφαρμόσω δυνάμεις στο Character Controller στον κάθετο άξονα y.
    [SerializeField] private float gravityForce = 11.0f; //
    [SerializeField] private float jumpForce = 4.5f; //
>>>>>>> Stashed changes


//     void Start() ///
//     {
//         Cursor.lockState = CursorLockMode.Locked;
//         Cursor.visible = false;
//     }


//     void Update() // Σε κάθε frame καλεί τις συναρτήσεις MouseLook() και UpdateMovement()
//     {
//         MouseLook();
//         UpdateMovement();
//     }


//     void MouseLook()
//     {
//         Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

//         cameraPitch -= mouseDelta.y * mouseSensitivity;
//         cameraPitch = Mathf.Clamp(cameraPitch, -maxPitchAngle, maxPitchAngle);

//         playerCamera.localEulerAngles = Vector3.right * cameraPitch;
//         transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity);
        
<<<<<<< Updated upstream
//     }


//     void UpdateMovement()
//     {
//         if (controller.isGrounded) { // Χρήση της ενσωματωμένης isGrounded(). Άν το Character Controller ακουμπάει έδαφος:
//             verticalPos.y = 0f; // κάνω reset τη θέση του στον κάθετο άξονα y 
//             if (Input.GetKey(KeyCode.Space)) { // και επιτρέπω τη δυνατότητα Jump. Αν ο παίκτης πηδήξει:
//                 verticalPos.y += jumpForce; // η θέση του Character Controller στον κάθετο άξονα y μεταβάλλεται σε += jumpForce
//             }
//         } else if (!controller.isGrounded) { // Χρήση της ενσωματωμένης isGrounded(). Άν το Character Controller ΔΕΝ ακουμπάει έδαφος, δηλαδή αν είναι στον αέρα (είτε επειδή έκανε jump, είτε επειδή έπεσε από κάπου):
//             verticalPos.y -= gravityForce * Time.deltaTime; // η θέση του Character Controller στον κάθετο άξονα y μεταβάλλεται κατά gravityForce (ψευτοδύναμη βαρύτητας και πτώσης)
//         }

//         Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // Αποθηκεύω στο Vector2 inputDirection ποια πλήκτρα κίνησης πάτησε ο παίκτης, άρα προς τα που επιθυμεί να κινηθεί.
//         inputDirection.Normalize(); // Κανονικοποιώ τις τιμές της inputDirection με την ενσωματωμένη Normalize()
=======
    }


    void UpdateMovement()
    {
        if (controller.isGrounded) { // Χρήση της ενσωματωμένης isGrounded(). Άν το Character Controller ακουμπάει έδαφος:
            // verticalPos.y = 0f; // κάνω reset τη θέση του στον κάθετο άξονα y 
            if (Input.GetKey(KeyCode.Space)) { // και επιτρέπω τη δυνατότητα Jump. Αν ο παίκτης πηδήξει:
                verticalPos.y += jumpForce; // η θέση του Character Controller στον κάθετο άξονα y μεταβάλλεται σε += jumpForce
            }
        } else { // Χρήση της ενσωματωμένης isGrounded(). Άν το Character Controller ΔΕΝ ακουμπάει έδαφος, δηλαδή αν είναι στον αέρα (είτε επειδή έκανε jump, είτε επειδή έπεσε από κάπου):
            verticalPos.y -= gravityForce * Time.deltaTime; // η θέση του Character Controller στον κάθετο άξονα y μεταβάλλεται κατά gravityForce (ψευτοδύναμη βαρύτητας και πτώσης)
        }

        Debug.Log(verticalPos);

        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // Αποθηκεύω στο Vector2 inputDirection ποια πλήκτρα κίνησης πάτησε ο παίκτης, άρα προς τα που επιθυμεί να κινηθεί.
        inputDirection.Normalize(); // Κανονικοποιώ τις τιμές της inputDirection με την ενσωματωμένη Normalize()
>>>>>>> Stashed changes
        
//         Vector3 playerDirection = (transform.forward * inputDirection.y + transform.right * inputDirection.x); // Πολλαπλασιάζω την inputDirection.y (πάνω/κάτω) με τo transform.forward (ευθεία του Player) για να βρω αν ο παίκτης θα κινηθεί ευθεία ή πίσω. Ομοίως, πολλαπλασιάζω την inputDirection.x (αριστερά/δεξιά) με το transform.right (δεξιά του Player) για να βρω αν ο παίκτης κινείται αριστερά ή δεξιά. To άθροισμα των 2 γινομένων είναι η κατεύθυνση του παίκτη.
        
//         Vector3 velocity = (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed) * playerDirection; // Χρησιμοποιώ ternary operator. Αν ο παίκτης πατάει το Shift τρέχει, αλλιώς περπατάει. Πολλαπλασιάζω αυτή τη ταχύτητα με playerDirection. Το τελικό γινόμενο velocity αφορά το μέτρο και τη κατεύθυνση προς την οποία θα κινηθεί το Character Controller.

//         controller.Move(velocity * Time.deltaTime); // Καλώ την ενσωματωμένη Move() για να μετατοπίσω το controller προς velocity * δέλτα
//         controller.Move(verticalPos * Time.deltaTime); // Καλώ την ενσωματωμένη Move() για να μετατοπίσω το controller προς verticalPos * δέλτα, εξομοιώνοντας με απλό τρόπο τη δύναμη της βαρύτητας.
//     }
    
// }