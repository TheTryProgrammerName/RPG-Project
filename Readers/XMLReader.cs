using System.Xml;

public class XMLReader
{
    public XmlElement Read(string pathToFile)
    {
        XmlDocument _xmlDocument = new XmlDocument();
        _xmlDocument.Load(pathToFile);
        XmlElement File = _xmlDocument.DocumentElement;

        return File;
    }
}
