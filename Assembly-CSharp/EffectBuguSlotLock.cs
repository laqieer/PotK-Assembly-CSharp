// Decompiled with JetBrains decompiler
// Type: EffectBuguSlotLock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class EffectBuguSlotLock : MonoBehaviour
{
  [SerializeField]
  private UIButton btnBugu_;
  [SerializeField]
  private Animator animator_;
  [SerializeField]
  private GameObject animaBaseObj_;
  [SerializeField]
  private Transform animaTrans_;
  [SerializeField]
  [Tooltip("開錠演出時間(秒)")]
  private float wait_ = 2f;
  private GameObject cloneAnimaObj;
  private EffectBuguSlot buguSlot;

  public void slotActive(bool active)
  {
    if ((UnityEngine.Object) this.cloneAnimaObj == (UnityEngine.Object) null)
    {
      this.animaBaseObj_.SetActive(true);
      this.cloneAnimaObj = this.animaBaseObj_.Clone(this.animaTrans_);
      this.buguSlot = this.cloneAnimaObj.GetComponent<EffectBuguSlot>();
      this.animator_ = this.cloneAnimaObj.GetComponent<Animator>();
      this.animaBaseObj_.SetActive(false);
    }
    if ((bool) (UnityEngine.Object) this.animator_)
      this.animator_.enabled = active;
    if ((bool) (UnityEngine.Object) this.btnBugu_)
      this.btnBugu_.isEnabled = active;
    if (!(bool) (UnityEngine.Object) this.buguSlot)
      return;
    this.buguSlot.slotActive(active);
  }

  public void setUnity(string unity) => this.buguSlot.setUnity(unity);

  public void ResetAnimation()
  {
    UnityEngine.Object.Destroy((UnityEngine.Object) this.cloneAnimaObj);
    this.cloneAnimaObj = (GameObject) null;
    this.buguSlot = (EffectBuguSlot) null;
    this.animator_ = (Animator) null;
  }

  public void startUnlock(System.Action onFinished)
  {
    Singleton<NGSoundManager>.GetInstance().PlaySe("SE_2712");
    this.StartCoroutine(this.waitAnimation(onFinished));
  }

  private IEnumerator waitAnimation(System.Action onFinished)
  {
    if ((bool) (UnityEngine.Object) this.animator_)
    {
      this.animator_.SetTrigger("isStart");
      this.animator_.enabled = true;
    }
    yield return (object) new WaitForSeconds(this.wait_);
    onFinished();
  }
}
