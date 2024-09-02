// Decompiled with JetBrains decompiler
// Type: StoryParser
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore.LispCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class StoryParser
{
  private static Regex lineRegexp = new Regex("(?<prefix>(#|@))\\s*((?<command>\\S+)\\s+(?<args>.*)|(?<command>\\S+)|)");
  private SExpReader sexpReader = new SExpReader();
  private SExpReader reader = new SExpReader();

  private string lineParser(string line, ref string command, ref string args)
  {
    Match match = StoryParser.lineRegexp.Match(line);
    if (!match.Success)
      return (string) null;
    command = match.Groups[nameof (command)].Value;
    args = match.Groups[nameof (args)].Value;
    return match.Groups["prefix"].Value;
  }

  private Cons parseArgs(string args, SExpReader reader) => string.IsNullOrEmpty(args) ? (Cons) null : this.sexpReader.parse(args, true) as Cons;

  private StoryBlock parseBlock(string text, List<string> funcs)
  {
    StringBuilder stringBuilder1 = new StringBuilder();
    StringBuilder stringBuilder2 = new StringBuilder();
    StoryBlock storyBlock = new StoryBlock();
    bool flag = false;
    IScriptParser scriptParser = (IScriptParser) null;
    int num = 0;
    string str1 = text;
    char[] chArray = new char[1]{ '\n' };
    foreach (string line in str1.Split(chArray))
    {
      if (!line.StartsWith(";") && line.Length != 0)
      {
        string args1 = (string) null;
        string command = (string) null;
        string str2 = this.lineParser(line, ref command, ref args1);
        if (str2 == "@")
          storyBlock.addScript("setname", SExp.cons((object) new SExpString(command), (object) null));
        else if (str2 == "#")
        {
          if (funcs.Contains(command))
          {
            storyBlock.addScript(command, this.parseArgs(args1, this.reader));
          }
          else
          {
            Cons args2 = this.parseArgs(args1, this.reader);
            if (!(command == "label"))
            {
              if (!(command == "script"))
              {
                if (!(command == "{"))
                {
                  if (command == "}")
                  {
                    if (scriptParser == null)
                      scriptParser = (IScriptParser) new LispParser(this.reader);
                    storyBlock.addScriptBody(scriptParser.parse(stringBuilder2.ToString()));
                    stringBuilder2 = new StringBuilder();
                    flag = false;
                  }
                  else
                    UnityEngine.Debug.Log((object) (command + " コマンドが定義されていない"));
                }
                else
                  flag = true;
              }
              else if (SExp.car((object) args2) is SExpString sexpString && sexpString.strValue == "lisp")
                scriptParser = (IScriptParser) new LispParser(this.reader);
            }
            else if (SExp.car((object) args2) is SExpString sexpString)
              storyBlock.label = sexpString.strValue;
          }
        }
        else if (flag)
        {
          stringBuilder2.AppendLine(line);
        }
        else
        {
          stringBuilder1.AppendLine(line);
          ++num;
        }
      }
    }
    if (stringBuilder1.ToString().EndsWith("\n"))
      stringBuilder1.Remove(stringBuilder1.Length - 1, 1);
    storyBlock.setText(stringBuilder1.ToString());
    return storyBlock;
  }

  public List<StoryBlock> parse(string text, Dictionary<string, object> env)
  {
    List<StoryBlock> storyBlockList = new List<StoryBlock>();
    List<string> funcs = new List<string>();
    foreach (KeyValuePair<string, object> keyValuePair in env)
    {
      if (Lisp.functionp(keyValuePair.Value).Value)
        funcs.Add(keyValuePair.Key);
    }
    string str = text;
    string[] separator = new string[1]{ "\n\n" };
    foreach (string text1 in str.Split(separator, StringSplitOptions.RemoveEmptyEntries))
    {
      try
      {
        storyBlockList.Add(this.parseBlock(text1, funcs));
      }
      catch (Exception ex)
      {
        Debug.LogError((object) ("stroy parse error e : " + (object) ex));
      }
    }
    return storyBlockList;
  }
}
