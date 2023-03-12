using UnityEngine;

public class ProbeFound : MonoBehaviour
{
    [SerializeField] Transform _character;
    [SerializeField] Transform _targetPosition;
    [SerializeField] GameObject _initialAppearance;
    [SerializeField] GameObject _finalAppearance;

    public void Trigger()
    {
        _initialAppearance.SetActive(false);
        _finalAppearance.SetActive(true);
        _character.position = _targetPosition.position;
    }
}
