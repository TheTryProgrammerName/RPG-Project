using System.Collections.Generic;

//Игра достаёт сразу все Choices
//Отрисовывает и переходит к NextBlock
//Взависимости от выбора
namespace DialogueSystem
{
    public class ChoiceBlock
    {
        private Queue<Choice> Choices;

        public void Create()
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
        private string PhraseID;
        private string NextBlock;

        public void AddPhraseID(string phraseID)
        {
            PhraseID = phraseID;
        }

        public string GetPhraseID()
        {
            return PhraseID;
        }

        public void AddNextBlock(string nextBlock)
        {
            NextBlock = nextBlock;
        }

        public string GetNextBlock()
        {
            return NextBlock;
        }
    }
}