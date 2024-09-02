// Decompiled with JetBrains decompiler
// Type: GotoHelp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[AddComponentMenu("Utility/Behaviour/GotoHelp")]
public class GotoHelp : MonoBehaviour
{
  [SerializeField]
  [Tooltip("親メニュー")]
  private NGMenuBase rootMenu_;
  [SerializeField]
  [Tooltip("ヘルプIDを列挙('help_'よりこちらを優先する)")]
  private int[] helpIDs_;
  [SerializeField]
  [Tooltip("ヘルプタイトル")]
  private string help_;
  [SerializeField]
  [Tooltip("ヘルプ遷移時にポップアップを全て閉じる")]
  private bool closeAllPopup_ = true;

  public Func<bool> onClickedButton { get; set; }

  private NGMenuBase root => !((UnityEngine.Object) this.rootMenu_ != (UnityEngine.Object) null) ? (this.rootMenu_ = NGUITools.FindInParents<NGMenuBase>(this.gameObject)) : this.rootMenu_;

  public void onClickedHelp()
  {
    NGMenuBase root = this.root;
    if ((UnityEngine.Object) root != (UnityEngine.Object) null && root.IsPushAndSet())
      return;
    if (this.onClickedButton == null)
      this.onClickedButton = new Func<bool>(this.defaultClickedButton);
    if (!this.onClickedButton())
    {
      if (!((UnityEngine.Object) root != (UnityEngine.Object) null))
        return;
      root.IsPush = false;
    }
    else
    {
      if (!this.closeAllPopup_ || !Singleton<PopupManager>.GetInstance().isOpen)
        return;
      Singleton<PopupManager>.GetInstance().closeAll();
    }
  }

  private bool defaultClickedButton()
  {
    List<HelpHelp> helpHelpList = this.helpIDs_ == null || this.helpIDs_.Length == 0 ? (List<HelpHelp>) null : ((IEnumerable<HelpHelp>) MasterData.HelpHelpList).Where<HelpHelp>((Func<HelpHelp, bool>) (x => ((IEnumerable<int>) this.helpIDs_).Contains<int>(x.ID))).ToList<HelpHelp>();
    if (helpHelpList != null && helpHelpList.Any<HelpHelp>())
    {
      Help0152Scene.ChangeScene(true, helpHelpList);
      return true;
    }
    if (string.IsNullOrEmpty(this.help_))
      return false;
    HelpCategory helpCategory = Array.Find<HelpCategory>(MasterData.HelpCategoryList, (Predicate<HelpCategory>) (x => x.name == this.help_));
    if (helpCategory == null)
      return false;
    Help0152Scene.ChangeScene(true, helpCategory);
    return true;
  }
}
