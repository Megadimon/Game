using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject HPBar; // ����� ��������
    private Player _player; // ������ �� ������
    private Image _fillImage; // ��������� ����������� ��� ���������� �����

    private void Start()
    {
        _player = GetComponent<Player>();
        if (HPBar != null)
        {
            _fillImage = HPBar.transform.Find("Fill").GetComponent<Image>();
        }
    }

    private void Update()
    {
        if (_fillImage != null)
        {
            // �������� ����� �������� � ����������� �� �������� �������� ������
            float _currentFillAmount = Mathf.MoveTowards(_fillImage.fillAmount, Mathf.Clamp01(_player._currentHealth / _player.Health), Time.deltaTime / 2);
            _fillImage.fillAmount = _currentFillAmount;
        }
    }
}
