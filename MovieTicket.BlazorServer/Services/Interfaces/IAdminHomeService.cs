﻿using MovieTicket.Application.DataTransferObjs.AdminHome;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
	public interface IAdminHomeService
	{
		Task<List<RevenueByCinemaDto>> GetListRevenueByCinemaAsync(DateTime? startDate, DateTime? endDate);
		Task<List<RevenueByMovieDto>> GetListRevenueByMovieAsync(DateTime? startDate, DateTime? endDate);
		Task<GeneralDto> GetAdminGeneralAsync();
	}
}