using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private TextAsset _textAsset;
    [SerializeField] private Text _dialogueTitle;
    [SerializeField] private Text _dialogueText;
    [SerializeField] private Image _dialogueIcon;
    private DialogueLoader _loader;
    private Dialogue _dialogue;
    private string _symbolsToDelay = ".?!";


    private void Start()
    {
        _loader = gameObject.AddComponent<DialogueLoader>();
        _dialogue = _loader.LoadDialogue(_textAsset.text);


        //
        //_dialogue = ScriptableObject.CreateInstance<Dialogue>();
        //_dialogue.Prases = new List<Phrase>();
        //Phrase _phrase1 = ScriptableObject.CreateInstance<Phrase>();
        //_phrase1.Name = "Тристан";
        //_phrase1.Text = "Hello World! Heh";
        //_phrase1.IconPath = "mutantExample";
        //_dialogue.Prases.Add(_phrase1);
        //_dialogue.Prases.Add(_phrase1);
        //_dialogue.Prases.Add(_phrase1);
        //

        StartCoroutine(StartDialogue());
    }

    public IEnumerator StartDialogue()
    {
        for (int i = 0; i < _dialogue.Prases.Length; i++)
        {
            Phrase phrase = _dialogue.Prases[i];
            _dialogueTitle.text = phrase.Name;
            _dialogueIcon.overrideSprite = Resources.Load<Sprite>(phrase.IconPath);
            _dialogueText.text = "";
            for (int j = 0; j < phrase.Text.Length; j++)
            {
                _dialogueText.text = _dialogueText.text + phrase.Text[j];
                yield return new WaitForSeconds(_symbolsToDelay.Contains(phrase.Text[j]) ? 0.5f : 0.05f);
            }
            while (!Input.GetMouseButtonDown(0))
                yield return null;
        }
    }
}
