// Decompiled with JetBrains decompiler
// Type: HeadLabelExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class HeadLabelExtension
{
  public static bool SetTextHeadline(
    this UILabel self,
    string text,
    int lengthPerLine,
    int maxLine = 1)
  {
    if ((UnityEngine.Object) self == (UnityEngine.Object) null)
      return false;
    string text1 = text.Replace("\r\n", "\n").Replace("\r", "\n");
    int num = lengthPerLine * maxLine;
    bool flag = false;
    if (!string.IsNullOrEmpty(text1) && num > 0)
    {
      string str1 = "．．．";
      if (text1.Length > num)
      {
        flag = true;
        text1 = text1.Replace("\n", "").Substring(0, num - str1.Length) + str1;
      }
      else if (text1.Length > maxLine)
      {
        string[] strArray = text1.Split('\n');
        if (strArray.Length > 1)
        {
          if (strArray.Length > maxLine)
            flag = true;
          else if (((IEnumerable<string>) strArray).Max<string>((Func<string, int>) (x => x.Length)) > lengthPerLine)
            flag = true;
          if (flag)
          {
            int count = Mathf.Min(strArray.Length - 1, maxLine - 1);
            string str2 = count <= 0 ? string.Empty : string.Join("\n", ((IEnumerable<string>) strArray).Take<string>(count).ToArray<string>());
            text1 = (strArray[count].Length + str1.Length <= lengthPerLine ? str2 + strArray[count] : str2 + strArray[count].Substring(0, lengthPerLine - str1.Length)) + str1;
          }
        }
      }
    }
    self.SetTextLocalize(text1);
    return flag;
  }
}
