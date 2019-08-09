using RFT.Api.Interfaces;
using RFT.Api.Repository.Models;
using RFT.Api.Repository.Models.Base;
using RFT.Api.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RFT.Api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDictionary<Type, object> _repositories;

        private PlayerRepository _playerRepository;
        private TournamentRepository _tournamentRepository;
        private UserRepository _userRepository;

        private RFTContext context;

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
                LoadRepos();
            return (IRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        private void LoadRepos()
        {
            _repositories = new Dictionary<Type, object>();
            _repositories.Add(typeof(Player), new PlayerRepository(context));
            _repositories.Add(typeof(Tournament), new TournamentRepository(context));
            _repositories.Add(typeof(User), new UserRepository(context));
        }

        public PlayerRepository PlayerRepository
        {
            get
            {
                if (_playerRepository == null)
                {
                    _playerRepository = new PlayerRepository(context);
                }
                return _playerRepository;
            }
        }

        public TournamentRepository TournamentRepository
        {
            get
            {
                if (_tournamentRepository == null)
                {
                    _tournamentRepository = new TournamentRepository(context);
                }
                return _tournamentRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(context);
                }
                return _userRepository;
            }
        }

        public UnitOfWork(RFTContext context)
        {
            this.context = context;
        }

        public async Task CommitAsync(CancellationToken ct = default)
        {
            await context.SaveChangesAsync(ct);
        }
    }
}
