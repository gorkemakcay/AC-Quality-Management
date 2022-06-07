using Microsoft.AspNetCore.Identity;
using QM.Entities.Interface;
using System;

namespace QM.Entities.Concrete.Users
{
    public class AppRole : IdentityRole<int>, ITable
    {
    }
}
