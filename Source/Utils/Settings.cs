using System;
using System.Collections;

namespace Utils
{
	internal struct Settings
	{
		internal Hashtable settings;

		internal Settings(Hashtable ht)
		{
			settings = ht;
		}

		internal Hashtable Get()
		{
			return settings;
		}

		internal bool GetBoolean(string Key, bool defaultValue = false)
		{
			return !bool.TryParse((string)settings[Key], out bool result) ? defaultValue : result;
		}

		internal Decimal GetDecimal(string Key)
		{
			return Decimal.TryParse((string)settings[Key], out decimal result) ? result : 0M;
		}

		internal string GetString(string Key)
		{
			return (string)settings[Key] ?? "";
		}

		internal void Set(Hashtable newSettings)
		{
			settings = newSettings;
		}

		internal void SetBoolean(string key, bool value)
		{
			settings[key] = value.ToString();
		}

		internal void SetDecimal(string key, Decimal value)
		{
			settings[key] = value.ToString();
		}

		internal void SetString(string key, string value)
		{
			settings[key] = value ?? "";
		}
	}
}