using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseCharacter
{
    //Rigid body komponentti, tarvitaan .velocity käytön takia
    Rigidbody2D playerRigidBody;
    [SerializeField]
    float playerSpeed = 5000f;

    public float PlayerSpeed { get => playerSpeed; set => playerSpeed = value; } 
    //Property (erona fieldiin on se että siinä on get ja set).
    //Hakee arvonsa playerspeedistä ja kans asettaa arvon aina playerspeedin kautta

    // Start is called before the first frame update
    void Start()
    {
        //Löytää rigid body komponentin suoraan tämän skriptin gameobjektista
        playerRigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }
    void Movement()
    {
        var movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //Eli suunta a - d ja w - s akseleina näppäimistöllä
        movement = Vector3.ClampMagnitude(movement, 1); //Rajoitetaan liikkumisvektori (ilman nopeutta lisättynä) maksimissaan arvoon yksi
        //Koska jos painaa a + w tai w+s kulkisit loppuen lopulta kaksinkertaista vauhtia.
        //Nyt liike on "ympyrämäisen nopea", ei niin että pääilmansuunnnat ovat hitaampia kun niitten vierekkäiset ilmansuunat.
        //a on negatiivinen yksi, kuten on s
        //d on positiivinen suunta, kuten w
        //Asetetaan velocity = nopeus (ERI KUIN VAUHTI. Vauhdilla ei ole suuntaa = vauhti ei voi olla negatiivinen, esim nopeus -15kmh = peruuttaa).
        playerRigidBody.velocity = movement * PlayerSpeed;
        //Time deltatime poistaa sen, että frameratesta riippuen voisit liikkua nopeammin tai hitaammin.
    }

}
