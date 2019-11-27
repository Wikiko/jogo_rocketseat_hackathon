using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Truck : MonoBehaviour
{

    private Rigidbody2D truckRb;
    public Button BotaoDireita;
    private GameController gameController;

    public int qtdMove;

    private int startQtdMove;

    public bool isGrounded = true;

    // Use this for initialization
    void Start()
    {
        truckRb = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
        startQtdMove = qtdMove;
        //botao andar para a direita
        /*Button btn = GameObject.Find("BotaoDireita").GetComponent<Button>();
        btn.onClick.AddListener(moveDireita);
        */

    }

    // Update is called once per frame
    void Update()
    {
        this.moverPersonagem(Input.GetAxisRaw("Horizontal"));
    }

    void moverPersonagem(float horizontal)
    {
        float moverParaComVelocidade = horizontal * gameController.velocidadeObjeto;
        truckRb.velocity = new Vector2(moverParaComVelocidade, truckRb.velocity.y);
    }

    public IEnumerator corMoveDireita(float lado)
    {
        if (qtdMove > 0)
        {
            yield return new WaitForEndOfFrame();
            moverPersonagem(lado);
            qtdMove--;
            StartCoroutine("corMoveDireita", lado);
        }
        else
        {
            StopCoroutine("corMoveDireita");
        }
    }

    public void startMover(float lado)
    {
        var nomeDoComando = "";

        if(lado > 0)
        {
            nomeDoComando = "Andar ->";
        } else
        {
            nomeDoComando = "Andar <-";
        }
        gameController.addComando(new Comando(nomeDoComando, () =>
        {
            qtdMove = startQtdMove;
            return corMoveDireita(lado);
        }));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Terreno":
                isGrounded = true;
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Terreno":
                isGrounded = false;
                break;
        }
    }
}
