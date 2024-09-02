// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Example.LogView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity.Example
{
  internal class LogView : ConsoleBase
  {
    private static string datePatt = "M/d/yyyy hh:mm:ss tt";
    private static IList<string> events = (IList<string>) new List<string>();

    public static void AddLog(string log)
    {
      LogView.events.Insert(0, string.Format("{0}\n{1}\n", (object) DateTime.Now.ToString(LogView.datePatt), (object) log));
    }

    protected void OnGUI()
    {
    }
  }
}
