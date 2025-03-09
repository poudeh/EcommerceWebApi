namespace Common.Query.Filter;

public class BaseFilter
{
    public int EntityCount { get; private set; } //Number of entities
    public int CurrentPage { get; private set; }
    public int PageCount { get; private set; } //Tedade safhe
    public int StartPage { get; private set; } //az yek safhe be safhe digar
    public int EndPage { get; private set; }
    public int Take { get; private set; }

    //For Entity frameWork
    public void GeneratePaging(IQueryable<Object> data, int take, int currentPage)
    {
        var entityCount = data.Count();
        var pageCount = (int)Math.Ceiling(entityCount / (double)take);
        PageCount = pageCount;
        CurrentPage = currentPage;
        EndPage = (currentPage + 5 > pageCount) ? pageCount : currentPage + 5;
        EntityCount = entityCount;
        Take = take;
        StartPage = (currentPage - 4 <= 0) ? 1 : currentPage - 4;
    }

    //For Dapper
    public void GeneratePaging(int count, int take, int currentPage)
    {
        var entityCount = count;
        var pageCount = (int)Math.Ceiling(entityCount / (double)take);
        PageCount = pageCount;
        CurrentPage = currentPage;
        EndPage = (currentPage + 5 > pageCount) ? pageCount : currentPage + 5;
        EntityCount = entityCount;
        Take = take;
        StartPage = (currentPage - 4 <= 0) ? 1 : currentPage - 4;
    }
}


public class BaseFilterParam
{
    public int PageId { get; set; } = 1;
    public int Take { get; set; } = 10;
}

public class BaseFilter<TData, TParam> : BaseFilter where TParam : BaseFilterParam // Must be derived from BaseFilterParam.
    where TData : BaseDto // Must be derived from BaseDto.
{
    public List<TData> Data { get; set; } // The paginated and filtered data.
    public TParam FilterParams { get; set; } // The filter parameters.
}