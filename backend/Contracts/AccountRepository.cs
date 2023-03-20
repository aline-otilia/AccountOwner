using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities;
using Entities.Models;

namespace Contracts;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Account> AccountByOwner(Guid ownerId)
    {
        return FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList();
    }

    private object FindyByCondition(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }
}
