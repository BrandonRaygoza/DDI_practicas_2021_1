using UnityEngine;
using Vuforia;

public class VirtualButtonScript : MonoBehaviour, IVirtualButtonEventHandler
{
    public Interactable aumentableObject;           //referencia a mi objeto a interactuar (el charizard)
    private VirtualButtonBehaviour virtualButton;   //referencia a ese componente para poder registrar los eventos que quiero

    /*Métodos necesarios para que funcione la interfaz (IVirtualButtonEventHandler)*/
    public void OnButtonPressed(VirtualButtonBehaviour vb){
        aumentableObject.Interact(); //Como el charizard (animación) tiene el script de PickUpObject, como hereda de Interactable, tambien se considera como un Interactable
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb){

    }

    void Awake()
    {
        virtualButton = GetComponent<VirtualButtonBehaviour>(); //Inicializar referencia al componente (es un script)

    }

    // Start is called before the first frame update
    void Start()
    {
        if(virtualButton != null){
            virtualButton.RegisterEventHandler(this); //Se registra asi mismo como un handler, y se llaman los métodos de presionar o dejar de presionar
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
