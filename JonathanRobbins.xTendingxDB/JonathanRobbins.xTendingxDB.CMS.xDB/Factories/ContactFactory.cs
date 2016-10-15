using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.CMS.xDB.Entities;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Repository;
using JonathanRobbins.xTendingxDB.CMS.xDB.Repository;
using Sitecore.Analytics;
using Sitecore.Analytics.Data;
using Sitecore.Analytics.DataAccess;
using Sitecore.Analytics.Model;
using Sitecore.Analytics.Model.Entities;
using Sitecore.Analytics.Tracking;
using Sitecore.Data;
using Sitecore.Diagnostics;
using IContactFactory = JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Factories.IContactFactory;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Factories
{
    public class ContactFactory : IContactFactory
    {
        private readonly ContactManager _contactManager;
        private readonly ContactRepository _contactRepository;

        public ContactFactory()
        {
            _contactManager = Sitecore.Configuration.Factory.CreateObject("tracking/contactManager", true) as ContactManager;
            _contactRepository = Sitecore.Configuration.Factory.CreateObject("tracking/contactRepository", true) as ContactRepository;
        }

        public void UpdateContact(Contact contact, ContactModel contactModel, string entryName)
        {
            if (contactModel == null)
            {
                throw new ArgumentNullException(nameof(contactModel));
            }

            try
            {
                IContactPersonalInfo contactPersonalInfo = contact.GetFacet<IContactPersonalInfo>("Personal");

                if (string.IsNullOrEmpty(contactPersonalInfo.FirstName))
                    contactPersonalInfo.FirstName = contactModel.FirstName;
                if (string.IsNullOrEmpty(contactPersonalInfo.Surname))
                    contactPersonalInfo.Surname = contactModel.Surname;
                if (string.IsNullOrEmpty(contactPersonalInfo.JobTitle))
                    contactPersonalInfo.JobTitle = contactModel.Role;

                IContactEmailAddresses contactEmailAddresses = contact.GetFacet<IContactEmailAddresses>("Emails");

                if (string.IsNullOrEmpty(contactEmailAddresses.Preferred))
                    contactEmailAddresses.Preferred = entryName;

                if (!contactEmailAddresses.Entries.Contains(entryName))
                    contactEmailAddresses.Entries.Create(entryName);

                contactEmailAddresses.Entries[entryName].SmtpAddress = contactModel.EmailAddress;

                IContactPhoneNumbers contactNumbers = contact.GetFacet<IContactPhoneNumbers>("Phone Numbers");

                if (string.IsNullOrEmpty(contactNumbers.Preferred))
                    contactNumbers.Preferred = entryName;

                if (!contactNumbers.Entries.Contains(entryName))
                    contactNumbers.Entries.Create(entryName);

                contactNumbers.Entries[entryName].Number = contactModel.Number;

                IContactAddresses contactAddresses = contact.GetFacet<IContactAddresses>("Addresses");

                if (!contactAddresses.Entries.Contains(entryName))
                    contactAddresses.Entries.Create(entryName);

                if (string.IsNullOrEmpty(contactAddresses.Preferred))
                    contactAddresses.Preferred = entryName;

                contactAddresses.Entries[entryName].StreetLine1 = contactModel.AddressLine1;
                contactAddresses.Entries[entryName].StreetLine2 = contactModel.AddressLine2;
                contactAddresses.Entries[entryName].City = contactModel.City;
                contactAddresses.Entries[entryName].Country = contactModel.Country;
                contactAddresses.Entries[entryName].PostalCode = contactModel.PostCode;
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
            }
        }

        public Contact GetOrCreateContact(string emailAddress)
        {
            if (IsContactInSession(emailAddress))
            {
                return Tracker.Current.Session.Contact;
            }

            try
            {
                Contact contact;

                var foundContact = _contactRepository.LoadContactReadOnly(emailAddress);
                if (foundContact != null)
                {
                    LockAttemptResult<Contact> lockResult = _contactManager.TryLoadContact(foundContact.ContactId);

                    contact = ProcessContactLockResult(emailAddress, lockResult);
                }
                else
                {
                    contact = Tracker.Current.Session.Contact != null ? Tracker.Current.Session.Contact : CreateContact(emailAddress);
                }

                if (!contact.ContactId.Equals(Tracker.Current.Session.Contact.ContactId) ||
                    Tracker.Current.Session.Contact.Identifiers.IdentificationLevel != ContactIdentificationLevel.Known)
                {
                    Tracker.Current.Session.Identify(emailAddress);
                }

                return contact;
            }
            catch (Exception ex)
            {
                Log.Error("Error in GetrCreateContact :" + ex.Message, ex, this);
                throw new Exception(this.GetType() + " Contact could not be loaded/created - " + emailAddress + " - " + ex.Message, ex);
            }
        }

        private Contact ProcessContactLockResult(string emailAddress, LockAttemptResult<Contact> lockResult)
        {
            switch (lockResult.Status)
            {
                case LockAttemptStatus.Success:
                    Contact lockedContact = lockResult.Object;
                    lockedContact.ContactSaveMode = ContactSaveMode.AlwaysSave;
                    return lockedContact;

                case LockAttemptStatus.NotFound:
                    Contact createdContact = CreateContact(emailAddress);
                    _contactManager.FlushContactToXdb(createdContact);
                    return GetOrCreateContact(emailAddress);

                default:
                    throw new Exception(this.GetType() + " Contact could not be locked - " + emailAddress);
            }
        }

        private Contact CreateContact(string emailAddress)
        {
            Contact contact = _contactRepository.CreateContact(ID.NewID);
            contact.Identifiers.Identifier = emailAddress;
            contact.Identifiers.IdentificationLevel = ContactIdentificationLevel.Known;
            contact.System.Value = 0;
            contact.System.VisitCount = 0;
            contact.ContactSaveMode = ContactSaveMode.AlwaysSave;
            return contact;
        }

        private bool IsContactInSession(string emailAddress)
        {
            if (emailAddress == null)
            {
                throw new ArgumentNullException(nameof(emailAddress));
            }

            bool? contactInSession = false;

            var tracker = Tracker.Current;
            if (tracker?.IsActive != null)
            {
                contactInSession = tracker.Session?.Contact?.Identifiers?.Identifier?.Equals(emailAddress, StringComparison.InvariantCultureIgnoreCase);
            }

            return contactInSession.HasValue && contactInSession.Value;
        }
    }
}
