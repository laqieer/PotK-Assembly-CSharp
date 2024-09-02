// Decompiled with JetBrains decompiler
// Type: StoryParser
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore.LispCore;
using MasterDataTable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UniLinq;
using UnityEngine;

#nullable disable
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

  private Cons parseArgs(string args, SExpReader reader)
  {
    return string.IsNullOrEmpty(args) ? (Cons) null : this.sexpReader.parse(args, true) as Cons;
  }

  private StoryBlock parseBlock(string text, List<string> funcs)
  {
    StringBuilder stringBuilder1 = new StringBuilder();
    StringBuilder stringBuilder2 = new StringBuilder();
    StoryBlock block = new StoryBlock();
    bool flag = false;
    IScriptParser scriptParser = (IScriptParser) null;
    int num1 = 0;
    string str1 = text;
    char[] chArray1 = new char[1]{ '\n' };
    foreach (string str2 in str1.Split(chArray1))
    {
      if (!str2.StartsWith(";") && str2.Length != 0)
      {
        string args1 = (string) null;
        string command = (string) null;
        switch (this.lineParser(str2, ref command, ref args1))
        {
          case "@":
            int id1 = 0;
            if (int.TryParse(command, out id1))
            {
              block.addScript("setname", SExp.cons((object) new SExpString(((IEnumerable<ScriptText>) MasterData.ScriptTextList).First<ScriptText>((Func<ScriptText, bool>) (x => x.ID == id1)).Text), (object) null));
              continue;
            }
            Debug.LogError((object) ("ID以外が入ってました" + command));
            block.addScript("setname", SExp.cons((object) new SExpString(command), (object) null));
            continue;
          case "#":
            if (funcs.Contains(command))
            {
              block.addScript(command, this.parseArgs(args1, this.reader));
              continue;
            }
            Cons args2 = this.parseArgs(args1, this.reader);
            string key = command;
            if (key != null)
            {
              // ISSUE: reference to a compiler-generated field
              if (StoryParser.\u003C\u003Ef__switch\u0024map1D == null)
              {
                // ISSUE: reference to a compiler-generated field
                StoryParser.\u003C\u003Ef__switch\u0024map1D = new Dictionary<string, int>(4)
                {
                  {
                    "label",
                    0
                  },
                  {
                    "script",
                    1
                  },
                  {
                    "{",
                    2
                  },
                  {
                    "}",
                    3
                  }
                };
              }
              int num2;
              // ISSUE: reference to a compiler-generated field
              if (StoryParser.\u003C\u003Ef__switch\u0024map1D.TryGetValue(key, out num2))
              {
                switch (num2)
                {
                  case 0:
                    if (SExp.car((object) args2) is SExpString sexpString1)
                    {
                      block.label = sexpString1.strValue;
                      continue;
                    }
                    continue;
                  case 1:
                    if (SExp.car((object) args2) is SExpString sexpString2)
                    {
                      string strValue = sexpString2.strValue;
                      if (strValue != null)
                      {
                        // ISSUE: reference to a compiler-generated field
                        if (StoryParser.\u003C\u003Ef__switch\u0024map1C == null)
                        {
                          // ISSUE: reference to a compiler-generated field
                          StoryParser.\u003C\u003Ef__switch\u0024map1C = new Dictionary<string, int>(1)
                          {
                            {
                              "lisp",
                              0
                            }
                          };
                        }
                        int num3;
                        // ISSUE: reference to a compiler-generated field
                        if (StoryParser.\u003C\u003Ef__switch\u0024map1C.TryGetValue(strValue, out num3) && num3 == 0)
                        {
                          scriptParser = (IScriptParser) new LispParser(this.reader);
                          continue;
                        }
                        continue;
                      }
                      continue;
                    }
                    continue;
                  case 2:
                    flag = true;
                    continue;
                  case 3:
                    if (scriptParser == null)
                      scriptParser = (IScriptParser) new LispParser(this.reader);
                    block.addScriptBody(scriptParser.parse(stringBuilder2.ToString()));
                    stringBuilder2 = new StringBuilder();
                    flag = false;
                    continue;
                }
              }
            }
            Debug.Log((object) (command + " コマンドが定義されていない"));
            continue;
          default:
            if (flag)
            {
              stringBuilder2.AppendLine(str2);
              continue;
            }
            int id2 = 0;
            if (int.TryParse(str2, out id2))
            {
              string text1 = ((IEnumerable<ScriptText>) MasterData.ScriptTextList).First<ScriptText>((Func<ScriptText, bool>) (x => x.ID == id2)).Text;
              char[] chArray2 = new char[1]{ '\n' };
              foreach (string str3 in text1.Split(chArray2))
              {
                stringBuilder1.AppendLine(str3);
                ++num1;
              }
              continue;
            }
            Debug.LogError((object) ("ID以外が入ってました" + str2));
            stringBuilder1.AppendLine("ID以外が入ってました" + str2);
            ++num1;
            continue;
        }
      }
    }
    if (stringBuilder1.ToString().EndsWith("\n"))
      stringBuilder1.Remove(stringBuilder1.Length - 1, 1);
    block.setText(stringBuilder1.ToString());
    return block;
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
