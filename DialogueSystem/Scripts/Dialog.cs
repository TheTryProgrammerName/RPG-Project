using System.Collections.Generic;

//Содержит все PhraseBlock диалога
//И PhraseLogicBlock
//Просто хранит данные и выдаёт DialogController'у
namespace DialogueSystem
{
    public class Dialog
    {
        private Queue<DialogBlock> DialogBlocks;

        public Dialog()
        {
            DialogBlocks = new Queue<DialogBlock>();
        }

        public void AddBlock(DialogBlock Block)
        {
            DialogBlocks.Enqueue(Block);
        }

        public DialogBlock GetDialogBlock()
        {
            return DialogBlocks.Dequeue();
        }

        public DialogBlock GetDialogBlock(string ID)
        {
            int DialogBlocksCount = DialogBlocks.Count;

            for (int i = 0; i < DialogBlocksCount; i++)
            {
                DialogBlock dialogBlock = DialogBlocks.Dequeue();

                if (dialogBlock.ID == ID)
                {
                    return dialogBlock;
                }
            }

            return null;
        }
    }
}