// Decompiled with JetBrains decompiler
// Type: Startup000121ScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class Startup000121ScrollParts : MonoBehaviour
{
  [SerializeField]
  public UILabel title;
  [SerializeField]
  protected UILabel date;
  [SerializeField]
  protected UILabel time;
  [SerializeField]
  protected UILabel badge;
  protected OfficialInformationArticle article;
  [SerializeField]
  protected GameObject newSprite;
  [SerializeField]
  private string nextSceneName;

  public string NextSceneName
  {
    get => this.nextSceneName;
    set => this.nextSceneName = value;
  }

  public void IbtnNewslist()
  {
    Singleton<NGSoundManager>.GetInstance().stopVoice();
    Singleton<NGSceneManager>.GetInstance().changeScene(this.NextSceneName, true, (object) this.article);
  }

  public virtual void Set(OfficialInformationArticle info, string listSceneName)
  {
    this.NextSceneName = listSceneName;
    this.article = info;
    if (Object.op_Inequality((Object) this.title, (Object) null))
      this.title.SetText(info.title);
    this.badge.SetTextLocalize(info.badge_display);
  }

  public virtual void SetData(OfficialInformationArticle info, NGMenuBase menu)
  {
  }

  public virtual bool SetNewSprite()
  {
    bool isPast = this.article.IsPast;
    if (Persist.infoUnRead.Data.GetUnRead(this.article.id) || isPast)
    {
      this.newSprite.SetActive(false);
      return false;
    }
    this.newSprite.SetActive(true);
    return true;
  }
}
