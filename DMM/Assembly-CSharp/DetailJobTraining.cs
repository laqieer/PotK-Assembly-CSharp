// Decompiled with JetBrains decompiler
// Type: DetailJobTraining
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class DetailJobTraining : MonoBehaviour
{
  [SerializeField]
  private SpreadColorButton button;
  [SerializeField]
  private UILabel txtMenuName;
  [SerializeField]
  private GameObject txtUnopended;
  public UIDragScrollView dragScrollView;

  public IEnumerator Init(string menuName, bool isActive, System.Action callFunction)
  {
    this.txtMenuName.text = menuName;
    this.SetActive(isActive);
    if (isActive)
      EventDelegate.Add(this.button.onClick, (EventDelegate.Callback) (() => callFunction()));
    yield return (object) new WaitForEndOfFrame();
  }

  private void SetActive(bool active)
  {
    this.button.isEnabled = active;
    this.txtUnopended.SetActive(!active);
  }
}
