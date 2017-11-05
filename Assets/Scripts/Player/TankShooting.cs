using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public MuseDataHandler TargetMuse;

    public int m_PlayerNumber = 1;              // Used to identify the different players.
    public Rigidbody m_Shell;                   // Prefab of the shell.
    public Transform m_FireTransform;           // A child of the tank where the shells are spawned.
    public Slider m_AimSlider;                  // A child of the tank that displays the current launch force.
    public float m_MinLaunchForce = 15f;        // The force given to the shell if the fire button is not held.
    public float m_MaxLaunchForce = 30f;        // The force given to the shell if the fire button is held for the max charge time.
    public float m_TimeToLaunch = 1f;
    public float m_Cooldown = 1f;

    public Color m_MaxLaunchColor = Color.red;    
    public Color m_MinLaunchColor = Color.yellow;
    public Image m_AimImage;

    private float m_CurrentLaunchForce;         // The force that will be given to the shell when the fire button is released.
    private float m_ChargeSpeed;                // How fast the launch force increases, based on the max charge time.
    private bool m_Fired = true;                       // Whether or not the shell has been launched with this button press.
    private float m_LaunchTimeCounter;
    private float m_CooldownCounter;


    

    private void OnEnable()
    {
        // When the tank is turned on, reset the launch force and the UI
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
    }


    private void Start ()
    {

        // The rate that the launch force charges up is the range of possible forces by the max charge time.
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce)/m_TimeToLaunch;
    }


    private void Update ()
    {
        m_CooldownCounter -= Time.deltaTime;
        if (m_CooldownCounter >= 0) {
            m_Fired = true;
            return;
        }

        m_LaunchTimeCounter -= Time.deltaTime;
        if (m_LaunchTimeCounter < 0 && !m_Fired) {
            Fire();
        }

        // The slider should have a default value of the minimum launch force.
        m_AimSlider.value = m_MinLaunchForce;

        // If the max force has been exceeded and the shell hasn't yet been launched...
        if (TargetMuse.jawClench > 0.0f && !m_Fired) {
            Fire();
        }
        if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
        {
            // ... use the max force and launch the shell.
            m_CurrentLaunchForce = m_MaxLaunchForce;
            Fire ();
        }
        else if (m_CurrentLaunchForce < (TargetMuse.concentration * m_ChargeSpeed * m_TimeToLaunch + m_MinLaunchForce) && !m_Fired)
        {
            m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;

            m_AimSlider.value = m_CurrentLaunchForce;
            m_AimImage.color = Color.Lerp (m_MinLaunchColor, m_MaxLaunchColor, m_CurrentLaunchForce/m_MaxLaunchForce);
    
        }
        else if (m_CurrentLaunchForce > (TargetMuse.concentration * m_ChargeSpeed * m_TimeToLaunch + m_MinLaunchForce) && !m_Fired)
        {
            m_CurrentLaunchForce -= m_ChargeSpeed * Time.deltaTime;

            m_AimSlider.value = m_CurrentLaunchForce;
            m_AimImage.color = Color.Lerp (m_MinLaunchColor, m_MaxLaunchColor, m_CurrentLaunchForce/m_MaxLaunchForce);
    
        }
        // // Otherwise, if the fire button is being held and the shell hasn't been launched yet...
        // else if (TargetMuse.concentration > 0.0f && !m_Fired)
        // {
        //     // Increment the launch force and update the slider.
        //     m_CurrentLaunchForce = TargetMuse.concentration * m_ChargeSpeed + m_MinLaunchForce;

        //     m_AimSlider.value = m_CurrentLaunchForce;
        // }
        // Otherwise, if the fire button has just started being pressed...
        else if (TargetMuse.concentration > 0.0f)
        {
            // ... reset the fired flag and reset the launch force.
            m_Fired = false;
            m_CurrentLaunchForce = m_MinLaunchForce;

            m_LaunchTimeCounter = m_TimeToLaunch;
        }
        else if (TargetMuse.concentration <= 0.0f && !m_Fired)
        {
            Fire();
        }
    }


    private void Fire ()
    {
        // Set the fired flag so only Fire is only called once.
        m_Fired = true;

        m_CooldownCounter = m_Cooldown;

        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody shellInstance =
            Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        // Set the shell's velocity to the launch force in the fire position's forward direction.
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward; 

        // Reset the launch force.  This is a precaution in case of missing button events.
        m_CurrentLaunchForce = m_MinLaunchForce;
    }
}