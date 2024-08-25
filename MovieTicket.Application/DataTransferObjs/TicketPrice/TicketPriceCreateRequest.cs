using MovieTicket.Application.ValueObjs.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.TicketPrice
{
	public class TicketPriceCreateRequest
	{
		public Guid SeatTypeId { get; set; }
		public Guid ScreenTypeId { get; set; }
		public Guid ScreeningDayId { get; set; }
		public Guid CinemaTypeId { get; set; }
		public decimal Price { get; set; }

		public string Validate()
		{
			string message = "";
			if (String.IsNullOrEmpty(SeatTypeId.ToString()))
			{
				message += "SeatTypeId is required. ";
			}
			if (String.IsNullOrEmpty(ScreenTypeId.ToString()))
			{
				message += "ScreenTypeId is required. ";
			}
			if (String.IsNullOrEmpty(ScreeningDayId.ToString()))
			{
				message += "ScreeningDayId is required. ";
			}
			if (String.IsNullOrEmpty(CinemaTypeId.ToString()))
			{
				message += "CinemaTypeId is required. ";
			}
			if (String.IsNullOrEmpty(Price.ToString()))
			{
				message += "Price is required. ";
			}
			if (Price <= 20000)
			{
				message += "Price must be more than 20000. ";
			}
			return message;
		}
	}
}
