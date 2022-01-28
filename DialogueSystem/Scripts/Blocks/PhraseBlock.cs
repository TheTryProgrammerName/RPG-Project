using System.Collections.Generic;

//Блок фраз. Содержит ID фраз, по которым Localizator подставляет текст
//Игра достаёт текст пока он не кончится
//Потом переходит к ChoiceBlock'у
namespace DialogueSystem
{
    public class PhraseBlock
    {
        private Queue<string> PhrasesID;

        public void Create()
        {
            PhrasesID = new Queue<string>();
        }

        public void AddPhraseID(string ID)
        {
            PhrasesID.Enqueue(ID);
        }

        public string GetPhraseID()
        {
            if (GetPhrasesIDCount() > 0)
            {
                return PhrasesID.Dequeue();
            }
            else
            {
                return null;
            }
        }

        public int GetPhrasesIDCount()
        {
            return PhrasesID.Count;
        }
    }
}