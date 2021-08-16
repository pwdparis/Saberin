namespace ContactManagementApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ContactManagementApp.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<ContactManagementApp.Models.ContactContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContactManagementApp.Models.ContactContext ctxt)
        {
            var seedContacts = new List<Person>
            {
                new Person { ID=0, FirstName="Blues", LastName="Jake", EmailAddresses = new List<EmailAddress>() {
                        new EmailAddress { EmailAddressID = 0, EmailType = EmailAddress.EmailAddressType.Personal, EmailAddressContent = "jolietjake@jolietcorrectionalcenter.illinois.gov" },
                        new EmailAddress { EmailAddressID = 1, EmailType = EmailAddress.EmailAddressType.Business, EmailAddressContent = "jakes.blues@paramountpictures.com" }
                    }
                },
                new Person { ID=1, FirstName="Blues", LastName="Elwood", EmailAddresses = new List<EmailAddress>() {
                    new EmailAddress { EmailAddressID = 2, EmailType = EmailAddress.EmailAddressType.Business, EmailAddressContent = "elwood.blues@paramountpictures.com" }
                }},
                new Person { ID=2, FirstName="Cleophus", LastName="James", EmailAddresses = new List<EmailAddress>() {
                    new EmailAddress { EmailAddressID = 3, EmailType = EmailAddress.EmailAddressType.Business, EmailAddressContent = "reverend.cleophus.james@triplerockbaptistchurch.org" },
                    new EmailAddress { EmailAddressID = 4, EmailType= EmailAddress.EmailAddressType.Personal, EmailAddressContent = "bsmith@namehider.org" }
                }},
                new Person { ID=3, FirstName="Curtis", LastName="Mayfield", EmailAddresses = new List<EmailAddress>() {
                    new EmailAddress { EmailAddressID = 5, EmailType= EmailAddress.EmailAddressType.Business, EmailAddressContent = "jjoliet@jolietcorrectionalcenter.illinois.gov" }
                }},
                new Person { ID=4, FirstName="Ray", LastName="Jones", EmailAddresses = new List<EmailAddress>() {
                    new EmailAddress { EmailAddressID = 5, EmailType= EmailAddress.EmailAddressType.Business, EmailAddressContent = "jjoliet@jolietcorrectionalcenter.illinois.gov" }
                }},
                new Person { ID=5, FirstName="Mrs", LastName="Murphy", EmailAddresses = new List<EmailAddress>() {
                    new EmailAddress { EmailAddressID = 6, EmailType= EmailAddress.EmailAddressType.Business, EmailAddressContent = "jjoliet@jolietcorrectionalcenter.illinois.gov" }
                }},
                new Person { ID=6, FirstName="Mary", LastName="Stigmata", EmailAddresses = new List<EmailAddress>() {
                    new EmailAddress { EmailAddressID = 6, EmailType= EmailAddress.EmailAddressType.Business, EmailAddressContent = "jjoliet@jolietcorrectionalcenter.illinois.gov" }
                }}
            };

            seedContacts.ForEach(s => ctxt.People.AddOrUpdate(s));
            ctxt.SaveChanges();
        }

    }
}
