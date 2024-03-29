﻿using SistemaEscolar.Infrastructure.Persistence.Contexts;
using SistemaEscolar.Infrastructure.Persistence.Interfaces;

namespace SistemaEscolar.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SistemaEscolarContext _context;
        private bool disposed = false;

        public IUserRepository Users { get; private set; }
        public IInstitutionRepository Institutions { get; private set; }
        public IEducationalLevelRepository EducationalLevels { get; private set; }
        public IInstitutionEducationalRepository InstitutionEducationalLevels { get; private set; }

        public UnitOfWork(SistemaEscolarContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Institutions = new InstitutionRepository(_context);
            EducationalLevels = new EducationalLevelRepository(_context);
            InstitutionEducationalLevels = (IInstitutionEducationalRepository)new InstitutionEducationalLevelRepository(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
