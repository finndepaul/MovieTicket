﻿using MovieTicket.Application.DataTransferObjs.UserHome;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
	public interface IUserHomeReadOnlyRepository
	{
		Task<IQueryable<UserHomeDto>> GetAllFilmForUserHome();

		Task<int> GetPointOfMembershipAsync(Guid accountId, CancellationToken cancellationToken);
	}
}