using System;
using System.Data.Entity.Validation;

namespace SuperheroesUniverse.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SuperheroeEntities dbContext;

        public UnitOfWork(SuperheroeEntities context)
        {
            this.dbContext = context;
        }

        public void Commit()
        {
            try
            {
                this.dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
            }
        }
    }
}
