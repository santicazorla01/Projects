using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    //public Animator animator;
    public GameObject Player;
    public Transform PlayerTransf;
    public GameObject blood;
    public Transform BloodSpawn;

    public GameObject Enemy;
    
    public Rigidbody2D Erb;

    public float fdirection;
    public float fMoveSpeed;
    public bool bFacingRight = false;
    public Vector3 localscale;
    public int nextSceneIndex;

    public int maxHealth = 9;
    public int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        localscale = transform.localScale;
        Erb = GetComponent<Rigidbody2D>();
        fdirection = -1f;
        fMoveSpeed = 3f;

        currentHealth = maxHealth;

    }
    void Update()
    {
        TakeDamage();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Wall>())
        {
            fdirection *= -1f;
        }
    }

     void FixedUpdate()
    {
        Erb.velocity = new Vector2(fdirection * fMoveSpeed, Erb.velocity.y);
    }

     void LateUpdate()
    {
        CheckWheretoFace();
    }

    void CheckWheretoFace()
    {
        if(fdirection > 0)
        
            bFacingRight = true;
        
        else if (fdirection < 0)
        
            bFacingRight = false;
        

        if(((bFacingRight) && (localscale.x < 0))|| ((!bFacingRight) && (localscale.x > 0)))
        
            localscale.x *= -1;
        
        transform.localScale = localscale;
    }

    // Update is called once per frame

    public void TakeDamage()
    {
        //currentHealth -= damage;
       
        /*animator.SetTrigger("Hurt");  //Reproducir animacion al herir
        GameObject bloodClone = Instantiate(blood, BloodSpawn.position, transform.rotation) as GameObject;
        Destroy(bloodClone, 2f);*/

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");

        //animator.SetBool("IsDead", true); //Animacion de muerte

        this.enabled = false;  //desactivar el boss
        GetComponent<Collider2D>().enabled = false;

        StartCoroutine("ChangeScene");
        
    }
     IEnumerator ChangeScene()
     {
         SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Additive);

         Scene nextScene = SceneManager.GetSceneAt(1);

         SceneManager.MoveGameObjectToScene(Player, nextScene);

         yield return null;

         SceneManager.UnloadSceneAsync(nextSceneIndex - 1);
     }

}
