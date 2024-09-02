// Decompiled with JetBrains decompiler
// Type: TutorialBattlePage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using UnityEngine;

#nullable disable
public class TutorialBattlePage : TutorialPageBase
{
  [SerializeField]
  private TutorialBattlePage.MESSAGE_TYPE messageType;
  [SerializeField]
  private int stageId;
  [SerializeField]
  private int deckId;
  private Dictionary<int, string> turnDict = new Dictionary<int, string>();

  [DebuggerHidden]
  public override IEnumerator Show()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialBattlePage.\u003CShow\u003Ec__Iterator65C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator startBattle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialBattlePage.\u003CstartBattle\u003Ec__Iterator65D()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void OnPlayerTurnStart(int turn)
  {
    string message;
    if (!this.turnDict.TryGetValue(turn, out message))
      return;
    this.advice.SetMessage(message);
  }

  public void OnBattleFinish() => this.StartCoroutine(this.finishLoop());

  [DebuggerHidden]
  private IEnumerator finishLoop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialBattlePage.\u003CfinishLoop\u003Ec__Iterator65E()
    {
      \u003C\u003Ef__this = this
    };
  }

  private Dictionary<int, string> parseTurnMessage(string message)
  {
    int key = -1;
    Dictionary<int, string> turnMessage = new Dictionary<int, string>();
    List<string> self = new List<string>();
    Regex regex = new Regex("#turn (\\d+)");
    string str = message;
    char[] chArray = new char[1]{ '\n' };
    foreach (string input in str.Split(chArray))
    {
      if (input.StartsWith("#"))
      {
        Match match = regex.Match(input);
        if (match.Success)
        {
          if (key >= 0)
          {
            turnMessage[key] = self.Join("\n");
            self.Clear();
          }
          key = int.Parse(match.Groups[1].Value);
        }
        else
          self.Add(input);
      }
      else
        self.Add(input);
    }
    turnMessage[key] = self.Join("\n");
    return turnMessage;
  }

  private enum MESSAGE_TYPE
  {
    BATTLE1,
    BATTLE2,
  }
}
