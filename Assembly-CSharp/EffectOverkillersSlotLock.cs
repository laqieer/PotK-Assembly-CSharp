// Decompiled with JetBrains decompiler
// Type: EffectOverkillersSlotLock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class EffectOverkillersSlotLock : MonoBehaviour
{
  [SerializeField]
  private Animator animator_;
  [SerializeField]
  private GameObject objUnity_;
  [SerializeField]
  private UILabel txtUnity_;
  [SerializeField]
  [Tooltip("開錠演出時間(秒)")]
  private float wait_ = 2f;

  public void initialize(int unityValue, bool bUnity)
  {
    this.objUnity_.SetActive(bUnity);
    this.txtUnity_.gameObject.SetActive(bUnity);
    if (bUnity)
      this.txtUnity_.SetTextLocalize(unityValue);
    this.gameObject.SetActive(true);
  }

  public void startUnlock(System.Action onFinished)
  {
    Singleton<NGSoundManager>.GetInstance().PlaySe("SE_2712");
    this.StartCoroutine(this.waitAnimation(onFinished));
  }

  private IEnumerator waitAnimation(System.Action onFinished)
  {
    this.animator_.SetTrigger("isStart");
    this.animator_.enabled = true;
    yield return (object) new WaitForSeconds(this.wait_);
    onFinished();
  }
}
