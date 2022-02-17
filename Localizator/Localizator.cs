using UnityEngine;
using System.Xml;
using System.Collections.Generic;
using System.IO;

//Кто угодно скармливает ему ключ, а он возвращает текст
public class Localizator : MonoBehaviour
{
    private string _language = "Rus"; //Грузить всё это из конфига
    private static string _pathToText = "C:\\Users\\Vasa\\Documents\\Unity Projects\\RPG Project\\Assets\\Text\\";
    private string[] _textFiles;

    private XMLReader _XMLReader;

    private List<Phrase> _phrasesList;

    public void Initialize()
    {
        _XMLReader = new XMLReader();
        _phrasesList = new List<Phrase>();
        GetFiles();
        ReadFiles();
    }

    public void ChangeLanguage()
    {

    }

    private void GetFiles()
    {
        _textFiles = Directory.GetFiles(_pathToText + _language, "*.xml", SearchOption.AllDirectories);
    }

    private void ReadFiles()
    {
        for (int i = 0; i < _textFiles.Length; i++)
        {
            XmlElement File = _XMLReader.Read(_textFiles[i]);
            SortFile(File);
        }
    }

    private void SortFile(XmlElement File)
    {
        foreach (XmlElement Phrase in File)
        {
            Phrase phrase = new Phrase();

            phrase.Key = Phrase.GetAttribute("id");

            foreach (XmlNode text in Phrase.ChildNodes)
            {
                phrase.Text = text.InnerText;
            }

            _phrasesList.Add(phrase);
        }
    }

    public string GetText(string key)
    {
        for (int i = 0; i < _phrasesList.Count; i++)
        {
            Phrase phrase = _phrasesList[i];

            if (phrase.Key == key)
            {
                return phrase.Text;
            }
        }

        return key;
    }
}

public class Phrase
{
    public string Key;
    public string Text;
}