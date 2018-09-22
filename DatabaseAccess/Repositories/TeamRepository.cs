﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DatabaseAccess.ExternalModel;

namespace DatabaseAccess.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public async Task<ExternalModel.Team> GetTeamAsync(string teamReference)
        {
            ExternalModel.Team newTeam = null;

            bool converts = int.TryParse(teamReference, out int teamId);

            if (converts == false)
                return null;

            using (var context = new DatabaseContext())
            {
                InternalModel.Team team = await context.Teams.Include(cl => cl.Club).SingleOrDefaultAsync(tm => tm.TeamId == teamId);

                if (team != null)
                {
                    newTeam = new ExternalModel.Team(
                        team.TeamId.ToString(),
                        ExternalModel.Club.Convert(team.Club),
                        team.ShortName,
                        team.LongName,
                        team.TeamRef,
                        team.IsDirty.ToString(),
                        team.Url,
                        team.SponsorsName,
                        team.SponsorsUrl,
                        team.MiniName);
                }

                return newTeam;
            }
        }

        public async Task<ReadOnlyCollection<ExternalModel.TeamsInClubResult>> GetTeamsInClubAsync(string clubId)
        {
            List<ExternalModel.TeamsInClubResult> teams = new List<ExternalModel.TeamsInClubResult>();

            using (var context = new DatabaseContext())
            {
                var databaseTeams = await context.Database.SqlQuery<InternalModel.TeamsInClubResult>(
                    "dbo.api_GetTeamsinClubID @clubId",
                    new SqlParameter("clubId", int.Parse(clubId))).ToListAsync();

                foreach (InternalModel.TeamsInClubResult team in databaseTeams)
                {
                    ExternalModel.TeamsInClubResult newTeam = new ExternalModel.TeamsInClubResult(
                        team.TeamId.ToString(),
                        team.TeamName,
                        team.NclTeam == "NCL",
                        team.LongName
                    );

                    teams.Add(newTeam);
                }
            }

            return new ReadOnlyCollection<ExternalModel.TeamsInClubResult>(teams);
        }

        public async Task<ReadOnlyCollection<ExternalModel.SeasonsForTeamResult>> GetSeasonsForTeamsAsync(string teamReference)
        {
            List<ExternalModel.SeasonsForTeamResult> seasons = new List<ExternalModel.SeasonsForTeamResult>();

            bool converts = int.TryParse(teamReference, out int teamId);

            if (!converts) return null;

            using (var context = new DatabaseContext())
            {
                var databaseSeasons = await context.Database.SqlQuery<InternalModel.SeasonsForTeamResult>(
                    "dbo.api_GetNCLSeasonsForTeamID @teamId",
                    new SqlParameter("teamId", teamId)).ToListAsync();


                foreach (InternalModel.SeasonsForTeamResult season in databaseSeasons)
                {
                    ExternalModel.SeasonsForTeamResult newSeason = new ExternalModel.SeasonsForTeamResult(
                        season.SeasonId.ToString(),
                        season.ShortName);

                    seasons.Add(newSeason);
                }
            }

            return new ReadOnlyCollection<SeasonsForTeamResult>(seasons);
        }
    }
}