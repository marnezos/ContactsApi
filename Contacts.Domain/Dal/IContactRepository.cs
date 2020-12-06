using Contacts.Domain.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Domain.Dal
{
    public interface IContactRepository:IRepository<Contact>
    {
        //Custom contact methods go here
    }
}
