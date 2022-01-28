using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DialogueSystem
{
    public class DialogDrawer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        [SerializeField] private Transform _buttonsContainer;
        [SerializeField] private GameObject _buttonPrefab;

        private Queue<GameObject> _choiceButtons;

        public void DrawPhrase(string text)
        {
            _text.text = text;
        }

        public void DrawChoices(Queue<string> text)
        {
            _choiceButtons = new Queue<GameObject>();

            int ChoicesCount = text.Count;

            for (int i = 0; i < ChoicesCount; i++)
            {
                GameObject _instantiateButton = Instantiate(_buttonPrefab, _buttonsContainer);
                _choiceButtons.Enqueue(_instantiateButton);

                TextMeshProUGUI choiceButtonText = _instantiateButton.GetComponent<TextContainer>().ButtonText;
                choiceButtonText.text = text.Dequeue();
            }
        }

        public void DestroyChoices()
        {
            int ChoicesCount = _choiceButtons.Count;

            for (int i = 0; i < ChoicesCount; i++)
            {
                Destroy(_choiceButtons.Dequeue());
            }
        }
    }
}