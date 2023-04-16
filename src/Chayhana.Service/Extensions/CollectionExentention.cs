using Chayhana.Domain.Commons;
using Chayhana.Domain.Configurations;
using Chayhana.Service.Exeptions;
using System.Linq;

namespace Chayhana.Service.Extensions;

public static class CollectionExention
{
    public static IQueryable<TEntity> ToPagedList<TEntity> (this IQueryable<TEntity> entities, PaginationParams @params)
        where TEntity : Auditable
    {
        if (@params.PageIndex > 0 && @params.PageSize > 0)
        {
            var itemsForSkip = (@params.PageIndex - 1) * @params.PageSize;
            var totalCount = entities.Count();

            if (itemsForSkip >= totalCount && totalCount > 0)
                itemsForSkip = totalCount - totalCount % @params.PageSize;

            return entities.Skip(itemsForSkip).Take(@params.PageSize);
        }
        throw new CustomExeption(400, "Please, enter valid numbers");

    }
}
