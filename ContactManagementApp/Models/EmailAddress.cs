using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContactManagementApp.Models
{
    public class EmailAddress
    {
        public int EmailAddressID { get; set; }
        public EmailAddressType EmailType { get; set; }

        private string _EmailAddressContent;
        public string EmailAddressContent
        {
            get { return _EmailAddressContent; }
            set
            {
                ValidateEmailAddress(value);
                _EmailAddressContent = value;
            }
        }

        public enum EmailAddressType
        {
            Personal = 0,
            Business = 1
        }

        /// <summary>
        /// </summary>
        /// <param name="proposedEmailAddress"></param>
        /// <returns></returns>
        public string ValidateEmailAddress(string proposedEmailAddress)
        {
            var isValid = false;

            if (!string.IsNullOrWhiteSpace(proposedEmailAddress))
            {
                try
                {
                    isValid = Regex.IsMatch(proposedEmailAddress, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                }
                catch (RegexMatchTimeoutException)
                {
                    //TODO: name exception and implement logging
                }
            }

            return isValid ? proposedEmailAddress : string.Empty;
        }

    }
}