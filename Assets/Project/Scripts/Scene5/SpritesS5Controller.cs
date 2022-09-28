using UnityEngine;

public class SpritesS5Controller : MonoBehaviour
{
    [SerializeField] private GameObject vegetation;

    public void showVegetation()
    {
        vegetation.SetActive(true);
    }
}
