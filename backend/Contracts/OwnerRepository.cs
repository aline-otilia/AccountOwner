using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Contracts;

public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
{
    public OwnerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Owner> GetAllOwners()
    {
        return FindAll().OrderBy(ow => ow.Name).ToList();
    }

    public Owner GetOwnerById(Guid ownerId)
    {
        return FindByCondition(owner => owner.Id.Equals(ownerId)).FirstOrDefault();
    }

    public Owner GetOwnerWithDetails(Guid ownerId){
        return FindByCondition(owner => owner.Id.Equals(ownerId)).Include(ac => ac.Accounts).FirstOrDefault();
    }
}
