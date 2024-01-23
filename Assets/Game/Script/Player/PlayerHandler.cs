using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerHandler : MonoBehaviour
{
    PlayerData playerData;

    [SerializeField] private float currentHp;
    private void Awake()
    {
        playerData = GetComponent<PlayerData>();

        currentHp = playerData.maxHp;
    }
    public void TakeDamage(float Damage)
    {
        currentHp -= Damage;
    }
    public void OnGUI()
    {
        Rect rect = new Rect(200, 150, 200, 200);

        string message = "Hp : " + currentHp;

        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.white;

        GUI.Label(rect, message, style);
    }
}
