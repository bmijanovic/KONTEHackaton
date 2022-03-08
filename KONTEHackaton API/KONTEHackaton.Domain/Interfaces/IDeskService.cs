using KONTEHackaton.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONTEHackaton.Domain.Interfaces
{
    public interface IDeskService : IService<DeskDomainModel>
    {
        DeskDomainModel Delete(Guid id);
        DeskDomainModel Add(DeskDomainModel model);
    }
}
