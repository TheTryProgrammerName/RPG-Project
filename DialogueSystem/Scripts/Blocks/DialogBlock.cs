using System.Collections.Generic;

namespace DialogueSystem
{
    public class DialogBlock
    {
        private string BlockID;

        private Queue<PhraseBlock> PhraseBlocks;
        private Queue<ChoiceBlock> ChoiceBlocks;

        public void Create()
        {
            PhraseBlocks = new Queue<PhraseBlock>();
            ChoiceBlocks = new Queue<ChoiceBlock>();
        }

        public void AddID(string ID)
        {
            BlockID = ID;
        }

        public string GetID()
        {
            return BlockID;
        }

        public void AddPhraseBlock(PhraseBlock AddedBlock)
        {
            PhraseBlocks.Enqueue(AddedBlock);
        }

        public void AddChoiceBlock(ChoiceBlock AddedBlock)
        {
            ChoiceBlocks.Enqueue(AddedBlock);
        }

        public PhraseBlock GetPhraseBlock()
        {
            if (PhraseBlocks.Count > 0)
            {
                return PhraseBlocks.Dequeue();
            }
            else
            {
                return null;
            }
        }

        public ChoiceBlock GetChoiceBlock()
        {
            if (ChoiceBlocks.Count > 0)
            {
                return ChoiceBlocks.Dequeue();
            }
            else
            {
                return null;
            }
        }
    }
}