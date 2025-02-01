using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.Services;

public class TicketsService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tickets.AnyAsync(t => t.TicketId == id);
    }

    private async Task<bool> Insertar(Ticket ticket)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Tickets.Add(ticket);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Ticket ticket)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Tickets.Update(ticket);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Ticket ticket)
    {
        if (!await Existe(ticket.TicketId))
            return await Insertar(ticket);
        else
            return await Modificar(ticket);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var ticketsEliminados = await contexto.Tickets
            .Where(t => t.TicketId == id).ExecuteDeleteAsync();
        return ticketsEliminados > 0;
    }

    public async Task<Ticket?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tickets.AsNoTracking()
            .FirstOrDefaultAsync(t => t.TicketId == id);
    }

    public async Task<List<Ticket>> Listar(Expression<Func<Ticket, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tickets
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
