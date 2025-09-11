// Decompiled with JetBrains decompiler
// Type: LauncherCS.Settings
// Assembly: Launcher, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BE2EDF30-BDA3-4FE0-9EFC-B0A1BE215D80
// Assembly location: D:\SteamLibrary\steamapps\common\Call of Duty Black Ops\bin\Launcher.exe

using System;
using System.Collections;

namespace LauncherCS
{
  public struct Settings
	{
		public Hashtable settings;

		public Settings(Hashtable ht)
		{
			settings = ht;
		}

		public Hashtable Get() => this.settings;

    public bool GetBoolean(string Key, bool defaultValue = false)
    {
      bool result = defaultValue;
      return !bool.TryParse((string) this.settings[(object) Key], out result) ? defaultValue : result;
    }

    public Decimal GetDecimal(string Key)
    {
      Decimal result = 0M;
      return Decimal.TryParse((string) this.settings[(object) Key], out result) ? result : 0M;
    }

    public string GetString(string Key) => (string) this.settings[(object) Key] ?? "";

    public void Set(Hashtable newSettings) => this.settings = newSettings;

    public void SetBoolean(string Key, bool Value)
    {
      this.settings[(object) Key] = (object) Value.ToString();
    }

    public void SetDecimal(string Key, Decimal Value)
    {
      this.settings[(object) Key] = (object) Value.ToString();
    }

    public void SetString(string Key, string Value)
    {
      this.settings[(object) Key] = Value != null ? (object) Value : (object) "";
    }
  }
}
