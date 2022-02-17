using System.Collections.Generic;

public class LtxFile
{
    private Queue<Section> Sections;

    public void Create()
    {
        Sections = new Queue<Section>();
    }

    public void AddSection(Section section)
    {
        Sections.Enqueue(section);
    }

    public Section GetSection()
    {
        return Sections.Dequeue();
    }

    public Section GetSection(string name)
    {
        int SectionsCount = Sections.Count;

        for (int i = 0; i < SectionsCount; i++)
        {
            Section section = Sections.Dequeue();

            if (section.GetName() == name)
            {
                return section;
            }
        }

        return null;
    }
}

public class Section 
{
    private string Name;
    private Queue<Parametr> Parametrs;

    public Section()
    {
        Parametrs = new Queue<Parametr>();
    }

    public void AddName(string name)
    {
        Name = name;
    }

    public void AddParametr(Parametr parametr)
    {
        Parametrs.Enqueue(parametr);
    }

    public string GetName()
    {
        return Name;
    }

    public int GetParametrsCount()
    {
        return Parametrs.Count;
    }

    public Parametr GetParametr()
    {
        return Parametrs.Dequeue();
    }

    public Queue<Parametr> GetParametrs()
    {
        return Parametrs;
    }
}

public class Parametr
{
    public string Name;
    public string Value;
}