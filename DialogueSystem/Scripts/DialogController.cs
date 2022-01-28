using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

//Берёт данные из диалога и занимается обработкой:
//Переключает фразы, совершает выбор и т.д.
namespace DialogueSystem
{
    public class DialogController : MonoBehaviour
    {
        [SerializeField] private UIController UIController;
        [SerializeField] private DialogDrawer _dialogDrawer;
        [SerializeField] private InputManager _InputManager;
        [SerializeField] private Localizator _localizator;

        [SerializeField] private Transform _buttonsContainer;

        private DialogReader _dialogReader;
        private Dialog _dialog;
        private DialogBlock _dialogBlock;
        private PhraseBlock _phraseBlock;

        private Utilits _utilits = new Utilits();

        private bool _dialogueStarted;

        //Грузить из конфига
        private string _pathToDialogsFloder = "C:\\Users\\Vasa\\Documents\\Unity Projects\\RPG Project\\Assets\\DialogueSystem\\Dialogs\\";

        public void Initialize()
        {
            _dialogReader = new DialogReader();
            LoadDialog("Dialog1.xml"); //Убрать это отсюда
            UIController.SetPreset("Dialog"); //Убрать это отсюда
        }

        public void UpdateDialog()
        {
            if (!_dialogueStarted)
            {
                _dialogBlock = _dialog.GetDialogBlock();
                _phraseBlock = _dialogBlock.GetPhraseBlock();
                _dialogueStarted = true;
            }

            ShowPhrase(_phraseBlock);

            if (_phraseBlock.GetPhrasesIDCount() == 0)
            {
                ChoiceBlock choiceBlock = _dialogBlock.GetChoiceBlock();
                ShowChoices(choiceBlock);
            }
        }

        private void LoadDialog(string DialogName)
        {
            _dialog = _dialogReader.Read(_pathToDialogsFloder + DialogName);
        }

        private void ShowPhrase(PhraseBlock phraseBlock)
        {
            string PhraseText = _localizator.GetText(phraseBlock.GetPhraseID());

            _dialogDrawer.DrawPhrase(PhraseText);
        }

        private void ShowChoices(ChoiceBlock choiceBlock) //Показывает кнопки
        {
            Queue<Choice> Choices = choiceBlock.GetChoices();

            Queue<string> ChoicesText = new Queue<string>();
            Queue<string> ChoicesLogic = new Queue<string>();

            int ChoicesCount = Choices.Count;

            for (int i = 0; i < ChoicesCount; i++)
            {
                Choice choice = Choices.Dequeue();

                string ChoiceText = _localizator.GetText(choice.GetPhraseID());
                string ChoiceLogic = choice.GetNextBlock();

                ChoicesText.Enqueue(ChoiceText);
                ChoicesLogic.Enqueue(ChoiceLogic);
            }

            _dialogDrawer.DrawChoices(ChoicesText);
            UIController.SetPreset("Choice");
            AddChoices(ChoicesLogic);

            _InputManager.LockControl();
        }

        private void AddChoices(Queue<string> ChoicesLogic) //Задаёт выбор
        {
            Queue<GameObject> ChoiceButtons = _utilits.GetChildren(_buttonsContainer);

            int ButtonsCount = ChoiceButtons.Count;

            for (int i = 0; i < ButtonsCount; i++)
            {
                Button ChoiceButton = ChoiceButtons.Dequeue().GetComponent<Button>();
                string BlockID = ChoicesLogic.Dequeue();
                ChoiceButton.onClick.AddListener(() => SwitchBlock(BlockID));
            }
        }

        private void SwitchBlock(string BlockID)
        {
            _dialogBlock = _dialog.GetDialogBlock(BlockID);
            _phraseBlock = _dialogBlock.GetPhraseBlock();

            UIController.SetInvertPreset("Choice");
            _dialogDrawer.DestroyChoices();
            _InputManager.UnlockControl();

            UpdateDialog();
        }
    }
}
