// Decompiled with JetBrains decompiler
// Type: Transfer01289Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class Transfer01289Menu : MonoBehaviour
{
  [SerializeField]
  protected UILabel TxtDescription;

  public void ChangeDescription(string errorCode)
  {
    string text;
    if (!(errorCode == "ASE001"))
    {
      if (!(errorCode == "ASE010"))
      {
        if (errorCode == "unknown")
          text = Consts.GetInstance().POPUP_012_8_9_UNKNOWN_TEXT;
        else
          text = Consts.Format(Consts.GetInstance().POPUP_012_8_9_OTHER_TEXT, (IDictionary) new Hashtable()
          {
            {
              (object) "error_code",
              (object) errorCode
            }
          });
      }
      else
        text = Consts.GetInstance().POPUP_012_8_9_ASE010_TEXT;
    }
    else
      text = Consts.GetInstance().POPUP_012_8_9_ASE001_TEXT;
    this.TxtDescription.SetTextLocalize(text);
  }

  public string TimeIntToString(int time) => time >= 0 && time < 10 ? "０" + time.ToLocalizeNumberText() : time.ToLocalizeNumberText();
}
