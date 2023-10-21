using UnityEngine;
using UnityEngine.UI;

public class AuthController : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GoogleSheetsController sheetsController;
    [SerializeField] private WebCamController webCamController;
    [SerializeField] private GameObject buttonsObj, noConnectionObj, webCamObj, enterNameObj, enterNameMenuObj;
    [SerializeField] private InputField nameInput;
    [SerializeField] private Text quitButtonTxt, insertNameText;
    private bool readQr;

    void Start()
    {
        try {
            sheetsController.StartSheets();
        }
        catch(System.Net.Http.HttpRequestException) {
            ErrorMode("Erro de conexão com a rede");
        }
        catch(System.Exception) {
            ErrorMode("Um erro inesperado aconteceu");
        }
    }

    public void ReadQrMode()
    {
        readQr = true;
        buttonsObj.SetActive(false);
        webCamObj.SetActive(true);
        enterNameObj.SetActive(true);
        quitButtonTxt.text = "VOLTAR";
        webCamController.StartWebCam();
    }    

    public void ErrorMode(string msg)
    {
        buttonsObj.SetActive(false);
        webCamObj.SetActive(false);        
        Text text = noConnectionObj.transform.GetComponentInChildren<Text>();
        text.text = msg;
        noConnectionObj.SetActive(true);
    }

    public void ShowEnterNameMenu() {
        webCamObj.SetActive(false); 
        enterNameObj.SetActive(false);
        enterNameMenuObj.SetActive(true);
        webCamController.StopCam();
    }

    public void ReadName() {
        string name = nameInput.text.ToLower();

        if(LoadPlayer((sheetsController.FindUser(name)+1).ToString())){
            insertNameText.text = $"BEM VINDO, {name.ToUpper()}!";
        } else {
            insertNameText.text = $"Usúario não encontrado";
        }
    }

    public bool LoadPlayer(string id)
    {
        var data = sheetsController.FindEntry(id);
        if (data == null) return false;
        Player.Instance.LoadData(data);

        sceneLoader.Invoke("loadMainMenu", 2.0f);
        return true;
    }

    public void QuitButtonAction()
    {
        if(readQr) {
            webCamController.StopCam();
            sceneLoader.loadAuthMenu();
        }
        else sceneLoader.quitGame();
    }
}
