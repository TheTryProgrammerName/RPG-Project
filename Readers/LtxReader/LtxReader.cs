using System.Collections.Generic;
using System.IO;

public class LtxReader
{
    public LtxFile Read(string pathToFile)
    {
        Queue<string> File = ReadFile(pathToFile);
        Queue<string> FileWithoutComments = SeparateComments(File);

        LtxFile LtxFile = new LtxFile();
        LtxFile.Create();

        while (FileWithoutComments.Count > 0)
        {
            Queue<string> SectionStrings = ReadSection(FileWithoutComments);
            Section section = SortSection(SectionStrings);
            LtxFile.AddSection(section);
        }

        return LtxFile;
    }

    private Queue<string> ReadFile(string pathToFile)
    {
        Queue<string> text = new Queue<string>();

        using (StreamReader streamReader = new StreamReader(pathToFile))
        {
            string line;

            while ((line = streamReader.ReadLine()) != null)
            {
                text.Enqueue(line);
            }
        }

        return text;
    }

    private Queue<string> SeparateComments(Queue<string> strings)
    {
        int stringsCount = strings.Count;
        Queue<string> stringsWithoutComments = new Queue<string>();

        for (int i = 0; i < stringsCount; i++)
        {
            string stringWithoutComments = strings.Dequeue().Split(';')[0];
            stringsWithoutComments.Enqueue(stringWithoutComments);
        }

        return stringsWithoutComments;
    }

    private Queue<string> ReadSection(Queue<string> strings) //Получаем чиатем файл до следующей секции
    {
        Queue<string> section = new Queue<string>();

        bool isSectionGetted = false;

        int stringsCount = strings.Count;

        for (int i = 0; i < stringsCount; i++)
        {
            string fileString = strings.Dequeue();
            string[] splitString = fileString.Split('[', ']');

            if (splitString.Length == 3)
            {
                if (!isSectionGetted)
                {
                    section.Enqueue(fileString);
                }
                else
                {
                    return section;
                }

                isSectionGetted = true;
            }
            else
            {
                section.Enqueue(fileString);
            }
        }

        return section;
    }

    private Section SortSection(Queue<string> SectionStrings) //Получаем параметры секции
    {
        int SectionStringsCount = SectionStrings.Count;

        Section section = new Section();

        for (int i = 0; i < SectionStringsCount; i++)
        {
            if (i == 0)
            {
                string SectionName = SectionStrings.Dequeue().Split('[', ']')[1];
                section.AddName(SectionName);
            }
            else
            {
                Parametr parametr = new Parametr();
                string[] parametrString = SectionStrings.Dequeue().Split('=');

                parametr.Name = parametrString[0];
                parametr.Value = parametrString[1];

                section.AddParametr(parametr);
            }
        }

        return section;
    }
}
