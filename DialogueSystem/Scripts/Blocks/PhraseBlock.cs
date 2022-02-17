using System.Collections.Generic;

//���� ����. �������� ����� ����, �� ������� Localizator ����������� �����
//���� ������ ����� ���� �� �� ��������
//����� ��������� � ChoiceBlock'�
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