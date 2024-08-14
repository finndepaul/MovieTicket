using AutoMapper;
using Microsoft.AspNetCore.Http;
using Azure.Core;
using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTicket.Domain.Enums;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class TicketPriceReadWriteReponsitory : ITicketPriceReadWriteReponsitory
    {
        private readonly MovieTicketReadWriteDbContext _dbContext;
        private readonly IMapper _map;

        public TicketPriceReadWriteReponsitory(MovieTicketReadWriteDbContext dbContext, IMapper map)
        {
            _dbContext = dbContext;
            _map = map;
        }

        public async Task<ResponseObject<TicketPriceCreateRequest>> Create(TicketPriceCreateRequest request, CancellationToken cancellationToken)
        {
            var ticketPrice = _map.Map<TicketPrice>(request);
            ticketPrice.Status = TicketPriceStatus.Active;
            await _dbContext.TicketPrices.AddAsync(ticketPrice);
            await _dbContext.SaveChangesAsync();
            return new ResponseObject<TicketPriceCreateRequest>
            {
                Data = request,
                Message = "Create ticket price success",
                Status = StatusCodes.Status200OK
            };
        }

        public async Task<ResponseObject<bool>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var ticketPrice = await _dbContext.TicketPrices.FindAsync(id);
            if (ticketPrice == null)
            {
                return new ResponseObject<bool>
                {
                    Data = false,
                    Message = "Ticket price not found",
                    Status = StatusCodes.Status404NotFound
                };
            }
            ticketPrice.Status = TicketPriceStatus.Inactive;
            _dbContext.TicketPrices.Update(ticketPrice);
            await _dbContext.SaveChangesAsync();
            return new ResponseObject<bool>
            {
                Data = true,
                Message = "Delete ticket price success",
                Status = StatusCodes.Status200OK
            };
        }

        public async Task<ResponseObject<TicketPriceUpdateRequest>> Update(TicketPriceUpdateRequest request, CancellationToken cancellationToken)
        {
            var ticketPrice = await _dbContext.TicketPrices.FindAsync(request.Id);
            if (ticketPrice == null)
            {
                return new ResponseObject<TicketPriceUpdateRequest>
                {
                    Data = null,
                    Message = "Ticket price not found",
                    Status = StatusCodes.Status404NotFound
                };
            }
            ticketPrice.ScreeningDayId = request.ScreeningDayId;
            ticketPrice.ScreenTypeId = request.ScreenTypeId;
            ticketPrice.SeatTypeId = request.SeatTypeId;
            ticketPrice.CinemaTypeId = request.CinemaTypeId;
            ticketPrice.Price = request.Price;
            _dbContext.TicketPrices.Update(ticketPrice);
            await _dbContext.SaveChangesAsync();
            return new ResponseObject<TicketPriceUpdateRequest>
            {
                Data = request,
                Message = "Update ticket price success",
                Status = StatusCodes.Status200OK
            };
        }
    }
}
