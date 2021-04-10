using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
    public class PlayerWithPositionSpecification : BaseSpecification<Player>
    {
        public PlayerWithPositionSpecification()
        {
            // AddInclude(x => x.Position);

        }

        // public PlayerWithPositionSpecification(int id) : base(x => x.Id => id)
        // {
        //                 // AddInclude(x => x.Position);
        // }
    }
}