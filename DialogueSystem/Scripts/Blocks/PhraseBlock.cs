using System.Collections.Generic;

//Блок фраз. Содержит ключи фраз, по которым Localizator подставляет текст
//Игра достаёт текст пока он не кончится
//Потом переходит к ChoiceBlock'у
namespace DialogueSystem
{
    public class PhraseBlock
    {
        private Queue<string> PhrasesKeys;

        public PhraseBlock()
        {
            PhrasesKeys = new Queue<string>();
        }

        public void AddPhraseID(string ID)
        {
            PhrasesKeys.Enqueue(ID);
        }

        public string GetPhraseID()
        {
            if (GetPhrasesIDCount() > 0)
            {
                return PhrasesKeys.Dequeue();
            }
            else
            {
                return null;
            }
        }

        public int GetPhrasesIDCount()
        {
            return PhrasesKeys.Count;
        }
    }
}