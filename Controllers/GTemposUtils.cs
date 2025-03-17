using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PKX.Data;
using PKX.Models;
using System.Linq.Expressions;

namespace PKX.Controllers
{
    public static class GTemposUtils
    {
        /// <summary>
        /// Returns a SelectList with items from a database table to.
        /// </summary>
        /// <typeparam name="T">The type of the entity in the database (e.g., Atividade, Funcionário, Cliente).</typeparam>
        /// <param name="values">The set of values from the database.</param>
        /// <param name="displayMember">The name of the property to display in the ListBox.</param>
        public static SelectList BuildSelectList<T>(DbSet<T> values, string displaymember) where T : class, new()
        {
            return new SelectList(values.ToList(), "Id", displaymember);
        }

        private static string GetNonEmptyString(String txt)
        {
            if (!string.IsNullOrEmpty(txt))
            {
                return txt;
            }
            return "";
        }

        /// <summary>
        /// Creates a query for retrieving data to populate a DataGridView with filtered process line data.
        /// </summary>
        /// <param name="PK1">The primary key for the AtividadeId filter.</param>
        /// <param name="PK2">The primary key for the FuncionarioId filter.</param>
        /// <param name="PK2">The primary key for the ClienteId filter.</param>
        /// <returns>An IQueryable containing the filtered data.</returns>
        // Note: Try/Catch provided by ChatGPT. I'm not not confortable with this mechanism 😣
        //public static IQueryable<dynamic> GetFilteredTemposQuery(ApplicationDbContext context, int PK1, int PK2, int PK3)
        //{
        //    try
        //    {
        //        if (context.Tempos == null)
        //        {
        //            throw new NullReferenceException("context.Tempos is null! Cannot generate query.");
        //        }
                
        //    IQueryable<Tempo>? query = context.Tempos;
                
        //    if (PK1 > 0) query = FilterByProperty(query, "AtividadeId", PK1);
        //    if (PK2 > 0) query = FilterByProperty(query, "FuncionarioId", PK2);
        //    if (PK3 > 0) query = FilterByProperty(query, "ClienteId", PK3);
            
        //    return GetTemposWithDetails(query, context);
        //    }
        //    catch(Exception ex)
        //    {
        //        // Log the error (or print it for now)
        //        Console.WriteLine($"[ERROR] {ex.Message}");

        //        // Return an empty list instead of crashing
        //        return Enumerable.Empty<object>().AsQueryable();
        //    }
        //}

        public static IQueryable<dynamic> GetFilteredTemposQuery(ApplicationDbContext context, int PK1, int PK2, int PK3, string sortedBy, bool isAsc)
        {
            try
            {
                if (context.Tempos == null)
                {
                    throw new NullReferenceException("context.Tempos is null! Cannot generate query.");
                }

                IQueryable<Tempo>? query = context.Tempos;

                if (PK1 > 0) query = FilterByProperty(query, "AtividadeId", PK1);
                if (PK2 > 0) query = FilterByProperty(query, "FuncionarioId", PK2);
                if (PK3 > 0) query = FilterByProperty(query, "ClienteId", PK3);

                return GetTemposWithDetails(query, context, sortedBy, isAsc);

            }
            catch (Exception ex)
            {
                // Log the error (or print it for now)
                Console.WriteLine($"[ERROR] {ex.Message}");

                // Return an empty list instead of crashing
                return Enumerable.Empty<object>().AsQueryable();
            }
        }

        private static IQueryable<Tempo> FilterByProperty(IQueryable<Tempo> query, string propertyName, int PK)
        {
            if (PK <= 0) return query; // Skip if PK is not valid

            var parameter = Expression.Parameter(typeof(Tempo), "tempo");
            var property = Expression.Property(parameter, propertyName);
            var value = Expression.Constant(PK);
            var equalsExpression = Expression.Equal(property, value);

            var lambda = Expression.Lambda<Func<Tempo, bool>>(equalsExpression, parameter);
            
            return query.Where(lambda);
        }

        //private static IQueryable<object> GetTemposWithDetails(IQueryable<Tempo> query, ApplicationDbContext context)
        //{

        //    return from t in query // `query` from ListarTempo
        //            join a in context.Atividades on t.AtividadeId equals a.Id
        //            join f in context.Funcionarios on t.FuncionarioId equals f.Id
        //            join c in context.Clientes on t.ClienteId equals c.Id
        //            select new
        //            {
        //                t.Id,
        //                t.Data,
        //                t.Descritivo,
        //                t.Minutos,
        //                t.AtividadeId,
        //                Atividade = a.Designacao,
        //                t.FuncionarioId,
        //                Funcionario = f.NomeFuncionario,
        //                t.ClienteId,
        //                Cliente = c.NomeCliente
        //            };
        //}

        private static IQueryable<object> GetTemposWithDetails(IQueryable<Tempo> query, ApplicationDbContext context, string sortedBy, bool isAsc)
        {
            //if (!string.IsNullOrEmpty(sortedBy))
            //{
            //    var orderDirection = isAsc ? "ascending" : "descending";
            //    query = query.OrderBy($"{sortedBy} {orderDirection}");
            //}


            var detailedQuery = from t in query // `query` from listartempo
                                join a in context.Atividades on t.AtividadeId equals a.Id
                                join f in context.Funcionarios on t.FuncionarioId equals f.Id
                                join c in context.Clientes on t.ClienteId equals c.Id
                                select new
                                {
                                    t.Id,
                                    t.Data,
                                    t.Descritivo,
                                    t.Minutos,
                                    t.AtividadeId,
                                    Atividade = a.Designacao,
                                    t.FuncionarioId,
                                    Funcionario = f.NomeFuncionario,
                                    t.ClienteId,
                                    Cliente = c.NomeCliente
                                };

            
            return detailedQuery;
        }


        private static IQueryable<Tempo> FilterByMultipleTxt(IQueryable<Tempo> query, string[] propertyNames, string txt)
        {
            if (string.IsNullOrEmpty(txt)) return query; // Skip if search text is empty

            var parameter = Expression.Parameter(typeof(Tempo), "tempo");
            Expression combinedExpression = null;

            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

            foreach (var propertyName in propertyNames)
            {
                var property = Expression.Property(parameter, propertyName); // e.g., tempo.Descritivo
                var value = Expression.Constant(txt);

                var containsExpression = Expression.Call(property, containsMethod, value); // tempo.Descritivo.Contains(txt) equivalent to NomeCliente.Contains(txt)

                // Combine multiple conditions using OR (||)
                combinedExpression = combinedExpression == null
                    ? containsExpression
                    : Expression.OrElse(combinedExpression, containsExpression);
            }

            if (combinedExpression == null) return query; // No valid expressions

            var lambda = Expression.Lambda<Func<Tempo, bool>>(combinedExpression, parameter); //equivalent to (m => m.NomeCliente.Contains(txt))

            return query.Where(lambda);
        }
    }
}
