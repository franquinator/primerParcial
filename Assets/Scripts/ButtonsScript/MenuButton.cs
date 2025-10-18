using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void BackToMenu()
    {
        GameManager.instance.QuitMenu();
    }
}
