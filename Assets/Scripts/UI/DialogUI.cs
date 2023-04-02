using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

/// <summary>
/// UI module for managing displayed dialogs
/// </summary>
public class DialogUI : MonoBehaviour
{
    [Header("UI System")]
    [SerializeField] UIWindowActivator _uiWindowActivator;

    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI _authorText;
    [SerializeField] TextMeshProUGUI _messageText;

    [Header("Audio")]
    [SerializeField] AudioClip _nextMessageSoundEffect;

    [Header("Parameters")]
    [SerializeField, Tooltip("Speed at which the message is displayed")] float _messageDisplaySpeed = 1f;
    [SerializeField, Tooltip("Delay between each message update")] float _messageUpdateDelay = 0.05f;
    [SerializeField] float _voiceVolume = 0.4f;

    private Dialog _currentDialog;
    private IEnumerator<DialogElement> _dialogEnumerator;
    private bool _isWrittingMessage = false;

    public void Init(Dialog dialog)
    {
        _currentDialog = dialog;
        _dialogEnumerator = dialog.GetEnumerator();
        Next();
        _uiWindowActivator.Show();
    }

    // Display next dialog element
    public void Next()
    {
        if (_isWrittingMessage)
        {
            // orders to finish writting the currently displayed message
            _isWrittingMessage = false;
        }
        else if (_dialogEnumerator.MoveNext())
        {
            // goes to next dialog element
            DisplayDialogElement(_dialogEnumerator.Current);
            AudioManager.Instance.PlaySoundEffect(_nextMessageSoundEffect);
        }
        else
        {
            // the dialog is finished
            _uiWindowActivator.Hide();
            _currentDialog.End();
        }
    }

    private void DisplayDialogElement(DialogElement element)
    {
        _authorText.text = element.Author.Name;
        _isWrittingMessage = true;
        StartCoroutine(DisplayDialogMessageCoroutine(element));
    }

    private IEnumerator DisplayDialogMessageCoroutine(DialogElement element)
    {
        string message = element.Message;
        _messageText.text = message;
        _messageText.maxVisibleCharacters = 0;

        while (_isWrittingMessage && _messageText.maxVisibleCharacters < message.Length)
        {
            // updates current message position after a frame
            yield return new WaitForSeconds(_messageUpdateDelay);
            _messageText.maxVisibleCharacters += Mathf.FloorToInt(_messageDisplaySpeed * _messageUpdateDelay);

            // if the character has a voice, we play it after writing a letter
            if (element.Author.Voice != null)
            {
                float pitch = Random.Range(-element.Author.VoiceModulationAmplitude, element.Author.VoiceModulationAmplitude);
                AudioManager.Instance.PlaySoundEffect(element.Author.Voice, pitch, _voiceVolume);
            }
        }

        _messageText.maxVisibleCharacters = message.Length;
        _isWrittingMessage = false;
    }
}
