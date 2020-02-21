using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UniqueEmailAddresses
{
	class Solution
	{
		/// <summary>
		/// A function designed to tell you the amount of unique emails within a list.
		/// </summary>
		/// <param emails="EmailList">a generic list of strings containing emails</param>
		public int NumberOfUniqueEmailAddresses(string[] emails)
		{
			List<string> uniqueEmails = new List<string>();

			foreach (string email in emails)
			{
				if (ValidEmail(email))
				{
					string[] parts = email.Split('@');
					string domain = parts[0].Split('+')[0].Replace(".", "");
					string address = parts[1];

					string simplifiedEmail = $"{domain}@{address}";

					if (!uniqueEmails.Contains(simplifiedEmail))
					{
						uniqueEmails.Add(simplifiedEmail);
					}
				}
				else
				{
					Console.WriteLine($"{email} was not a valid email and was excluded in the count");
				}
			}
			return uniqueEmails.Count;
		}

		private bool ValidEmail(string address)
		{
			Regex rx = new Regex("^(?:\\w*[.+]?){1,}@(?:\\w*\\.?){1,}$");
			return rx.IsMatch(address);
		}
	}
}
