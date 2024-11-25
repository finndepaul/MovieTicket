using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.BillCombo;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
	public class BillComboReadOnlyRepository : IBillComboReadOnlyRepository
	{
		private readonly MovieTicketReadOnlyDbContext _db;

		public BillComboReadOnlyRepository(MovieTicketReadOnlyDbContext db)
		{
			_db = db;
		}

		public async Task<IQueryable<BillComboDto>> GetListBillComboByBillId(Guid billId, CancellationToken cancellationToken)
		{
			var query = await _db.BillCombos.Where(x => x.BillId == billId)
				.Join(_db.Combos, bc => bc.ComboId, c => c.Id, (bc, c) => new { bc, c })
				.Select(x => new BillComboDto
				{
					BillId = x.bc.BillId,
					Price = x.c.Price,
					ComboId = x.bc.ComboId,
					ComboName = x.c.Name,
					Quantity = x.bc.Quantity,
					TotalPrice = x.c.Price * x.bc.Quantity
				}).AsNoTracking().ToListAsync();
			return query.AsQueryable();
		}
	}
}
