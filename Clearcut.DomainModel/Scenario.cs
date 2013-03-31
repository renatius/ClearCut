using System;

namespace Clearcut.DomainModel
{
    public interface Scenario
    {
        bool Authorize(Actor actor);
        void Execute();
    }
}
