using System.Collections.Generic;

//���� ����. �������� ID ����, �� ������� Localizator ����������� �����
//���� ������ ����� ���� �� �� ��������
//����� ��������� � ChoiceBlock'�
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