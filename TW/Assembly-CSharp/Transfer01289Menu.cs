// Decompiled with JetBrains decompiler
// Type: Transfer01289Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Transfer01289Menu : MonoBehaviour
{
  [SerializeField]
  protected UILabel TxtDescription;

  public void ChangeDescription(string errorCode)
  {
    string key = errorCode;
    string text;
    if (key != null)
    {
      // ISSUE: reference to a compiler-generated field
      if (Transfer01289Menu.\u003C\u003Ef__switch\u0024map1D == null)
      {
        // ISSUE: reference to a compiler-generated field
        Transfer01289Menu.\u003C\u003Ef__switch\u0024map1D = new Dictionary<string, int>(3)
        {
          {
            "ASE001",
            0
          },
          {
            "ASE010",
            1
          },
          {
            "unknown",
            2
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (Transfer01289Menu.\u003C\u003Ef__switch\u0024map1D.TryGetValue(key, out num))
      {
        switch (num)
        {
          case 0:
            text = Consts.GetInstance().POPUP_012_8_9_ASE001_TEXT;
            goto label_9;
          case 1:
            text = Consts.GetInstance().POPUP_012_8_9_ASE010_TEXT;
            goto label_9;
          case 2:
            text = Consts.GetInstance().POPUP_012_8_9_UNKNOWN_TEXT;
            goto label_9;
        }
      }
    }
    text = Consts.Format(Consts.GetInstance().POPUP_012_8_9_OTHER_TEXT, (IDictionary) new Hashtable()
    {
      {
        (object) "error_code",
        (object) errorCode
      }
    });
label_9:
    this.TxtDescription.SetTextLocalize(text);
  }

  public string TimeIntToString(int time)
  {
    string empty = string.Empty;
    return time >= 0 && time < 10 ? "０" + time.ToLocalizeNumberText() : time.ToLocalizeNumberText();
  }
}
