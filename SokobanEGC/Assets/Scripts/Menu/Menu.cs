using UnityEngine;
    
namespace EGC.Menu
{
    public abstract class Menu : MonoBehaviour
    {
        public void ShowMenu()
        {
            gameObject.SetActive(true);
        }

        public void HideMenu()
        {
            gameObject.SetActive(false);
        }
    }
}