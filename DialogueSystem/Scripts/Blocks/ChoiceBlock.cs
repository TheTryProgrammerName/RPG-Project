using System.Collections.Generic;

//���� ������ ����� ��� Choices
//������������ � ��������� � NextBlock
//������������ �� ������
namespace DialogueSystem
{
    public class ChoiceBlock
    {
        private Queue<Choice> Choices;

        public ChoiceBlock()
        {
            Choices = new Queue<Choice>();
        }

        public void AddChoice(Choice AddedChoice)
        {
            Choices.Enqueue(AddedChoice);
        }

        public Queue<Choice> GetChoices()
        {
            return Choices;
        }
    }

    public class Choice
    {
        public string PhraseKey;
        public string NextBlock;
    }
}