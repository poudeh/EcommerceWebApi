﻿using Common.Query.Filter;
using MediatR;

namespace Common.Query
{
    public interface IQuery<TResponse>:IRequest<TResponse> where TResponse : class
    {



    }

    public class QueryFilter<TResponse, TParam> : IQuery<TResponse> //It Should Give ME filter Result and Filterparam
        where TResponse : BaseFilter
        where TParam : BaseFilterParam
    {
        public TParam FilterParams { get; set; }
        public QueryFilter(TParam filterParams)
        {
            FilterParams = filterParams;
        }
    }
}
