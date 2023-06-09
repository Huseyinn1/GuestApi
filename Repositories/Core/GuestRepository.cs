﻿using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Core
{
    public class GuestRepository : RepositoryBase<Guest>, IGuestRepository
    {
        public GuestRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneGuest(Guest guest) => Create(guest);

  

        public void DeleteOneGuest(Guest guest) => Delete(guest);
      

        public IQueryable<Guest> GetAllGuests(bool trackChanges) =>
            
            FindAll(trackChanges).OrderBy(x => x.Id);
        

        public Guest GetOneGuestById(Guid id, bool trackChanges) => 
           
            FindByCondition(b =>b.Id.Equals(id),trackChanges).SingleOrDefault();
                
        public void UpdateOneGuest(Guest guest) => Update(guest);
    
    }
}
