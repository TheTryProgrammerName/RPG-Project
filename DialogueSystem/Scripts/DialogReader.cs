using System.Collections.Generic;
using System.Xml;

namespace DialogueSystem
{
    public class DialogReader
    {
        private XMLReader _XMLReader;

        public Dialog Read(string pathToFile)
        {
            _XMLReader = new XMLReader();
            XmlElement DialogFile = _XMLReader.Read(pathToFile);
            List<XmlElement> Blocks = SortFile(DialogFile);

            Dialog Dialog = new Dialog();

            for (int i = 0; i < Blocks.Count; i++)
            {
                DialogBlock dialogBlock = new DialogBlock();
                dialogBlock.ID = GetBlockID(Blocks[i]);

                List<XmlElement> SortBlocks = SortBlock(Blocks[i]);
                PhraseBlock phraseBlock = ReadPhrases(SortBlocks[0]);
                ChoiceBlock choiceBlock = ReadChoices(SortBlocks[1]);

                dialogBlock.AddPhraseBlock(phraseBlock);
                dialogBlock.AddChoiceBlock(choiceBlock);

                Dialog.AddBlock(dialogBlock);
            }

            return Dialog;
        }

        private List<XmlElement> SortFile(XmlElement File)
        {
            List<XmlElement> Blocks = new List<XmlElement>();

            foreach (XmlElement BlockNode in File)
            {
                Blocks.Add(BlockNode);
            }

            return Blocks;
        }

        private string GetBlockID(XmlElement Block)
        {
            return Block.GetAttribute("id");
        }

        //Выдаёт phrases и choices
        private List<XmlElement> SortBlock(XmlElement Block)
        {
            List<XmlElement> SortBlock = new List<XmlElement>();

            foreach (XmlElement Nodes in Block)
            {
                SortBlock.Add(Nodes);
            }

            return SortBlock;
        }

        //Считывает все фразы по порядку
        private PhraseBlock ReadPhrases(XmlElement PhrasesBlock)
        {
            PhraseBlock phraseBlock = new PhraseBlock();

            foreach (XmlElement PhraseNode in PhrasesBlock)
            {
                foreach (XmlNode PhraseChildren in PhraseNode.ChildNodes)
                {
                    phraseBlock.AddPhraseID(PhraseChildren.InnerText);
                }
            }

            return phraseBlock;
        }

        private ChoiceBlock ReadChoices(XmlElement ChoicesBlock)
        {
            ChoiceBlock choiceBlock = new ChoiceBlock();

            foreach (XmlElement ChoiceNode in ChoicesBlock)
            {
                Choice choice = new Choice();

                foreach (XmlNode ChoiceChildren in ChoiceNode.ChildNodes)
                {
                    if (ChoiceChildren.Name == "text")
                    {
                        choice.PhraseKey = ChoiceChildren.InnerText;
                    }
                    else
                    {
                        choice.NextBlock = ChoiceChildren.InnerText;
                    }
                }

                choiceBlock.AddChoice(choice);
            }

            return choiceBlock;
        }
    }
}