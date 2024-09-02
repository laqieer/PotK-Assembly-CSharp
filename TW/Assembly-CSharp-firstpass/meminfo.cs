// Decompiled with JetBrains decompiler
// Type: meminfo
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System.IO;
using System.Text.RegularExpressions;

#nullable disable
public class meminfo
{
  public static meminfo.meminf minf = new meminfo.meminf();
  private static Regex re = new Regex("\\d+");

  public static bool getMemInfo()
  {
    if (!File.Exists("/proc/meminfo"))
      return false;
    FileStream fileStream = new FileStream("/proc/meminfo", FileMode.Open, FileAccess.Read, FileShare.Read);
    StreamReader streamReader = new StreamReader((Stream) fileStream);
    string str;
    while ((str = streamReader.ReadLine()) != null)
    {
      string s = str.ToLower().Replace(" ", string.Empty);
      if (s.Contains("memtotal"))
        meminfo.minf.memtotal = meminfo.mVal(s);
      if (s.Contains("memfree"))
        meminfo.minf.memfree = meminfo.mVal(s);
      if (s.Contains("active"))
        meminfo.minf.active = meminfo.mVal(s);
      if (s.Contains("inactive"))
        meminfo.minf.inactive = meminfo.mVal(s);
      if (s.Contains("cached") && !s.Contains("swapcached"))
        meminfo.minf.cached = meminfo.mVal(s);
      if (s.Contains("swapcached"))
        meminfo.minf.swapcached = meminfo.mVal(s);
      if (s.Contains("swaptotal"))
        meminfo.minf.swaptotal = meminfo.mVal(s);
      if (s.Contains("swapfree"))
        meminfo.minf.swapfree = meminfo.mVal(s);
    }
    streamReader.Close();
    fileStream.Close();
    fileStream.Dispose();
    return true;
  }

  private static int mVal(string s) => int.Parse(meminfo.re.Match(s).Value);

  public struct meminf
  {
    public int memtotal;
    public int memfree;
    public int active;
    public int inactive;
    public int cached;
    public int swapcached;
    public int swaptotal;
    public int swapfree;
  }
}
