using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask; // Variable para guardar capas declaradas en el juego
    
    [SerializeField] private float jumpForce = 10f;    // Fuerza de salto
    [SerializeField] private float runningSpeed = 1f; // Velocidad al correr
    
    Rigidbody2D playerRb;    // Declaramos el rigidbody del objeto
    Animator playerAnim;    // Declaramos el animator del objeto
    Vector3 startPosition;  // 
    
    // Variables de condicion de animacion (las mayusculas
    // es un estandar heredado de C para declarar constantes)
    private const string STATE_ALIVE = "isAlive";                //Variable para saber si estoy vivo
    private const string STATE_ON_THE_GROUND = "isOnTheGround"; //Variable para saber si estoy en el suelo
    
    // Es buena practica cargar componentes en el metodo Awake
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>(); // Cargamos el componente rigidbody del objeto.
        playerAnim = GetComponent<Animator>(); // Cargamos el componente de animación el objeto.
    }
    
    void Start()
    {
        startPosition = this.transform.position;
    }
    
    // Logica donde ejecutamos el inicio del juego (se llama desde otro script)
    public void StartGame()
    {
        playerAnim.SetBool(STATE_ON_THE_GROUND, true); // Definimos el estado de animacion
        playerAnim.SetBool(STATE_ALIVE, true);        // Definimos el estado de animacion
        
        Invoke("RestartPosition", 0.3f);
    }
    
    void RestartPosition()
    {
        this.transform.position = startPosition;
        this.playerRb.velocity = Vector2.zero;
    }
    
    void Update()
    {
        // Si presionamos la tecla declarada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Ejecutamos el metodo de salto
            Jump(); 
        }
        
        // Definimos el estado de animacion con el valor que devuelca el metodo
        playerAnim.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround()); 

        // #DEBUG#: Dibujamos un rayo desde el centro del objeto hacia abajo
        Debug.DrawRay(this.transform.position, Vector2.down * 1.5f, Color.red);
    }
    
    // Todo lo que tiene que ver con fisicas es recomendable que vaya en este metodo porque es mas constante que Update
    private void FixedUpdate()
    {
        if(GameManager.gameManagerInstance.currentGameState == GameState.InGame)
        {
            if (playerRb.velocity.x < runningSpeed)
            {
                playerRb.velocity = new Vector2(runningSpeed * 5f, playerRb.velocity.y);
            }
        }
        else
        {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        }
    }
    
    // Lógica para saltar
    void Jump()
    {
        if(GameManager.gameManagerInstance.currentGameState == GameState.InGame)
        {
            // Si el metodo retorna verdadero...
            if (IsTouchingTheGround())
            {
                // ...Añadimos un impulso al RB del objeto
                playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
    
    // Lógica para saber si el Player está o no tocando el suelo
    bool IsTouchingTheGround()
    {
        // Lanzamos un raycast a partir de la posicion del objeto, hacia abajo, determinando
        //una distancia maxima, hasta topar con la variable de layer que declaramos antes.
        if (Physics2D.Raycast(this.transform.position,Vector2.down,1.2f,groundMask))
        {
            // Si se cumple la condicion, el metodo me da verdadero
            return true;
        }
        else
        {
            // Si no, me dara falso
            return false;
        }
    }
  
    public void Die()
    {
        this.playerAnim.SetBool(STATE_ALIVE, false);
        GameManager.gameManagerInstance.GameOver();
    }
}
