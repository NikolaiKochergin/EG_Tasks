using UnityEngine;
using UnityEngine.SceneManagement;

namespace Week_9_Platformer
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject _menuButton;
        [SerializeField] private GameObject _menuWindow;
        [SerializeField] private MonoBehaviour[] _componentsToDisable;


        public void OpenMenuWindow()
        {
            _menuButton.SetActive(false);
            _menuWindow.SetActive(true);

            foreach (var component in _componentsToDisable)
                component.enabled = false;

            Time.timeScale = 0.01f;
        }

        public void CloseMenuWindow()
        {
            _menuButton.SetActive(true);
            _menuWindow.SetActive(false);
            
            foreach (var component in _componentsToDisable)
                component.enabled = true;

            Time.timeScale = 1f;
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}