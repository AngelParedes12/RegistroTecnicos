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

    private async Task<bool> Insertar(Tickets ticket)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Tickets.Add(ticket);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Tickets ticket)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Tickets.Update(ticket);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Tickets ticket)
    {
        if (ticket == null)
            throw new ArgumentNullException(nameof(ticket));

        if (string.IsNullOrEmpty(ticket.Asunto))
            throw new ArgumentException("El asunto del ticket no puede estar vacío.");

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

    public async Task<Tickets?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tickets.AsNoTracking()
            .FirstOrDefaultAsync(t => t.TicketId == id);
    }

    public async Task<Tickets?> BuscarPorAsunto(string asunto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tickets.AsNoTracking()
            .FirstOrDefaultAsync(t => t.Asunto == asunto);
    }

    public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tickets
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Tickets>> ListarConRelaciones(Expression<Func<Tickets, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tickets
            .Include(t => t.Clientes)
            .Include(t => t.Tecnicos) 
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}