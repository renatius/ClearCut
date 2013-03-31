using System;

namespace Clearcut.DomainModel
{
    public static class UseCase
    {
        public static void Execute(Scenario scenario, Actor actor)
        {
            Precondition.Requires(
                scenario != null,
                Properties.Resources.USE_CASE_SCENARIO_CANNOT_BE_NULL
                );

            Precondition.Requires(
                actor != null,
                Properties.Resources.USE_CASE_ACTOR_CANNOT_BE_NULL
                );

            try
            {
                if (!scenario.Authorize(actor))
                {
                    throw new AuthorizationException(Properties.Resources.USER_AUTHORIZATION_FAILED);
                }

                scenario.Execute();
            }
            catch (DomainException)
            {
                throw;
            }
            catch (Exception exc)
            {
                throw new DomainException(exc.Message, exc);
            }            
        }
    }
}
