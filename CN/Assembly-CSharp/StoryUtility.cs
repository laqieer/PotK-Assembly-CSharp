// Decompiled with JetBrains decompiler
// Type: StoryUtility
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UniLinq;

#nullable disable
public class StoryUtility
{
  private static Regex lineRegexp = new Regex("(?<prefix>(#|@))\\s*((?<command>\\S+)\\s+(?<args>.*)|(?<command>\\S+)|)");

  private static string lineParser(string line, out string command, out string args)
  {
    Match match = StoryUtility.lineRegexp.Match(line);
    if (match.Success)
    {
      command = match.Groups[nameof (command)].Value;
      args = match.Groups[nameof (args)].Value;
      return match.Groups["prefix"].Value;
    }
    command = (string) null;
    args = (string) null;
    return (string) null;
  }

  public static IEnumerable<UnitUnit> GetUnits(int scriptId)
  {
    if (!MasterData.ScriptScript.ContainsKey(scriptId))
      return Enumerable.Empty<UnitUnit>();
    string[] strArray1 = MasterData.ScriptScript[scriptId].script.Split('\n');
    HashSet<UnitUnit> units = new HashSet<UnitUnit>();
    foreach (string line in strArray1)
    {
      if (!line.StartsWith(";") && line.Length != 0)
      {
        string args = (string) null;
        string command = (string) null;
        if (StoryUtility.lineParser(line, out command, out args) == "#" && (command == "chara" || command == "body"))
        {
          string[] strArray2 = args.Split(' ', '\t');
          int result;
          if (strArray2.Length != 0 && int.TryParse(strArray2[0], out result) && MasterData.UnitUnit.ContainsKey(result))
            units.Add(MasterData.UnitUnit[result]);
        }
      }
    }
    return (IEnumerable<UnitUnit>) units;
  }
}
