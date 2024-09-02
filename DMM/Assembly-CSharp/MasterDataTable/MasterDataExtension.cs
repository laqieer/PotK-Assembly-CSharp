// Decompiled with JetBrains decompiler
// Type: MasterDataTable.MasterDataExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterDataTable
{
  public static class MasterDataExtension
  {
    public static List<int> CommaSeparatedToInts(this string self)
    {
      if (string.IsNullOrEmpty(self))
        return new List<int>();
      string[] array = ((IEnumerable<string>) self.Split(',')).Select<string, string>((Func<string, string>) (s => s.Trim())).ToArray<string>();
      List<int> intList = new List<int>(array.Length);
      bool flag = true;
      foreach (string s in array)
      {
        int result;
        if (int.TryParse(s, out result))
        {
          intList.Add(result);
        }
        else
        {
          flag = false;
          break;
        }
      }
      if (flag)
        return intList;
      intList.Clear();
      foreach (string s in array)
      {
        double result;
        if (double.TryParse(s, out result))
        {
          int num = (int) Math.Floor(result);
          intList.Add(num);
        }
      }
      return intList;
    }
  }
}
