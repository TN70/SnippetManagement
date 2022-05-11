using Core.Application.Parameters;
using System;

namespace Core.Application.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(RequestParameter filter, string route);
    }
}
