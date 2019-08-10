using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RFT.Api.Interfaces;
using RFT.Api.Repository;
using RFT.Api.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RFT.Api.Controllers
{
    public class TournamentController : Base.CrudController<Tournament>
    {
        private IDictionary<Elo, int> EloValues;

        public TournamentController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            EloValues = new Dictionary<Elo, int>();
            EloValues.Add(Elo.Iron, 1);
            EloValues.Add(Elo.Bronze, 2);
            EloValues.Add(Elo.Silver, 4);
            EloValues.Add(Elo.Gold, 6);
            EloValues.Add(Elo.Platinum, 10);
            EloValues.Add(Elo.Diamond, 15);
            EloValues.Add(Elo.Master, 20);
            EloValues.Add(Elo.GrandMaster, 26);
            EloValues.Add(Elo.Challenger, 32);
        }

        private int GetEloValue(Elo elo)
        {
            foreach (Elo v in Enum.GetValues(typeof(Elo)))
            {
                if (v != Elo.I && v != Elo.II && v != Elo.III && v != Elo.IV && v != Elo.None)
                    if (elo.HasFlag(v))
                        return EloValues[v];
            }
            return 0;
        }

        [HttpGet("{id}/Teams")]
        [ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetTeam(int id, CancellationToken ct)
        {
            /*
            var customData = new List<Player>();
            var n = 1;
            customData.Add(new Player { Id = n++, Elo = Elo.Bronze | Elo.III });
            customData.Add(new Player { Id = n++, Elo = Elo.Silver | Elo.I });
            customData.Add(new Player { Id = n++, Elo = Elo.Gold | Elo.IV });
            customData.Add(new Player { Id = n++, Elo = Elo.Iron | Elo.III });
            customData.Add(new Player { Id = n++, Elo = Elo.Platinum | Elo.III });
            customData.Add(new Player { Id = n++, Elo = Elo.Platinum | Elo.I });
            customData.Add(new Player { Id = n++, Elo = Elo.Gold | Elo.I });
            customData.Add(new Player { Id = n++, Elo = Elo.Silver | Elo.III });
            customData.Add(new Player { Id = n++, Elo = Elo.Bronze | Elo.II });
            customData.Add(new Player { Id = n++, Elo = Elo.Silver | Elo.III });
            customData.Add(new Player { Id = n++, Elo = Elo.Diamond | Elo.IV });
            customData.Add(new Player { Id = n++, Elo = Elo.Bronze | Elo.IV });

            var players = customData.AsEnumerable();
            */

            var players = await UnitOfWork.GetRepository<Player>().Get();
            /*
            var pt = (await Repository.GetById(id, ct)).PlayerTournaments;
            var players = pt.Select(x => x.Player);
            */

            var nTeams = players.Count() / 5;
            var eloAverage = players.Select(x => x.Elo).Select(x => GetEloValue(x)).Average();

            var list = new List<object>();
            var ids = players.Select(x => x.Id).ToList();

            for (int i = 0; i < nTeams; i++)
            {
                var teamValue = 0;
                var attempt = 0;

                do
                {
                    var temp = new List<Player>();
                    var tempIds = new List<int>();
                    for (int j = 0; j < 5; j++)
                    {
                        var rnd = new Random().Next(ids.Count());
                        var rndid = ids.ElementAt(rnd);
                        var player = players.SingleOrDefault(x => x.Id == rndid);
                        temp.Add(player);
                        ids.RemoveAt(rnd);
                    }
                    teamValue = (int)temp.Select(x => x.Elo).Select(x => GetEloValue(x)).Average() + 1;
                    if (++attempt >= 100)
                    {
                        list.Add(temp);
                        break;
                    }
                    if (teamValue > eloAverage - 6 && teamValue < eloAverage + 6)
                    {
                        list.Add(temp);
                        break;
                    }
                } while (true);

            }

            return Ok(list);
        }
    }
}
