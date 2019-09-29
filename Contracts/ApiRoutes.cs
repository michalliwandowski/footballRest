using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Contracts
{
	public static class ApiRoutes
	{
		public const string Root = "api";

		public const string Base = Root;

		public static class Teams
		{
			public const string GetAll = Base + "/teams";

			public const string Update = Base + "/teams/{teamId}";

			public const string Delete = Base + "/teams/{teamId}";

			public const string Get = Base + "/teams/{teamId}";

			public const string Create = Base + "/teams";
		}

		public static class Players
		{
			public const string GetAll = Base + "/players";

			public const string Get = Base + "/players/{playerId}";

			public const string Update = Base + "/players/{playerId}";

			public const string Create = Base + "/players";

			public const string Delete = Base + "/players/{playerId}";

			public const string AddToTeam = Base + "/playersAddToTeam";

			public const string RemoveFromTeam = Base + "/playersRemoveFromTeam/{playerId}";
		}
	}
}
