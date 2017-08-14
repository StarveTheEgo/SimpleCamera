// Decompiled with JetBrains decompiler
// Type: SimpleCamera.Settings
// Assembly: SimpleCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.ComponentModel;
namespace SimpleCamera
{
  internal class Settings
  {
    private static Hashtable settings = (Hashtable) null;
    private static readonly string FILENAME = "SimpleCamera.xml";

    public static void saveSettings()
    {
      if (Settings.settings == null)
        return;
      XmlTextWriter xmlTextWriter = new XmlTextWriter(Settings.FILENAME, (Encoding) null);
      xmlTextWriter.Formatting = Formatting.Indented;
      xmlTextWriter.WriteStartDocument();
      xmlTextWriter.WriteComment("SimpleCamera settings file");
      xmlTextWriter.WriteStartElement("Settings");
      foreach (string key in (IEnumerable) Settings.settings.Keys)
      {
        xmlTextWriter.WriteStartElement(key);
        xmlTextWriter.WriteString((string) Settings.settings[(object) key]);
        xmlTextWriter.WriteEndElement();
      }
      xmlTextWriter.WriteEndElement();
      xmlTextWriter.WriteEndDocument();
      xmlTextWriter.Close();
    }

    public static void loadSettings()
    {
      Settings.settings = new Hashtable();
      if (!File.Exists(Settings.FILENAME))
        return;
      XmlTextReader xmlTextReader = new XmlTextReader(Settings.FILENAME);
      while (xmlTextReader.Read())
      {
        if (xmlTextReader.NodeType == XmlNodeType.Element && !xmlTextReader.Name.Equals("Settings"))
          Settings.settings[(object) xmlTextReader.Name] = (object) xmlTextReader.ReadElementContentAsString();
      }
      xmlTextReader.Close();
    }

    public static int getSettingInt(string key, int def)
    {
      string setting = Settings.getSetting(key);
      if (setting == null)
        return def;
      return int.Parse(setting);
    }

    public static float getSettingFloat(string key, float def)
    {
      string setting = Settings.getSetting(key);
      if (setting == null)
        return def;
      return float.Parse(setting);
    }

    public static Keys getSettingKey(string key, Keys def)
    {
      string setting = Settings.getSetting(key);
      if (setting == null)
        return def;
      TypeConverter converter = TypeDescriptor.GetConverter(typeof(Keys));
      Keys deer = ((Keys)converter.ConvertFromString(setting));
      return (Keys)converter.ConvertFromString(setting);
    }

    public static string getSettingString(string key, string def)
    {
      return Settings.getSetting(key) ?? def;
    }

    public static bool getSettingBool(string key, bool def)
    {
      return Settings.getSettingInt(key, def ? 1 : 0) != 0;
    }

    private static string getSetting(string key)
    {
      if (Settings.settings == null)
        Settings.loadSettings();
      return (string) Settings.settings[(object) key];
    }

    public static void setSetting(string key, string value)
    {
      Settings.settings[(object) key] = (object) value;
    }

    public static void setSetting(string key, int value)
    {
      Settings.settings[(object) key] = (object) string.Concat((object) value);
    }

    public static void setSetting(string key, bool value)
    {
      Settings.settings[(object) key] = (object) string.Concat((object) (value ? 1 : 0));
    }

    public static void setSetting(string key, Keys value)
    {
      Settings.settings[(object) key] = (object) string.Concat((object) value);
    }
  }
}
