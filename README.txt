1. Get all players.
Get Json with all players with basic information
https://localhost:5001/api/players

2. Get single player.
Get Json with one player with detailed information
https://localhost:5001/api/players/1

3. Post Create player.
Post Json with player properties. Adds player to database,
https://localhost:5001/api/player
{
    "name": "Thomas",
    "number": 1,
    "age": 28,
    "height": 190,
    "TeamId": 2
}

4. Put update player properties.
Put Json with player properties. Updates player in database
https://localhost:44389/api/players/106
{
    "name": "Thomas Lastname"
}

5. Delete delete player.
Deletes player from the database
https://localhost:44389/api/players/15

6. Put add player to a team.
Put Json with PlayerId and TeamId properties. Adds player to Team.
https://localhost:5001/api/PlayersAddToTeam
{
    "PlayerId": 105,
    "TeamId": 3
}

7. Put removes player from team.
Put Sets TeamId key to 1 (reserved for "NoTeamPlayers")
https://localhost:44389/api/PlayersRemoveFromTeam/1

8. Get all teams.
Get Json with all teams with basic information
https://localhost:5001/api/teams

9. Get single team.
Get Json with Single teams with basic information and listed all players
https://localhost:5001/api/teams/1















